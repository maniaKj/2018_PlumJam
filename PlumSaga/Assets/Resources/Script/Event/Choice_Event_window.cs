using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Choice_Event_window : MonoBehaviour {

    [Serializable]
    public class Description
    {
        public int MemberCount;
        public int Money;
        public float Reputation;
        public float Happiness;
        public float Participation;
        public float Intelligence;
    }

    [SerializeField]
    private Description m_ConditionToSuccess;

    [SerializeField]
    private Description m_RewardOnSuccess;

    [SerializeField]
    private Description m_LossOnFail;

    [SerializeField]
    private Status m_PlumStatus;

    [SerializeField]
    private Get_Stat_Player m_PlayerStat;

    [SerializeField]
    private GameObject m_ChoiceWindow;

    [SerializeField]
    private GameObject m_SuccessWindow;

    [SerializeField]
    private GameObject m_FailureWindow;

    [SerializeField]
    private GameObject m_RefusalWindow;

    [SerializeField]
    private Text m_Headline;

    [SerializeField]
    private Text m_MainText;

    [SerializeField]
    private Text m_ConditionText;

    [SerializeField]
    private Text m_SuccessText;

    [SerializeField]
    private Text m_FailureText;

    public void Start()
    {
        m_ChoiceWindow.SetActive(true);
        m_SuccessWindow.SetActive(false);
        m_RefusalWindow.SetActive(false);
        m_FailureWindow.SetActive(false);

        m_ConditionText.text = GetConditionText(m_ConditionToSuccess).ToString();
    }

    public void OnCheckButtonDown()
    {
        Event_Controller.Instance.OnEventEnd(gameObject);
        Destroy(gameObject);
    }

    public void OnAcceptButtonDown()
    {
        bool isSuccess = CheckCondition();

        Description result;

        if (isSuccess)
        {
            m_SuccessText.text = GetResultText(m_RewardOnSuccess).Insert(0, "성공!! : \r\n").ToString();
            m_SuccessWindow.SetActive(true);

            result = m_RewardOnSuccess;
        }
        else
        {
            m_FailureText.text = GetResultText(m_LossOnFail).Insert(0, "실패!! : \r\n").ToString();
            m_FailureWindow.SetActive(true);

            result = m_LossOnFail;
        }

        m_PlumStatus.UpdateMemberCount(result.MemberCount);
        m_PlumStatus.UpdateMemberStatus(result.Happiness, result.Participation, result.Intelligence);
        m_PlumStatus.UpdateMoney(result.Money);
        m_PlumStatus.UpdateReputation(result.Reputation);
        m_PlayerStat.OnChange();

        m_ChoiceWindow.SetActive(false);
    }

    public void OnRefusalButtonDown()
    {
        m_ChoiceWindow.SetActive(false);
        m_RefusalWindow.SetActive(true);
    }

    private bool CheckCondition()
    {
        return m_PlumStatus.MemberCount >= m_ConditionToSuccess.MemberCount &&
             m_PlumStatus.Money >= m_ConditionToSuccess.Money &&
              m_PlumStatus.Reputation >= m_ConditionToSuccess.Reputation &&
               m_PlumStatus.Happiness >= m_ConditionToSuccess.Happiness &&
                m_PlumStatus.Education >= m_ConditionToSuccess.Intelligence &&
                 m_PlumStatus.Participation >= m_ConditionToSuccess.Participation;
    }

    private StringBuilder GetConditionText(Description desc)
    {
        return new StringBuilder("성공조건 : \r\n").
        AppendFormat("인원 {0} 이상, ", desc.MemberCount).
        AppendFormat("자금 {0} 이상, ", desc.Money).
        AppendFormat("명성도 {0} 이상, ", desc.Reputation).
        AppendFormat("행복도 {0} 이상, ", desc.Happiness).
        AppendFormat("학습도 {0} 이상, ", desc.Intelligence).
        AppendFormat("참여도 {0} 이상, ", desc.Participation);
    }
    private StringBuilder GetResultText(Description desc)
    {
        return new StringBuilder().
        AppendFormat("인원 {0}, ", desc.MemberCount).
        AppendFormat("자금 {0}, ", desc.Money).
        AppendFormat("명성도 {0}, ", desc.Reputation).
        AppendFormat("행복도 {0}, ", desc.Happiness).
        AppendFormat("학습도 {0}, ", desc.Intelligence).
        AppendFormat("참여도 {0}, ", desc.Participation);
    }
}
