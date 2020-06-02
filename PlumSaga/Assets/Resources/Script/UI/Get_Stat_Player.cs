using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Get_Stat_Player : MonoBehaviour {
    private Stat[] stats;

	// Use this for initialization
	void Start () {
        stats = Status.Get_Data();
        OnChange();
    }
    public void OnChange()
    {
        try
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/plum_Logo");
            transform.Find("happybar").GetComponent<Scrollbar>().value = stats[0].Happiness / 100f;
            transform.Find("happybar").GetComponentInChildren<Text>().text = stats[0].Happiness.ToString();
            transform.Find("joinbar").GetComponent<Scrollbar>().value = stats[0].participation / 100f;
            transform.Find("joinbar").GetComponentInChildren<Text>().text = stats[0].participation.ToString();
            transform.Find("studybar").GetComponent<Scrollbar>().value = stats[0].learning_Point / 100f;
            transform.Find("studybar").GetComponentInChildren<Text>().text = stats[0].learning_Point.ToString();
            transform.Find("honorbar").GetComponent<Scrollbar>().value = stats[0].reputation / 100f;
            transform.Find("honorbar").GetComponentInChildren<Text>().text = stats[0].reputation.ToString();
        }
        catch(System.NullReferenceException e)
        {
            transform.Find("happybar").GetComponent<Scrollbar>().value = 0f;
            transform.Find("happybar").GetComponentInChildren<Text>().text = "0";
            transform.Find("joinbar").GetComponent<Scrollbar>().value = 0;
            transform.Find("joinbar").GetComponentInChildren<Text>().text = "0";
            transform.Find("studybar").GetComponent<Scrollbar>().value = 0;
            transform.Find("studybar").GetComponentInChildren<Text>().text = "0";
            transform.Find("honorbar").GetComponent<Scrollbar>().value = 0;
            transform.Find("honorbar").GetComponentInChildren<Text>().text = "0";

        }
    }
}
