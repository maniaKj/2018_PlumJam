﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat
{
    public string name;
    public int fund, headCount;
    [Range(0, 100)] public float reputation, Happiness, participation, learning_Point;
    public bool isEnabled;
    public float HeadCount_Increase_Rate;
    public float Fund_Increase_Rate, Reputation_Increase_Rate, member_Happiness_Increase_Rate, member_Participation_Increase_Rate, member_Learning_Point_Increase_Rate;
};

public class Status:MonoBehaviour{

    [ExecuteInEditMode]
    public Text budget;
    public string name = "PLUM";
    //기본 스테이터스 변수
    [Header("플럼 스테이터스")]
    public int MemberCount;
    public int Money;
    [Range(0, 100)] public float Reputation;
    [Header("플럼 멤버 스테이터스")]
    [Range(0, 100)] public float Happiness;
    [Range(0, 100)] public float Participation, Education;

    [Header("스테이터스 증가율")]
    public float HeadCount_Increase_Rate = 1.00f;
    public float Fund_Increase_Rate = 1.00f, Reputation_Increase_Rate = 1.00f, member_Happiness_Increase_Rate = 1.00f, member_Participation_Increase_Rate = 1.00f, member_Learning_Point_Increase_Rate = 1.00f;

    public bool isEnabled = true;
    public bool isChallenge = true;
    private static Stat[] stats;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        stats = new Stat[5];
        stats[0].name = "PLUM";
        stats[1].name = "EA";
        stats[2].name = "다방";
        stats[3].name = "WMV";
        stats[4].name = "ITQ";
        Get_State("PLUM", 150000, 40, 10f, 20f, 20f, 30f, true);
        Get_Increase_Rate("PLUM", 1, 1, 1, 1, 1, 1);
        Get_State("EA", 3000000, 90, 90f, 70f, 70f, 70f, true);
        Get_Increase_Rate("EA", 1, 1, 1, 1, 1, 1);
        Get_State("다방", 3000000, 70, 40f, 40f, 90f, 50f, true);
        Get_Increase_Rate("다방", 1, 1, 1, 1, 1, 1);
        Get_State("WMV", 3000000, 70, 40f, 90f, 40f, 40f, true);
        Get_Increase_Rate("WMV", 1, 1, 1, 1, 1, 1);
        Get_State("ITQ", 3000000, 70, 90f, 30f, 30f, 70f, true);
        Get_Increase_Rate("ITQ", 1, 1, 1, 1, 1, 1);
        init();
    }
    private void init()
    {
        MemberCount = stats[0].headCount;
        Money = stats[0].fund;
        Happiness = stats[0].Happiness;
        Participation = stats[0].participation;
        Education = stats[0].learning_Point;
        Reputation = stats[0].reputation;
    }
    public static Stat[] Get_Data()
    {
        return stats;
    }
    public static void Get_Increase_Rate(string name, float fund, float headCount, float reputation, float Happines, float participation,
    float learning_Point)
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if (stats[i].name == name)
            {
                stats[i].Fund_Increase_Rate = fund;
                stats[i].HeadCount_Increase_Rate = headCount;
                stats[i].Reputation_Increase_Rate = reputation;
                stats[i].member_Happiness_Increase_Rate = Happines;
                stats[i].member_Participation_Increase_Rate = participation;
                stats[i].member_Learning_Point_Increase_Rate = learning_Point;
                break;
            }
        }
    }
    public static void Get_State(string name, int fund, int headCount, float reputation, float Happines, float participation,
        float learning_Point, bool isEnabled)
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if (stats[i].name == name)
            {
                stats[i].fund = fund;
                stats[i].headCount = headCount;
                stats[i].reputation = reputation;
                stats[i].Happiness = Happines;
                stats[i].participation = participation;
                stats[i].learning_Point = learning_Point;
                stats[i].isEnabled = isEnabled;
                break;
            }
        }
    }

    //스테이터스 변경 함수
    public void UpdateMemberStatus(float Change_Happiness, float Change_Participation, float Change_Learning_Point)
    {
        Happiness = Mathf.Clamp(Happiness + Change_Happiness * member_Happiness_Increase_Rate, 0.0f, 100.0f);
        Participation = Mathf.Clamp(Participation + Change_Participation * member_Participation_Increase_Rate, 0.0f, 100.0f);
        Education = Mathf.Clamp(Education + Change_Learning_Point * member_Learning_Point_Increase_Rate, 0.0f, 100.0f);
        Get_GameInfo_Change();
    }

    public void Get_Member_Status_Change_By_Percentage(float Happinese_Rate, float Participation_Rate, float Learning_Point_Rate)
    {
        Happiness = Mathf.Clamp(Happiness + Happiness * Happinese_Rate, 0.0f, 100.0f);
        Participation = Mathf.Clamp(Participation + Participation * Participation_Rate, 0.0f, 100.0f);
        Education = Mathf.Clamp(Education + Education * Learning_Point_Rate, 0.0f, 100.0f);
        Get_GameInfo_Change();
    }

    public void UpdateMemberCount(int Change_Member)
    {
        MemberCount = Mathf.Clamp(MemberCount + Mathf.RoundToInt(Change_Member * HeadCount_Increase_Rate),0, 1000);
        Get_GameInfo_Change();
    }

    public void UpdateMoney(int Change_Fund)
    {
        Money = Mathf.Clamp(Money + Mathf.RoundToInt(Change_Fund * Fund_Increase_Rate),0 ,100000000);
        budget.text = Money + "원";
        /*if(GameObject.FindGameObjectWithTag("mainUI").transform.Find("balance"))
            GameObject.FindGameObjectWithTag("mainUI").transform.Find("balance").GetComponent<Budget>().Value_Change(Fund);*/
        Get_GameInfo_Change();
    }

    public void UpdateReputation(float Change_Reputation)
    {
        Reputation = Mathf.Clamp(Reputation + Mathf.RoundToInt(Change_Reputation * Reputation_Increase_Rate), 0.0f, 100.0f);
        Get_GameInfo_Change();
    }
    public void Get_GameInfo_Change()
    {
        string name = "PLUM";
        Get_State(name, Money, MemberCount, Reputation, Happiness, Participation
            , Education, isEnabled);
        Get_Increase_Rate(name, Fund_Increase_Rate, HeadCount_Increase_Rate, Reputation_Increase_Rate, member_Happiness_Increase_Rate, member_Participation_Increase_Rate, member_Learning_Point_Increase_Rate);
    }
    public void Get_GameInfo_Change(string name)
    {
        Get_State(name, Money, MemberCount, Reputation, Happiness, Participation
            , Education, isEnabled);
        Get_Increase_Rate(name, Fund_Increase_Rate, HeadCount_Increase_Rate, Reputation_Increase_Rate, member_Happiness_Increase_Rate, member_Participation_Increase_Rate, member_Learning_Point_Increase_Rate);
    }
    public void Get_Increase_Rate_Change(float headerCount_Rate, float fund_Rate, float Reputatioin_Rate, float Happiness_Rate, float Participation_Rate, float Learning_Point_Rate)
    {
        HeadCount_Increase_Rate += headerCount_Rate;
        Fund_Increase_Rate += fund_Rate;
        Reputation_Increase_Rate += Reputatioin_Rate;
        member_Happiness_Increase_Rate += Happiness_Rate;
        member_Participation_Increase_Rate += Participation_Rate;
        member_Learning_Point_Increase_Rate += Learning_Point_Rate;
    }
}
