using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Event : MonoBehaviour {
    readonly int[] item;
    public void BuyItem(int index)
    {
        int money = GameObject.Find("Plum").GetComponent<Status>().Money;
        int value = int.Parse(GetComponentInChildren<Text>().text);
        AudioSource audio;
        if (!GetComponent<AudioSource>())
        {
            audio = gameObject.AddComponent<AudioSource>();
        }
        else
            audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        int[] item = StoreManager.item;
        if (money >= value && money>0 && item[index]==0)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/Paying");
            audio.volume = 0.5f;
            audio.Play();
            GameObject.Find("Plum").GetComponent<Status>().UpdateMoney(-int.Parse(GetComponentInChildren<Text>().text));
            GetComponent<Button>().enabled = false;
            transform.parent.Find("Buy_Image").GetComponent<Image>().enabled = true;
            item[index] = 1;
            //GameObject.FindGameObjectWithTag("Finish").GetComponent<StorageManager>().Get_Bought_Signal(index);

        }
        else
        {
            audio.clip = Resources.Load<AudioClip>("Sound/Error");
            audio.Play();
        }
    }
}
