using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge_Scroll : MonoBehaviour {
    public float speed = 20f;
    public Slider slider;
	// Update is called once per frame
	void Update () {
        slider.value = Mathf.PingPong(Time.time * speed * 10f, 100f);
	}
}
