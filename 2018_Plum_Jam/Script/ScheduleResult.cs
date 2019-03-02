using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleResult : MonoBehaviour {
    public Text Happyre; //결과창에 표시할 내용
    public Text Studyre;
    public Text Partre;
    public Text Repure;
    public Text Budgetre;
    
   public float []stat= new float [5] { 0, 0, 0, 0, 0 }; //행복도,학습도,참가도,명성도
    public struct Schedule_selection
    {
        public string name;
        public float happych, studych,partch,repuch; //스탯 변화
        public bool ison; //활성화 되었는가
        public int budgetch; //자금

        public Schedule_selection(string name, float happych, float studych, float partch, float repuch, int budgetch, bool ison )
        {
            this.name = name;
            this.happych = happych;
            this.studych = studych;
            this.partch = partch;
            this.repuch = repuch;
            this.ison = ison;
            this.budgetch = budgetch;

        }
        public void getData (string Name, float Happych, float Studych, float Partch, float Repuch, int Budgetch, bool Ison)
        {
            name = Name;
            happych = Happych;
            studych = Studych;
            partch = Partch;
            repuch = Repuch;
            budgetch = Budgetch;
            ison = Ison;
        }
        
    }
    //List<Schedule_selection> all_Schedule_selection = new List<Schedule_selection>();
    //public Schedule_selection MtEvent;
    [HideInInspector]public Toggle[] toggles = new Toggle[5]; // 토글배열
    int actnum = 5; //활동 개수
    Schedule_selection[] schedules = new Schedule_selection[5];
    // Use this for initialization

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Stage_Controller>().Variable_Initialize(this);
    }

    void Start ()
    {//행복도,학습도,참가도,명성도,자금
        schedules[0].getData("Study_Check_Unity", -5f, 5f, 5f, 2f, 0, false ); //스케줄 내용
        schedules[1].getData("Study_Check_C++", -9f, 9f, 5f, 3f, 0, false);
        schedules[2].getData("Study_Check_Java", -6f, 6f, 2f, 1f, 0, false);
        schedules[3].getData("Act_Check_MT", 10f, -5f, 10f, 5f, -50000, false); 
        schedules[4].getData("Act_Check_Parttime", -3f, -3f, -5f, 0f, 27000, false);
        //schedules[5].getData("PccafeTo", 15f, -10f, 5f, -5f, -10000, false);
        for (int i = 0; i < actnum; i++)
            toggles[i] = GameObject.Find(schedules[i].name).GetComponent<Toggle>(); //토글 초기화

        Happyre.text = Mathf.Round(stat[0]).ToString();
        Studyre.text = Mathf.Round(stat[1]).ToString();
        Partre.text = Mathf.Round(stat[2]).ToString();
        Repure.text = Mathf.Round(stat[3]).ToString();
        Budgetre.text = Mathf.Round(stat[4]).ToString();
    }

    public void Sumup() //합산표시
    {
        for (int i = 0; i < actnum; i++)
        {
            if (schedules[i].ison == true)
            {
                stat[0] += schedules[i].happych;
                stat[1] += schedules[i].studych;
                stat[2] += schedules[i].partch;
                stat[3] += schedules[i].repuch;
                stat[4] += schedules[i].budgetch;
            }

        }
        Happyre.text = Mathf.Round(stat[0]).ToString();
        Studyre.text = Mathf.Round(stat[1]).ToString();
        Partre.text = Mathf.Round(stat[2]).ToString();
        Repure.text = Mathf.Round(stat[3]).ToString();
            

    }

    public void ToggleSynchro ()
    {
        //0으로 초기화
       for(int j = 0; j < 5; j++)
        {
            stat[j] = 0;
        }
       //토글값 동기화
        for(int i = 0; i < actnum; i++)
        {
            schedules[i].ison = toggles[i].isOn;
        }
        //합산표시
        Sumup();
    }

    
    
    
   
   
	
	
}
