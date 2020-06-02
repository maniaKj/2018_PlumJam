using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dark_Is_Coming : MonoBehaviour {

    [Header("조정해야할 변수")]
    [SerializeField] float Alpha_Change_Speed = 0.02f;

    //hide
    RawImage Black_Rawimage;

    private void Awake()
    {
        Black_Rawimage = GetComponent<RawImage>();
        Black_Rawimage.color = new Color(0, 0, 0, 0);
        //Black_Rawimage.enabled = false;
    }
    public void OnTurnOver()
    {
        Black_Rawimage = GetComponent<RawImage>();  
        Black_Rawimage.enabled = true;
        StartCoroutine(The_Dark_Is_Coming());
        GameObject.Find("Plum_Status").GetComponent<Get_Stat_Player>().OnChange();
    }

    IEnumerator The_Dark_Is_Coming()
    {
        float Image_Alpha_Value = 0.00f;
        while(Image_Alpha_Value < 0.95f)
        {
            Image_Alpha_Value += Alpha_Change_Speed;
            Black_Rawimage.color = new Color(0, 0, 0, Image_Alpha_Value);
            yield return new WaitForSeconds(0.03f);
        }
        GameObject.FindGameObjectWithTag("GameController").SendMessage("Get_Date_Change_Signal");
        while (Image_Alpha_Value > 0.00f)
        {
            Image_Alpha_Value -= Alpha_Change_Speed;
            Black_Rawimage.color = new Color(0, 0, 0, Image_Alpha_Value);
            yield return new WaitForSeconds(0.03f);
        }
        Black_Rawimage.enabled = false;
        GameObject.FindGameObjectWithTag("GameController").SendMessage("Get_Turn_Start_Siganl");
    }
}
