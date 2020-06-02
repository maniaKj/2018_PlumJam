using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge_Button_Event : MonoBehaviour {

    public void check()
    {
        if (GameObject.Find("Plum").GetComponent<Status>().isChallenge)
            GetComponent<WindowCre>().windowCreation();
    }
    public void change()
    {
        GameObject.Find("Plum").GetComponent<Status>().isChallenge = false;
    }
}
