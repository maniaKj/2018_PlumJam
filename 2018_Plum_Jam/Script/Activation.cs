using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour {
    [ExecuteInEditMode]
    private Status MyStatus; // Status 정보를 받아옴
    [SerializeField] enum Study_Method { unity = 0, c };

    private void Start()
    {
        MyStatus = gameObject.GetComponent<Status>();
    }
    public void PartJob(int money)
    {
        MyStatus.Get_Fund_InOut(money);
    }
    public void Study(int method)
    {
        switch (method)
        {
            case (int)Study_Method.unity:
                MyStatus.Get_Member_Status_Change_By_Addition(-1f, 0f, 1f);
                break;
            case (int)Study_Method.c:
                MyStatus.Get_Member_Status_Change_By_Addition(-2f, 0f, 2f);
                break;
        }
    }
    public void GoPCRoom()
    {
        MyStatus.Get_Fund_InOut(-500);
        MyStatus.Get_Member_Status_Change_By_Addition(5f, 2f, -3f);
    }
    public void Challenge()
    {
        GameObject.Find("ChallengeList").SetActive(true);

    }
}
