﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class Kari_time : MonoBehaviour
{
    public Text timerText;
    public float totalTime;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        seconds =  (int)totalTime;
        timerText.text = seconds.ToString();


    }
}