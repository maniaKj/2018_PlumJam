using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Choice_Event_window : MonoBehaviour {
    [Header("이벤트 성공 조건")]
    [SerializeField] int member_HeadCount;
    [SerializeField] int Fund;
    [SerializeField] float Reputation, member_Happiness, member_Participation, member_Learning_Point;

    [Header("성공 보상")]
    [SerializeField] int s_member_HeadCount;
    [SerializeField] int s_Fund;
    [SerializeField] float s_Reputation, s_member_Happiness, s_member_Participation, s_member_Learning_Point;

    [Header("실패 손실")]
    [SerializeField] int f_member_HeadCount;
    [SerializeField] int f_Fund;
    [SerializeField] float f_Reputation, f_member_Happiness, f_member_Participation, f_member_Learning_Point;

    [Header("적용해야할 변수")]
    [SerializeField] GameObject plum;
    [SerializeField] Text headline_Text;
    [SerializeField] Text main_Text, sub_Text;
    [SerializeField] Text success_Sub_Text, fail_Sub_Text;
    [SerializeField] GameObject choice_Window, after_Success_Window, after_Fail_Window, after_Disaccept_Window;

    [Header("테스트 전용 변수")]
    [SerializeField] bool test_Check_Button = false;

    private void Awake()
    {
        Apply_SubText();

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
        choice_Window.SetActive(true);
        after_Success_Window.SetActive(false);
        after_Disaccept_Window.SetActive(false);
        after_Fail_Window.SetActive(false);
        //Set_Active_Child_Obj(true);
    }

    public void Get_Check_Button_Down()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Event_Controller>().Get_Event_End_Signal(this.gameObject);
        Destroy(this.gameObject);
        //Set_Active_Child_Obj(false);
    }

    public void Get_Accept_Button_Down()
    {
        if (Check_Condition_Satisfying())
        {
            after_Success_Window.SetActive(true);
            Apply_Result_To_Status(true);
        }
        else
        {
            after_Fail_Window.SetActive(true);
            Apply_Result_To_Status(false);
        }
        choice_Window.SetActive(false);
    }

    public void Get_DisAccept_Button_Down()
    {
        choice_Window.SetActive(false);
        after_Disaccept_Window.SetActive(true);
    }

    bool Check_Condition_Satisfying()
    {
        bool Is_Satisfying_Condition = true;
        if (plum.GetComponent<Status>().member_HeadCount < member_HeadCount)
        {
            Is_Satisfying_Condition = false;
        }
        if (plum.GetComponent<Status>().Fund < Fund)
        {
            Is_Satisfying_Condition = false;
        }
        if (plum.GetComponent<Status>().Reputation < Reputation)
        {
            Is_Satisfying_Condition = false;
        }
        if (plum.GetComponent<Status>().member_Happiness < member_Happiness)
        {
            Is_Satisfying_Condition = false;
        }
        if (plum.GetComponent<Status>().member_Learning_Point < member_Learning_Point)
        {
            Is_Satisfying_Condition = false;
        }
        if (plum.GetComponent<Status>().member_Participation < member_Participation)
        {
            Is_Satisfying_Condition = false;
        }

        if (Is_Satisfying_Condition) Debug.Log("From Choic_Event_Window 조건 만족함");
        else Debug.Log("From Choic_Event_Window 조건 불만족");
        return Is_Satisfying_Condition;
    }

    void Apply_SubText()
    {
        sub_Text.text = "성공조건 : \r\n";
        if (member_HeadCount > 0) sub_Text.text += "인원 " + member_HeadCount + "이상, ";
        if (Fund > 0) sub_Text.text += "자금 " + Fund + "이상, ";
        if (Reputation > 0) sub_Text.text += "명성도 " + Reputation + "이상, ";
        if (member_Happiness > 0) sub_Text.text += "행복도 " + member_Happiness + "이상, ";
        if (member_Learning_Point > 0) sub_Text.text += "학습도 " + member_Learning_Point + "이상, ";
        if (member_Participation > 0) sub_Text.text += "참여도 " + member_Participation + "이상, ";
        sub_Text.text = sub_Text.text.Substring(0, sub_Text.text.Length - 2);

        success_Sub_Text.text = "성공보상 : \r\n";
        if (s_member_HeadCount > 0) success_Sub_Text.text += "인원 + " + s_member_HeadCount + ", ";
        if (s_member_HeadCount < 0) success_Sub_Text.text += "인원 - " + Mathf.Abs(s_member_HeadCount) + ", ";
        if (s_Fund > 0) success_Sub_Text.text += "자금 + " + s_Fund + ", ";
        if (s_Fund < 0) success_Sub_Text.text += "자금 - " + Mathf.Abs(s_Fund) + ", ";
        if (s_Reputation > 0) success_Sub_Text.text += "명성도 + " + s_Reputation + ", ";
        if (s_Reputation < 0) success_Sub_Text.text += "명성도 - " + Mathf.Abs(s_Reputation) + ", ";
        if (s_member_Happiness > 0) success_Sub_Text.text += "행복도 + " + s_member_Happiness + ", ";
        if (s_member_Happiness < 0) success_Sub_Text.text += "행복도 - " + Mathf.Abs(s_member_Happiness) + ", ";
        if (s_member_Learning_Point > 0) success_Sub_Text.text += "학습도 + " + s_member_Learning_Point + ", ";
        if (s_member_Learning_Point < 0) success_Sub_Text.text += "학습도 - " + Mathf.Abs(s_member_Learning_Point) + ", ";
        if (s_member_Participation > 0) success_Sub_Text.text += "참여도 + " + s_member_Participation + ", ";
        if (s_member_Participation < 0) success_Sub_Text.text += "참여도 - " + Mathf.Abs(s_member_Participation) + ", ";
        success_Sub_Text.text = success_Sub_Text.text.Substring(0, success_Sub_Text.text.Length - 2);

        fail_Sub_Text.text = "실패 손실 : \r\n";
        if (f_member_HeadCount > 0) fail_Sub_Text.text += "인원 + " + f_member_HeadCount + ", ";
        if (f_member_HeadCount < 0) fail_Sub_Text.text += "인원 - " + Mathf.Abs(f_member_HeadCount) + ", ";
        if (f_Fund > 0) fail_Sub_Text.text += "자금 + " + f_Fund + ", ";
        if (f_Fund < 0) fail_Sub_Text.text += "자금 - " + Mathf.Abs(f_Fund) + ", ";
        if (f_Reputation > 0) fail_Sub_Text.text += "명성도 + " + f_Reputation + ", ";
        if (f_Reputation < 0) fail_Sub_Text.text += "명성도 - " + Mathf.Abs(f_Reputation) + ", ";
        if (f_member_Happiness > 0) fail_Sub_Text.text += "행복도 + " + f_member_Happiness + ", ";
        if (f_member_Happiness < 0) fail_Sub_Text.text += "행복도 - " + Mathf.Abs(f_member_Happiness) + ", ";
        if (f_member_Learning_Point > 0) fail_Sub_Text.text += "학습도 + " + f_member_Learning_Point + ", ";
        if (f_member_Learning_Point < 0) fail_Sub_Text.text += "학습도 - " + Mathf.Abs(f_member_Learning_Point) + ", ";
        if (f_member_Participation > 0) fail_Sub_Text.text += "참여도 + " + f_member_Participation + ", ";
        if (f_member_Participation < 0) fail_Sub_Text.text += "참여도 - " + Mathf.Abs(f_member_Participation) + ", ";
        fail_Sub_Text.text = fail_Sub_Text.text.Substring(0, fail_Sub_Text.text.Length - 2);
    }
    void Apply_Result_To_Status(bool Success_or_Fail)
    {
        if (Success_or_Fail)
        {
            plum.GetComponent<Status>().Get_Fund_InOut(s_Fund);
            plum.GetComponent<Status>().Get_Member_InOut(s_member_HeadCount);
            plum.GetComponent<Status>().Get_Reputateion_Change(s_Reputation);
            plum.GetComponent<Status>().Get_Member_Status_Change_By_Addition(s_member_Happiness, s_member_Participation, s_member_Learning_Point);

        }
        else
        {
            plum.GetComponent<Status>().Get_Fund_InOut(f_Fund);
            plum.GetComponent<Status>().Get_Member_InOut(f_member_HeadCount);
            plum.GetComponent<Status>().Get_Reputateion_Change(f_Reputation);
            plum.GetComponent<Status>().Get_Member_Status_Change_By_Addition(f_member_Happiness, f_member_Participation, f_member_Learning_Point);
        }
        GameObject.Find("Plum_Status").GetComponent<Get_Stat_Player>().Value_change();
    }

    //private
    void Set_Active_Child_Obj(bool onOff)
    {
        for (int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.SetActive(onOff);
    }
}
