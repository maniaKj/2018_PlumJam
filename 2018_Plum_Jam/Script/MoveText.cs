using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveText : MonoBehaviour {
    public float speed = 0.000001f;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }
    public IEnumerator BlinkText()
    {
        while (true)
        {
            text.text = "";
            yield return new WaitForSeconds(.5f);
            text.text = "다른 동아리에게 도전하시겠습니까?";
            yield return new WaitForSeconds(.5f);
            text.text = "";
            yield return new WaitForSeconds(.5f);
            text.text = "기회는 한달에 한번 입니다.";
            yield return new WaitForSeconds(.7f);
        }
    }
}
