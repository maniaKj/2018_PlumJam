using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Budget : MonoBehaviour {

    private Text text;
    public void Start()
    {
        text = transform.Find("balance").GetComponent<Text>();
        Value_Change(GameObject.Find("Plum").GetComponent<Status>().Money);
    }
    public void Value_Change(int money) {

        Debug.Log(money);
        text.text = money.ToString();
    }
}
