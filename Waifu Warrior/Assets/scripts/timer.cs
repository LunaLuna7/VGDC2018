﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timer : MonoBehaviour {


    public Text timerText;
    private float StartTime;
	// Use this for initialization
	void Start () {
        StartTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.time;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ':' + seconds;

	}
}
