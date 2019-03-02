using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage_Controller : MonoBehaviour {
    [Header("확인해야할 변수")]
    [SerializeField] int Stage_Num = 1;
    public int Month = 1, Year = 2018;
    public bool is_Turn_ready_To_end = true;

    [Header("적용해야 할 변수")]
    [SerializeField] Text Date_Text;
    [SerializeField] GameObject Dark_Change_Obj;
    [SerializeField] ScheduleResult script_Schedule;
    [SerializeField] GameObject plum;

    //[Hearder("조정해야할 변수")]


    [Header("테스트 전용 변수")]
    [SerializeField] bool test_Turn_Over_signal = false;

    private void Awake()
    {
        plum = GameObject.FindGameObjectWithTag("Plum");
        Get_Turn_Over_Signal();
    }

    private void Update()
    {
        if (test_Turn_Over_signal)
        {
            test_Turn_Over_signal = false;
            Get_Turn_Over_Signal();
        }
    }

    public void Get_Turn_Over_Signal()
    {
        if (is_Turn_ready_To_end)
        {

            if (script_Schedule != null) Send_Status_Change_Data(0, Mathf.RoundToInt(script_Schedule.stat[4]), script_Schedule.stat[3], script_Schedule.stat[0], script_Schedule.stat[1], script_Schedule.stat[2]);
            Dark_Change_Obj.GetComponent<Dark_Is_Coming>().Get_Turn_Over_Signal();
            is_Turn_ready_To_end = false;
        }
        
    }

    public void Get_Turn_Start_Siganl()
    {
        GetComponent<Event_Controller>().Get_Turn_Over_Signal();
    }

    public void Variable_Initialize(ScheduleResult script_S)
    {
        if(script_S !=null) script_Schedule = script_S;
    }

    public void Get_Date_Change_Signal()
    {
        Stage_Num++;
        Year += (Month + 1) / 13;
        Month = ++Month % 13 + Month / 13;
        Date_Text.text = Year + "년 " + Month + "월";
    }

    public void Get_Event_End_Siganl()
    {
        is_Turn_ready_To_end = true;
        if(plum.GetComponent<Status>().member_Happiness == 0 || plum.GetComponent<Status>().Fund == 0)
        {
            SceneManager.LoadScene("nonhappyending");
            Debug.Log("Game Over Event");
        }
    }

    void Send_Status_Change_Data(int headCount, int Fund, float Reputation, float Happiness, float Learning_Point, float Participation)
    {
        plum.GetComponent<Status>().Get_Fund_InOut(Fund);
        plum.GetComponent<Status>().Get_Member_InOut(headCount);
        plum.GetComponent<Status>().Get_Reputateion_Change(Reputation);
        plum.GetComponent<Status>().Get_Member_Status_Change_By_Addition(Happiness, Participation, Learning_Point);
    }
}
