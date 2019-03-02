using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Choice_Event_Data_Property
{
    //이벤트 이름&설명&번호
    public string event_Name, event_Explain_text;
    public int event_Num;

    //이벤트 성공 조건
    public int c_club_Fund, c_club_Member_num;
    public float c_club_Reputation, c_member_Happiness, c_member_Learning_Point, c_member_Participation;

    //성공시 적용될 스테이터스 변동값
    public int s_club_Fund, s_club_Member_num;
    public float s_club_Reputation, s_member_Happiness, s_member_Learning_Point, s_member_Participation;
    //실패시 적용될 스테이터스 변동값
    public int f_club_Fund, f_club_Member_num;
    public float f_club_Reputation, f_member_Happiness, f_member_Learning_Point, f_member_Participation;

    public void Get_Data_Basic_EventInfo(string name, int event_Number, string explain)
    {
        event_Name = name;
        event_Num = event_Number;
        event_Explain_text = explain;
    }

    public void Get_Data_Success_Condition(int club_Fund, int club_Member_num, float club_Reputation, float member_Happiness, float member_Learning_Point, float member_Participation)
    {
        c_club_Fund = club_Fund;
        c_club_Member_num = club_Member_num;
        c_club_Reputation = club_Reputation;
        c_member_Happiness = member_Happiness;
        c_member_Learning_Point = member_Learning_Point;
        c_member_Participation = member_Participation;
    }

    public void Get_Data_Status_Change_OnSuccess(int club_Fund, int club_Member_num, float club_Reputation, float member_Happiness, float member_Learning_Point, float member_Participation)
    {
        s_club_Fund = club_Fund;
        s_club_Member_num = club_Member_num;
        s_club_Reputation = club_Reputation;
        s_member_Happiness = member_Happiness;
        s_member_Learning_Point = member_Learning_Point;
        s_member_Participation = member_Participation;
    }

    public void Get_Data_Status_Change_OnFail(int club_Fund, int club_Member_num, float club_Reputation, float member_Happiness, float member_Learning_Point, float member_Participation)
    {
        f_club_Fund = club_Fund;
        f_club_Member_num = club_Member_num;
        f_club_Reputation = club_Reputation;
        f_member_Happiness = member_Happiness;
        f_member_Learning_Point = member_Learning_Point;
        f_member_Participation = member_Participation;
    }
}

public class Event : MonoBehaviour {
    [ExecuteInEditMode]

    enum Club_Event_List {Club_Merge, Club_Closing, Get_Other_Club, Get_Chanllenge, Nitpicking_From_Dep_Office}
    List<Club_Event_List> All_Event_List;
    List<Club_Event_List> Event_Will_Applying;

    /*[Header("확인해야할 변수")]
    [SerializeField] int final_member_Change_Value;
    [SerializeField] int final_fund_Change_Value;
    [SerializeField] float final_club_Reputation_Change_Value, final_M_member_Happiness_Value, final_M_member_Participation_Value, final_M_Leanr_Value;*/

    [Header("적용해야할 변수")]
    [SerializeField] GameObject plum;
    [SerializeField] GameObject Event_Window, Choice_Event_Window;
    

    [Header("테스트용 변수")]
    [SerializeField] bool Initialize_Test = false;

    //이벤트 구조체
    public struct Simple_Event_Data_Property
    {
        //이벤트 이름 & 설명문
        public string event_Name, event_Explain_text;

        //이벤트 발생시 스테이터스 변동값
        public int event_Num ,club_Fund, club_Member_num;
        public float club_Reputation, member_Happiness, member_Learning_Point, member_Participation;

        public Simple_Event_Data_Property(string event_Name, string event_Explain_text, int event_Num, int club_Fund, int club_Member_num, float club_Reputation, float member_Happiness, float member_Learning_Point, float member_Participation)
        {
            this.event_Name = event_Name;
            this.event_Explain_text = event_Explain_text;
            this.event_Num = event_Num;
            this.club_Fund = club_Fund;
            this.club_Member_num = club_Member_num;
            this.club_Reputation = club_Reputation;
            this.member_Happiness = member_Happiness;
            this.member_Learning_Point = member_Learning_Point;
            this.member_Participation = member_Participation;
        }
        
        public void Get_Data (string name, int event_Number, int Fund, int Member_num, float Reputation, float Happiness, float Learning_Point, float Participation)
        {
            event_Name = name;
            event_Num = event_Number;
            club_Fund = Fund;
            club_Member_num = Member_num;
            club_Reputation = Reputation;
            member_Happiness = Happiness;
            member_Learning_Point = Learning_Point;
            member_Participation = Participation;
        }

        public void Get_Explain_Text(string Long_Text)
        {
            event_Explain_text = Long_Text;
        }
    }

    List<Simple_Event_Data_Property> all_Event_Property = new List<Simple_Event_Data_Property>();
    List<Choice_Event_Data_Property> all_Choice_Event_Property = new List<Choice_Event_Data_Property>();

    //private
    public Simple_Event_Data_Property Club_Merge, Club_Closing, Get_Other_Club, Nitpicking_From_Dep_Office,
        Black_Out, WorkShop, Exam_Period;
    public Choice_Event_Data_Property Choice_Event1, Choice_Event2;

    //[Header("조정해야할 변수")]
    //[SerializeField]

    //초기화
    private void Awake()
    {
        //이름, 이벤트 색인 넘버, 자금, 인원, 평판, 행복도, 학습도, 참여도
        Club_Merge.Get_Data("동아리 병합", 0, 0, 0, 1, 0, 1, 1);
        Club_Closing.Get_Data("동아리 폐쇄", 1, 0, 0, -1, 0, 0, 0);
        Get_Other_Club.Get_Data("타 동아리 흡수", 2, 0, 1, 0, 0, 1, 1);
        Nitpicking_From_Dep_Office.Get_Data("과사의 잔소리", 3, 0, 0, 0, -1, 0, 0);
        Black_Out.Get_Data("미래관 정전", 4, 0, 0, 0, -1, -1, 0);
        WorkShop.Get_Data("동아리 워크샵", 5, 1, 0, 1, 0, 0, 0);
        Exam_Period.Get_Data("시험기간", 6, 0, 0, 1, -1, 1, 1);

        Apply_Explain_text_To_event();
        Apply_Choice_Event_Property();

        all_Event_Property.Add(Club_Merge);
        all_Event_Property.Add(Club_Closing);
        all_Event_Property.Add(Get_Other_Club);
        all_Event_Property.Add(Nitpicking_From_Dep_Office);
        all_Event_Property.Add(Black_Out);
        all_Event_Property.Add(WorkShop);
        all_Event_Property.Add(Exam_Period);
    }

    private void Update()
    {
        if (Initialize_Test)
        {
            Initialize_Test = false;
            Get_Turn_Over_Signal();
        }
    }

    //public
    public void Get_Turn_Over_Signal()
    {

        int Randomly_Created_Value = Random_Event_Value_Create();
        if (Randomly_Created_Value <= 100)
        {
            Simple_Event_Data_Property Randomly_Created_Simple_Event = all_Event_Property[Randomly_Created_Value];
            Send_Event_Signal(plum, Randomly_Created_Simple_Event);
            //Event_Window.GetComponent<Event_Window>().Get_Turn_Over_Signal(Randomly_Created_Simple_Event);
        }
        else if (Randomly_Created_Value > 100 && Randomly_Created_Value <= 200)
        {
            Choice_Event_Data_Property Randomly_Created_Choice_Event = all_Choice_Event_Property[Randomly_Created_Value];
            //Choice_Event_Window.GetComponent<Choice_Event_window>().Get_Turn_Over_Signal(Randomly_Created_Choice_Event);
        }
    }

    //private
    private int Random_Event_Value_Create()
    {
        int Random_Value_Event;
        int Random_value_select_Simple_or_Choice = Mathf.RoundToInt(Random.Range(0.0f, 1.0f)); // 0이면 기본 이벤트 발생, 1이면 선택지 이벤트 발생

        if(Random_value_select_Simple_or_Choice == 0)
        {
            Random_Value_Event = Mathf.RoundToInt(Random.Range(0.0f, 6.0f));
            Debug.Log("From Event 이벤트 실행 : " + all_Event_Property[Random_Value_Event].event_Name);
        }
        else
        {
            Random_Value_Event = Mathf.RoundToInt(Random.Range(100.0f, 101.0f));
            Debug.Log("From Event 이벤트 실행 : " + all_Choice_Event_Property[Random_Value_Event].event_Name);
        }
        
        return Random_Value_Event;
    }

    void Apply_Explain_text_To_event()
    {
        Club_Merge.Get_Explain_Text("동아리가 합쳐졌다!");
        Club_Closing.Get_Explain_Text("동아리가 폐쇄되었다 ㅠㅠ");
        Get_Other_Club.Get_Explain_Text("다른 동아리가 우리에게 합쳐졌다");
        Nitpicking_From_Dep_Office.Get_Explain_Text("과사에서 청소하라고 잔소리한다");
        Black_Out.Get_Explain_Text("미래관이 정전되어서 실습실 컴퓨터를 사용할 수가 없다");
        WorkShop.Get_Explain_Text("컴퓨터공학과 동아리 워크숍을 진행했다");
        Exam_Period.Get_Explain_Text("시험기간이 찾아왔다");
    }
    void Apply_Choice_Event_Property()
    {
        //선택지 이벤트는 이벤트 번호 101번부터 시작
        //자금, 인원수, 명성도, 행복도, 학습도, 참여도
        Choice_Event1.Get_Data_Basic_EventInfo("선택지 이벤트 1", 101, "선택지 이벤트 테스트 번호 1번 입니다. 자금 10000원 이상, 동아리 인원 수 10명이상이면 성공합니다. 성공시 자금 5000원과 명성 10을 얻으며, 실패시 명성이 10이 감소됩니다.");
        Choice_Event1.Get_Data_Success_Condition(10000, 10, 0, 0, 0, 0);
        Choice_Event1.Get_Data_Status_Change_OnSuccess(5000, 0, 10, 0, 0, 0);
        Choice_Event1.Get_Data_Status_Change_OnFail(0, 0, -10, 0, 0, 0);

        Choice_Event2.Get_Data_Basic_EventInfo("선택지 이벤트 2", 102, "선택지 이벤트 테스트 번호 2번 입니다. 참여도 40 이상, 학습도 60 이상이면 성공합니다. 성공시 행복도 10과 명성 10을 얻으며, 실패시 행복도 20이 감소됩니다.");
        Choice_Event2.Get_Data_Success_Condition(0, 0, 0, 0, 60, 40);
        Choice_Event2.Get_Data_Status_Change_OnSuccess(0, 0, 10, 10, 0, 0);
        Choice_Event2.Get_Data_Status_Change_OnFail(0, 0, 0, -20, 0, 0);

        all_Choice_Event_Property.Add(Choice_Event1);
        all_Choice_Event_Property.Add(Choice_Event2);
    }

    private void Send_Event_Signal(GameObject target, Simple_Event_Data_Property changing_Value_Struct)
    {
        target.GetComponent<Status>().Get_Fund_InOut(changing_Value_Struct.club_Fund);
        target.GetComponent<Status>().Get_Member_InOut(changing_Value_Struct.club_Member_num);
        target.GetComponent<Status>().Get_Reputateion_Change(changing_Value_Struct.club_Reputation);
        target.GetComponent<Status>().Get_Member_Status_Change_By_Addition(changing_Value_Struct.member_Happiness, changing_Value_Struct.member_Participation, changing_Value_Struct.member_Learning_Point);
    }
}
