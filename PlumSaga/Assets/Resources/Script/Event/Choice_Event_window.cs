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
            m_SuccessText.text = GetResultText(m_RewardOnSuccess);
            m_SuccessWindow.SetActive(true);

            result = m_RewardOnSuccess;
        }
        else
        {
            m_FailureText.text = GetResultText(m_LossOnFail);
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

    private string GetConditionText(Description desc)
    {
        return string.Format(
            @"인원 {0} 이상, \r\n
            자금 {1} 이상, \r\n
            명성도 {2} 이상, \r\n
            행복도 {3} 이상, \r\n
            학습도 {4} 이상, \r\n
            참여도 {5} 이상, ",
            desc.MemberCount.ToString(),
            desc.Money.ToString(),
            desc.Reputation.ToString(),
            desc.Happiness.ToString(),
            desc.Intelligence.ToString(),
            desc.Participation.ToString());
    }

    private string GetResultText(Description desc)
    {
        return string.Format(
            @"인원 {0}, \r\n
            자금 {1}, \r\n
            명성도 {2}, \r\n
            행복도 {3}, \r\n
            학습도 {4}, \r\n
            참여도 {5}, ",
            desc.MemberCount.ToString(),
            desc.Money.ToString(),
            desc.Reputation.ToString(),
            desc.Happiness.ToString(),
            desc.Intelligence.ToString(),
            desc.Participation.ToString());
    }
}
