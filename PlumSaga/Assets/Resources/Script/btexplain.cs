using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btexplain : MonoBehaviour {
    private GameObject text;
	// Use this for initialization
	void Start () {
        text = transform.Find("Text").gameObject;
        text.SetActive(false);
		
	}

   public void CreateText()
    {
        text.SetActive(true);
    }

    public void DestoryText()
    {
        text.SetActive(false);
    }
}
