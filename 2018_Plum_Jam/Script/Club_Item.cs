using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Club_Item : MonoBehaviour {
    
    enum Helpful_Club_Item {Advertise_Pannel, Playing_Card, Sanquaehan, Coupang, Earplug, Senior }

    [Header("조정해야 할 변수")]
    [SerializeField] Helpful_Club_Item Item_Type;
    [SerializeField] string Item_Name;
    [SerializeField] float HeadCount_Increase_Rate = 0.00f, Fund_Increase_Rate = 0.00f, Reputation_Increase_Rate = 0.00f, member_Happiness_Increase_Rate = 0.00f, member_Participation_Increase_Rate = 0.00f, member_Learning_Point_Increase_Rate = 0.00f;
    [SerializeField] bool Data_Initialize_By_Script = false;

    [Space(30)]

    [Header("적용해야 할 변수")]
    [SerializeField] GameObject plum;
    [SerializeField] Text name_Text;
    [SerializeField] Text effect_Text;

    [Header("테스트 시스템")]
    [SerializeField] bool Test_Apply_Item_Effect = false;

    private void Awake()
    {
        plum = GameObject.FindGameObjectWithTag("Plum");
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == "Item_name") name_Text = transform.GetChild(i).GetComponent<Text>();
            if (transform.GetChild(i).name == "Item_effect_text") effect_Text = transform.GetChild(i).GetComponent<Text>();
        }
        if (name_Text == null) Debug.Log("From Club_Item 이름 텍스트 못찾음"); if (effect_Text == null) Debug.Log("From Club_Item 효과 텍스트 못찾음");
        Item_Data_Initialize_By_Script();
        Apply_Text_About_ItemEffect();
    }

    private void Update()
    {
        if (Data_Initialize_By_Script)
        {
            Data_Initialize_By_Script = false;
            Item_Data_Initialize_By_Script();
        }
        if (Test_Apply_Item_Effect)
        {
            Test_Apply_Item_Effect = false;
            Apply_Item_Effect(plum);
        }
        
    }

    void Item_Data_Initialize_By_Script()
    {
        switch (Item_Type)
        {
            case Helpful_Club_Item.Advertise_Pannel:
                Item_Name = "Plum 광고 판넬";
                HeadCount_Increase_Rate = 0.10f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Playing_Card:
                Item_Name = "어딘가 구겨진 트럼프 카드";
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.10f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Sanquaehan:
                Item_Name = "상쾌한";
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.10f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Coupang:
                Item_Name = "쿠팡맨";
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.10f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Earplug:
                Item_Name = "귀마개";
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.10f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;
            case Helpful_Club_Item.Senior:
                Item_Name = "잘나가는 선배";
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.30f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.10f;
                member_Learning_Point_Increase_Rate = 0.30f;
                break;
        }
        Apply_Text_About_ItemEffect();
    }

    public void Apply_Item_Effect(GameObject target)
    {
        target.GetComponent<Status>().Get_Increase_Rate_Change(HeadCount_Increase_Rate, Fund_Increase_Rate, Reputation_Increase_Rate, member_Happiness_Increase_Rate, member_Participation_Increase_Rate, member_Learning_Point_Increase_Rate);
            //float headerCount_Rate, float fund_Rate, float Reputatioin_Rate, float Happiness_Rate, float Participation_Rate, float Learning_Point_Rate)
    }

    void Apply_Text_About_ItemEffect()
    {
        name_Text.text = Item_Name;
        effect_Text.text = "아이템 효과 : \r\n";
        if (HeadCount_Increase_Rate != 0) effect_Text.text += "인원수 증가율 : " + HeadCount_Increase_Rate * 100f + "%\r\n";
        if (Fund_Increase_Rate != 0) effect_Text.text += "자금 증가율 : " + Fund_Increase_Rate * 100f + "%\r\n";
        if (Reputation_Increase_Rate != 0) effect_Text.text += "명성도 증가율 : " + Reputation_Increase_Rate * 100f + "%\r\n";
        if (member_Happiness_Increase_Rate != 0) effect_Text.text += "행복도 증가율 : " + member_Happiness_Increase_Rate * 100f + "%\r\n";
        if (member_Participation_Increase_Rate != 0) effect_Text.text += "참가도 증가율 : " + member_Participation_Increase_Rate * 100f + "%\r\n";
        if (member_Learning_Point_Increase_Rate != 0) effect_Text.text += "학습도 증가율 : " + member_Learning_Point_Increase_Rate * 100f + "%\r\n";
    }
}
