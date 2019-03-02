using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Controller : MonoBehaviour {
    [Header("확인해야할 변수")]
    [SerializeField] int randomly_Created_Value;
    [SerializeField] int Remained_Event_Num = 0;

    [Space(30)]
    [Header("기본 랜덤 생성 이벤트(프리팹 적용할것)")]
    [SerializeField] GameObject[] Default_Event;
    [Header("특정 기간 생성 이벤트")]
    [SerializeField] GameObject[] Periodic_Event;
    [Header("활동 연계 이벤트")]
    [SerializeField] GameObject[] Activative_Event;
    [Space(30)]
    [Header("적용해야할 변수")]
    [SerializeField] GameObject canvas_Obj;

    //Hide
    List<GameObject> Window_Objs = new List<GameObject>();

    public void Get_Turn_Over_Signal()
    {
        Remained_Event_Num = 0;
        Window_Objs = new List<GameObject>();
        int checked_Value = Check_Periodic_Event_First();
        if (checked_Value != -1)
        {
            Window_Objs.Add(Instantiate(Periodic_Event[checked_Value], canvas_Obj.transform));
            Remained_Event_Num++;
            Window_Objs[Window_Objs.Count - 1].SendMessage("Get_Turn_Over_Signal");
            Window_Objs[Window_Objs.Count - 1].SetActive(false);
        }

        Random_Value_Create();
        Window_Objs.Add(Instantiate(Default_Event[randomly_Created_Value], canvas_Obj.transform));
        Remained_Event_Num++;
        Window_Objs[Window_Objs.Count - 1].SendMessage("Get_Turn_Over_Signal");
        Window_Objs[Window_Objs.Count - 1].SetActive(false);

        //실행
        Window_Objs[Window_Objs.Count - 1].SetActive(true);
    }

    public void Get_Activate_Event_Signal(int num)
    {
        if (num >= Activative_Event.Length || num < 0) Debug.Log("From Event_Controller 활동연계 이벤트 변수 잘못된 값 입력");
        Window_Objs.Add(Instantiate(Activative_Event[num], canvas_Obj.transform));
        Remained_Event_Num++;
        Window_Objs[Window_Objs.Count - 1].SendMessage("Get_Turn_Over_Signal");
    }

    public void Get_Event_End_Signal(GameObject target)
    {
        Remained_Event_Num--;
        Window_Objs.Remove(target);
        if (Window_Objs.Count == 0) GetComponent<Stage_Controller>().Get_Event_End_Siganl();
        else Window_Objs[Window_Objs.Count - 1].SetActive(true);

        //Debug.Log("From Event_Controller Windos_Objs.Count : " + Window_Objs.Count);

    }

    void Random_Value_Create()
    {
        randomly_Created_Value = Mathf.RoundToInt(Random.Range(0.0f, Default_Event.Length - 1));
    }

    int Check_Periodic_Event_First()
    {
        for (int i = 0; i < Periodic_Event.Length; i++)
            if (Periodic_Event[i].GetComponent<Periodic_Event_Property>().Month == GetComponent<Stage_Controller>().Month)
            {
                return i;
            }
        return -1;
    }


}