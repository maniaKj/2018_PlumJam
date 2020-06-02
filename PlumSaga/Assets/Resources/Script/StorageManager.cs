using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour {
    int[] item;
    // Use this for initialization
    void OnEnable () {
        AllocateItem();
    }
    public void AllocateItem() //아이템창에 구입한 아이템 배열확인
    {
        int[] item = StoreManager.item;
        for (int index = 0; index < 6; index++)
        {
            try
            {
                if (item[index] == 1)
                {
                    /*for(int j = 0; j < transform.Find("Item" + (index + 1)).childCount; j++)
                    {
                        transform.Find("Item" + (index + 1)).GetChild(j).gameObject.SetActive(true);
                    }*/
                    transform.Find("Item" + (index + 1)).transform.Find("Image").GetComponent<Image>().enabled = true;
                    transform.Find("Item" + (index + 1)).transform.Find("Item_text").GetComponent<Text>().enabled = true;
                    transform.Find("Item" + (index + 1)).transform.Find("Item_name").GetComponent<Text>().enabled = true;
                    transform.Find("Item" + (index + 1)).transform.Find("Item_effect_text").GetComponent<Text>().enabled = true;
                }
                else if (item[index] == 0)
                {
                    /*for (int j = 0; j < transform.Find("Item" + (index + 1)).childCount; j++)
                    {
                        transform.Find("Item" + (index + 1)).GetChild(j).gameObject.SetActive(false);
                    }*/
                    transform.Find("Item" + (index + 1)).transform.Find("Image").GetComponent<Image>().enabled = false;
                    transform.Find("Item" + (index + 1)).transform.Find("Item_text").GetComponent<Text>().enabled = false;
                    transform.Find("Item" + (index + 1)).transform.Find("Item_name").GetComponent<Text>().enabled = false;
                    transform.Find("Item" + (index + 1)).transform.Find("Item_effect_text").GetComponent<Text>().enabled = false;
                }
            }
            catch (System.NullReferenceException e)
            {
                /*for (int j = 0; j < transform.Find("Item" + (index + 1)).childCount; j++)
                {
                    transform.Find("Item" + (index + 1)).GetChild(j).gameObject.SetActive(false);
                }*/
                transform.Find("Item" + (index + 1)).transform.Find("Image").GetComponent<Image>().enabled = false;
                transform.Find("Item" + (index + 1)).transform.Find("Item_text").GetComponent<Text>().enabled = false;
                transform.Find("Item" + (index + 1)).transform.Find("Item_name").GetComponent<Text>().enabled = false;
                transform.Find("Item" + (index + 1)).transform.Find("Item_effect_text").GetComponent<Text>().enabled = false;
            }

        }
    }

    public void Get_Bought_Signal(int num)
    {
        for (int j = 0; j < transform.Find("Item" + (num + 1)).childCount; j++)
        {
            transform.Find("Item" + (num + 1)).GetChild(j).gameObject.SetActive(true);
        }
    }

}
