using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [HideInInspector]
    public static int[] item;

    // Use this for initialization
    void Awake()
    {
        item = new int[] { 0, 0, 0, 0, 0, 0 };
        AllocateItem();
    }
    public void AllocateItem() //아이템창에 구입한 아이템 배열확인
    {
        for (int index = 0; index < 6; index++)
        {
            if (item[index] == 1 && transform.Find("Item" + (index + 1)).transform.Find("buybt").GetComponent<Button>().enabled)
            {
                
                transform.Find("Item" + (index + 1)).transform.Find("buybt").GetComponent<Button>().enabled = false;
                transform.Find("Item" + (index + 1)).transform.Find("Buy_Image").GetComponent<Image>().enabled = true;
            }
        }
    }
}
