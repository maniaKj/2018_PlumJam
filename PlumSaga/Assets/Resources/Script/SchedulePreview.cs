using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchedulePreview : SingletonMonobehaviour<SchedulePreview> {

    [SerializeField]
    private Text m_HappinessText;

    [SerializeField]
    private Text m_IntelligenceText;

    [SerializeField]
    private Text m_ParticipationText;

    [SerializeField]
    private Text m_ReputationText;

    [SerializeField]
    private Text m_MoneyText;
    
    [SerializeField]
    private int m_MemberCount;
    public int MemberCount
    {
        get
        {
            return m_MemberCount;
        }
    }

    [SerializeField]
    private int m_Money;
    public int Money
    {
        get
        {
            return m_Money;
        }
    }

    [SerializeField]
    private float m_Reputation;
    public float Reputation
    {
        get
        {
            return m_Reputation;
        }
    }

    [SerializeField]
    private float m_Happiness;
    public float Happiness
    {
        get
        {
            return m_Happiness;
        }
    }

    [SerializeField]
    private float m_Intelligence;
    public float Intelligence
    {
        get
        {
            return m_Intelligence;
        }
    }

    [SerializeField]
    private float m_Participation;
    public float Participation
    {
        get
        {
            return m_Participation;
        }
    }

    [SerializeField]
    private Toggle[] m_Toggles;

    public enum ScheduleCategory 
    {
        UnityStudy = 0,
        CppStudy,
        JavaStudy,
        MT,
        PartTimeJob,
        Max
    }

    public class Schedule_selection
    {
        public string Name;
        public int Money; 
        public float Happiness;
        public float Education;
        public float Participation;
        public float Reputation;

        public void SetField (string name, float happiness, float education, float participation, float reputation, int money)
        {
            Name = name;
            Happiness = happiness;
            Education = education;
            Participation = participation;
            Reputation = reputation;
            Money = money;
        }
    }

    private Schedule_selection[] m_Schedules = new Schedule_selection[(int)ScheduleCategory.Max];

    private void Start () {
        m_Schedules[(int)ScheduleCategory.UnityStudy].SetField("Study_Check_Unity", -5f, 5f, 5f, 2f, 0);
        m_Schedules[(int)ScheduleCategory.CppStudy].SetField("Study_Check_C++", -9f, 9f, 5f, 3f, 0);
        m_Schedules[(int)ScheduleCategory.JavaStudy].SetField("Study_Check_Java", -6f, 6f, 2f, 1f, 0);
        m_Schedules[(int)ScheduleCategory.MT].SetField("Act_Check_MT", 10f, -5f, 10f, 5f, -50000); 
        m_Schedules[(int)ScheduleCategory.PartTimeJob].SetField("Act_Check_Parttime", -3f, -3f, -5f, 0f, 27000);

        UpdateText();
    }

    private void UpdateText()
    {
        m_HappinessText.text = m_Happiness.ToString();
        m_IntelligenceText.text = m_Intelligence.ToString();
        m_ParticipationText.text = m_Participation.ToString();
        m_ReputationText.text = m_Reputation.ToString();
        m_MoneyText.text = m_Money.ToString();
    }

    public void SyncToggle()
    {
        m_Happiness = 0;
        m_Intelligence = 0;
        m_Participation = 0;
        m_Reputation = 0;
        m_Money = 0;

        for(int i = 0; i < (int)ScheduleCategory.Max; i++)
        {
            if (m_Toggles[i].isOn)
            {
                m_Happiness += m_Schedules[i].Happiness;
                m_Intelligence += m_Schedules[i].Education;
                m_Participation += m_Schedules[i].Participation;
                m_Reputation += m_Schedules[i].Reputation;
                m_Money += m_Schedules[i].Money;
            }
        }
        UpdateText();
    }
}
