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
        MyStatus.UpdateMoney(money);
    }
    public void Study(int method)
    {
        switch (method)
        {
            case (int)Study_Method.unity:
                MyStatus.UpdateMemberStatus(-1f, 0f, 1f);
                break;
            case (int)Study_Method.c:
                MyStatus.UpdateMemberStatus(-2f, 0f, 2f);
                break;
        }
    }
    public void GoPCRoom()
    {
        MyStatus.UpdateMoney(-500);
        MyStatus.UpdateMemberStatus(5f, 2f, -3f);
    }
    public void Challenge()
    {
        GameObject.Find("ChallengeList").SetActive(true);

    }
}
