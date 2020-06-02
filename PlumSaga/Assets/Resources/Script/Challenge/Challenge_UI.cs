using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge_UI : MonoBehaviour
{
    private Stat[] gameInfo_stat;
    private Image[] status_Image;
    public float divide = 2f; // 확률 계산용

    // Use this for initialization
    void Start()
    {
        gameInfo_stat = Status.Get_Data();
        init();
        UIupdate();
    }
    void init()
    {
        status_Image = new Image[4];
        status_Image[0] = transform.Find("FirstButton").Find("Image").GetComponent<Image>();
        status_Image[1] = transform.Find("SecondButton").Find("Image").GetComponent<Image>();
        status_Image[2] = transform.Find("ThirdButton").Find("Image").GetComponent<Image>();
        status_Image[3] = transform.Find("FourthButton").Find("Image").GetComponent<Image>();
    }
    void UIupdate()
    {
        float playerScore = gameInfo_stat[0].learning_Point * gameInfo_stat[0].participation / 100;
        for (int i = 1; i < 5; i++)
        {
            if (gameInfo_stat[i].isEnabled)
            {
                float enemyScore = gameInfo_stat[i].learning_Point * gameInfo_stat[i].participation / 100;
                float score = playerScore - enemyScore / divide;
                int sum = 0;
                for (int j = (int)score; j >= 1; j--)
                    sum += j;
                score = sum / (playerScore / divide * enemyScore / divide) * 100;
                if (score >= 50f)
                    status_Image[i-1].color = Color.green;
                else if (score >= 20f)
                    status_Image[i-1].color = Color.yellow;
                else
                    status_Image[i-1].color = Color.red;

            }
            else
                status_Image[i-1].color = Color.black;
        }
    }

}
