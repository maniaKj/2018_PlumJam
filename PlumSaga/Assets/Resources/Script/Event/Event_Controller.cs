using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Controller : SingletonMonobehaviour<Event_Controller> {

    [SerializeField]
    private Choice_Event_window[] m_RandomEvents;

    [SerializeField]
    private Choice_Event_window[] m_MonthlyEvent;

    [SerializeField]
    private Choice_Event_window[] m_ReferenceEvents;

    [SerializeField]
    private GameObject m_Canvas;

    private List<GameObject> m_Windows = new List<GameObject>();

    private GameObject AddEventWindow(Choice_Event_window target)
    {
        var obj = Instantiate(target.gameObject, m_Canvas.transform);
        obj.SetActive(false);

        m_Windows.Add(obj);
        return obj;
    }

    public void OnTurnOver()
    {
        var monthlyEvent = GetMonthlyEvent();
        if (monthlyEvent)
        {
            AddEventWindow(monthlyEvent);
        }

        int randomIndex = Util.GenerateRandomInt(m_RandomEvents.Length - 1);
        var firstEvent = AddEventWindow(m_RandomEvents[randomIndex]);

        firstEvent.SetActive(true);
    }

    public void OnEventEnd(GameObject target)
    {
        m_Windows.Remove(target);

        if (m_Windows.Count == 0)
        {
            Stage_Controller.Instance.OnEventEnd();
        }
        else
        {
            m_Windows[m_Windows.Count - 1].SetActive(true);
        }
    }
    
    private Choice_Event_window GetMonthlyEvent()
    {
        for (int i = 0; i < m_MonthlyEvent.Length; i++)
        {
            if (m_MonthlyEvent[i].GetComponent<Periodic_Event_Property>().Month == Stage_Controller.Instance.Month)
            {
                return m_MonthlyEvent[i];
            }
        }
        return null;
    }
}