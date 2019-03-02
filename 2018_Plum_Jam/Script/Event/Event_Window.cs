using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Event_Window : MonoBehaviour {
    [Header("이벤트 스테이터스 변화")]
    [SerializeField] public int member_HeadCount;
    [SerializeField] public int Fund;
    [SerializeField] public float Reputation, member_Happiness, member_Participation, member_Learning_Point;

    [Header("적용해야할 변수")]
    [SerializeField] GameObject plum;
    [SerializeField] GameObject game_Manager;
    [SerializeField] Text sub_Text;

    [Header("테스트 전용 변수")]
    [SerializeField] bool test_Check_Button = false;

    private void Awake()
    {
        Apply_SubText();
        game_Manager = GameObject.FindGameObjectWithTag("GameController");
    }
    private void Update()
    {
        if (test_Check_Button)
        {
            test_Check_Button = false;
            Apply_SubText();
        }
    }

    //public
    public void Get_Turn_Over_Signal()
    {
        plum = GameObject.FindGameObjectWithTag("Plum");
        Apply_SubText();
        Apply_Result_To_Status();
    }

    public void Get_Check_Button_Down()
    {
        game_Manager.GetComponent<Event_Controller>().Get_Event_End_Signal(this.gameObject);
        Destroy(this.gameObject);
        //Set_Active_Child_Obj(false);
    }

    void Apply_SubText()
    {
        sub_Text.text = "";
        if (member_HeadCount > 0) sub_Text.text += "인원 + " + member_HeadCount + ", ";
        else if (member_HeadCount < 0) sub_Text.text += "인원 - " + Mathf.Abs(member_HeadCount) + ", ";
        if (Fund > 0) sub_Text.text += "자금 + " + Fund + ", ";
        else if (Fund < 0) sub_Text.text += "자금 - " + Mathf.Abs(Fund) + ", ";
        if (Reputation > 0) sub_Text.text += "명성도 + " + Reputation + ", ";
        else if (Reputation < 0) sub_Text.text += "명성도 - " + Mathf.Abs(Reputation) + ", ";
        if (member_Happiness > 0) sub_Text.text += "행복도 + " + member_Happiness + ", ";
        else if (member_Happiness < 0) sub_Text.text += "행복도 - " + Mathf.Abs(member_Happiness) + ", ";
        if (member_Learning_Point > 0) sub_Text.text += "학습도 + " + member_Learning_Point + ", ";
        else if (member_Learning_Point < 0) sub_Text.text += "학습도 - " + Mathf.Abs(member_Learning_Point) + ", ";
        if (member_Participation > 0) sub_Text.text += "참여도 + " + member_Participation + ", ";
        else if (member_Participation < 0) sub_Text.text += "참여도 - " + Mathf.Abs(member_Participation) + ", ";
        sub_Text.text = sub_Text.text.Substring(0, sub_Text.text.Length - 2);
    }
    void Apply_Result_To_Status()
    {
        plum.GetComponent<Status>().Get_Fund_InOut(Fund);
        plum.GetComponent<Status>().Get_Member_InOut(member_HeadCount);
        plum.GetComponent<Status>().Get_Reputateion_Change(Reputation);
        plum.GetComponent<Status>().Get_Member_Status_Change_By_Addition(member_Happiness, member_Participation, member_Learning_Point);
        GameObject.Find("Plum_Status").GetComponent<Get_Stat_Player>().Value_change();
    }
}
