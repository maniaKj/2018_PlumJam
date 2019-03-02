using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowCre : MonoBehaviour {
    public GameObject winUI;//배경 UI
    [HideInInspector] public GameObject mainUI;//부가 UI
   
	// Use this for initialization
	void Start () {
        //winUI.SetActive(false);
        mainUI = GameObject.FindWithTag("mainUI");

    }
	public void windowCreation()//부가창을 염
    {
        GameObject.Find("Game_Fundamental_Obj").GetComponentInChildren<AudioSource>().Pause();
        winUI.SetActive(true);
        mainUI.SetActive(false);
    }
    public void windowCreation_NoPauseSound()
    {
        winUI.SetActive(true);
        mainUI.SetActive(false);
    }
    public void windowCreation_Alarm()//부가창을 염
    {
        winUI.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
    public void windowDestory()//부가창을 닫음
    {
        GameObject.Find("Game_Fundamental_Obj").GetComponentInChildren<AudioSource>().Play();
        winUI.SetActive(false);
        mainUI.SetActive(true);
    }
    public void windowDestory_Alarm()//부가창을 닫음
    {
        GameObject Ui = GameObject.Find("Challenge_Window").gameObject;
        Ui.GetComponent<AudioSource>().Stop();
        GameObject.Find("Game_Fundamental_Obj").GetComponentInChildren<AudioSource>().Play();
        Ui.SetActive(false);
        winUI.SetActive(false);
        mainUI.SetActive(true);
    }
    public void windowDestroy_NoPauseSound()
    {
        GameObject.Find("Game_Fundamental_Obj").GetComponentInChildren<AudioSource>().Play();
        winUI.SetActive(false);
        mainUI.SetActive(true);
    }
}
