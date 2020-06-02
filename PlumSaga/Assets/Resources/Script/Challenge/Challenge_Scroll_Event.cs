using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge_Scroll_Event : MonoBehaviour
{
    private float range;
    private Challenge_Scroll challenge_Scroll;
    private Stat[] gameInfo_stat;
    private Image image;
    private Text text;
    public GameObject ChallengeResult;
    private void Start()
    {
        range = transform.parent.Find("Gauge").localScale.x * 10f;
        image = ChallengeResult.transform.Find("Image").GetComponent<Image>();
        text = ChallengeResult.transform.Find("Text").GetComponent<Text>();
        gameInfo_stat = Status.Get_Data();
        challenge_Scroll = transform.parent.GetComponent<Challenge_Scroll>();
    }
    public void Select()
    {
        if (challenge_Scroll.speed > 0.01f)
        {
            challenge_Scroll.speed = 0f;
            GameObject.Find("Game_Fundamental_Obj").GetComponentInChildren<AudioSource>().Pause();
            ChallengeResult.SetActive(true);
            if (challenge_Scroll.slider.value > 50 - range && challenge_Scroll.slider.value <= 50 + range) // Win
            {

                ChallengeResult.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/Pass");
                ChallengeResult.GetComponent<AudioSource>().Play();
                image.sprite = Resources.Load<Sprite>("Image/pass");
                text.text = "도전에 성공하였습니다. 상대 동아리를 합병시킵니다.";
                for (int i = 1; i < 5; i++)
                {
                    if (transform.parent.Find("Text").GetComponent<Text>().text.Contains(gameInfo_stat[i].name))
                    {
                        gameInfo_stat[i].isEnabled = false;
                        float avg = (gameInfo_stat[i].learning_Point + gameInfo_stat[0].learning_Point) / 2 - gameInfo_stat[0].learning_Point;
                        GameObject.Find("Plum").GetComponent<Status>().UpdateMemberStatus(4f, -2f, avg);
                        break;
                    }
                }
            }
            else // Lose
            {
                ChallengeResult.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/Fail");
                ChallengeResult.GetComponent<AudioSource>().Play();
                image.sprite = Resources.Load<Sprite>("Image/fail");
                text.text = "도전에 실패하였습니다. 일부 스텟이 떨어집니다.";
                GameObject.Find("Plum").GetComponent<Status>().UpdateMemberStatus(-5f, -5f, -3f);
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
