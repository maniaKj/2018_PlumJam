using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Get_Stat_Enemy : MonoBehaviour {
    string[] name = { "EA", "Dabang", "WMV", "ITQ" };
    private Stat[] stats;
    private GameObject[] obj;
	// Use this for initialization
	void Start () {
        obj = new GameObject[4];
        stats = Status.Get_Data();
        Find_Object();
	}
    void Find_Object()
    {
        for(int i=0; i<4; i++)
        {
            obj[i] = transform.Find(name[i]).gameObject;
            obj[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/" + name[i]);
            GameObject happybar = obj[i].transform.Find("happybar").gameObject;
            GameObject joinbar = obj[i].transform.Find("joinbar").gameObject;
            GameObject studybar = obj[i].transform.Find("studybar").gameObject;
            GameObject honorbar = obj[i].transform.Find("honorbar").gameObject;
            happybar.GetComponent<Scrollbar>().value = stats[i + 1].Happiness / 100f;
            happybar.GetComponentInChildren<Text>().text = stats[i + 1].Happiness.ToString();
            joinbar.GetComponent<Scrollbar>().value = stats[i + 1].participation / 100f;
            joinbar.GetComponentInChildren<Text>().text = stats[i + 1].participation.ToString();
            studybar.GetComponent<Scrollbar>().value = stats[i + 1].learning_Point / 100f;
            studybar.GetComponentInChildren<Text>().text = stats[i + 1].learning_Point.ToString();
            honorbar.GetComponent<Scrollbar>().value = stats[i + 1].reputation / 100f;
            honorbar.GetComponentInChildren<Text>().text = stats[i + 1].reputation.ToString();
        } 
    }
}
