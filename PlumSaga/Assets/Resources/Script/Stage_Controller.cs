using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage_Controller : SingletonMonobehaviour<Stage_Controller> {
    [SerializeField]
    private int m_StageNum = 1;

    [SerializeField]
    private int m_Month = 1;
    public int Month
    {
        get
        {
            return m_Month;
        }
    }

    [SerializeField]
    private int m_Year = 2018;
    public int Year
    {
        get
        {
            return m_Year;
        }
    }

    public bool m_IsTurnOverReady = true;

    [SerializeField]
    private Text m_DateText;

    [SerializeField]
    private Dark_Is_Coming m_ScreenFader;

    [SerializeField]
    private Status m_PlumStatus;

    private void Awake()
    {
        OnTurnOver();
    }

    public void OnTurnOver()
    {
        if (m_IsTurnOverReady)
        {
            m_PlumStatus.UpdateMoney(SchedulePreview.Instance.Money);
            m_PlumStatus.UpdateMemberCount(SchedulePreview.Instance.MemberCount);
            m_PlumStatus.UpdateReputation(SchedulePreview.Instance.Reputation);
            m_PlumStatus.UpdateMemberStatus(
                SchedulePreview.Instance.Happiness,
                SchedulePreview.Instance.Participation,
                SchedulePreview.Instance.Intelligence);

            m_ScreenFader.OnTurnOver();
            m_IsTurnOverReady = false;
        }
    }

    public void OnTurnStart()
    {
        Event_Controller.Instance.OnTurnOver();
    }

    public void UpdateCalender()
    {
        m_StageNum++;

        m_Year += (m_Month + 1) / 13;
        m_Month = ++m_Month % 13 + m_Month / 13;

        m_DateText.text = string.Format("{0}년 {1}월", m_Year, m_Month);
    }

    public void OnEventEnd()
    {
        m_IsTurnOverReady = true;
        if(m_PlumStatus.Happiness == 0 || m_PlumStatus.Money == 0)
        {
            SceneManager.LoadScene("nonhappyending");
        }
    }
}
