using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge_Event : MonoBehaviour {

    public GameObject Player;
    private float divide = 2f; // 확률 계산용 
    private Stat[] gameInfo_stat;
    private float playerScore; // 플럼 점수
    private float enemyScore; // 적 동아리 점수
    private float avg;
    private Image image;
    private Text text;
    public GameObject ChallengeResult;
    public GameObject ChallengeScroll;
    // Use this for initialization
    void Start()
    {
        divide = transform.parent.GetComponent<Challenge_UI>().divide;
        gameInfo_stat = Status.Get_Data();
    }
    public void Challenge(int number)
    {
        ChallengeScroll.transform.Find("Text").GetComponent<Text>().text = "상대 동아리 : " + gameInfo_stat[number].name;
        image = ChallengeResult.transform.Find("Image").GetComponent<Image>();
        text = ChallengeResult.transform.Find("Text").GetComponent<Text>();
        if (gameInfo_stat[number].isEnabled)
        {
            ChallengeScroll.SetActive(true);
            playerScore = gameInfo_stat[0].learning_Point * gameInfo_stat[0].participation / 100;
            enemyScore = gameInfo_stat[number].learning_Point * gameInfo_stat[number].participation / 100; 
            if (playerScore > enemyScore) 
            {
                ChallengeScroll.transform.Find("Gauge").localScale = new Vector3(1f, 1f, 1f);
                ChallengeScroll.GetComponent<Challenge_Scroll>().speed = 20f;
 
            }
            else
            {
                ChallengeScroll.transform.Find("Gauge").localScale = new Vector3(Mathf.Clamp(1f-((enemyScore-playerScore)*2f)/100f,0.01f,1f), 1f, 1f);
                ChallengeScroll.GetComponent<Challenge_Scroll>().speed = 20 + (enemyScore - playerScore)*7f;
            }
        }
        else
        {
            ChallengeResult.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/Error");
            ChallengeResult.GetComponent<AudioSource>().Play();
            ChallengeResult.SetActive(true);
            image.sprite = Resources.Load<Sprite>("Image/Triangle_Error");
            text.text = "이미 없어진 동아리입니다.";
        }
        transform.parent.gameObject.SetActive(false);
    }

}
