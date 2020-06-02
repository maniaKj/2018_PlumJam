using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeResult_Event : MonoBehaviour {

    public GameObject ChallengeList;
    public void Back()
    {
        ChallengeList.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
