using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canp : MonoBehaviour
{
    private CoolTimeUI ctui;

    [SerializeField, Tooltip("生成間隔")]
    private float intervalTime = 0;

    [SerializeField, Tooltip("生成数")]
    private int spownSoldiorNum = 0;
    
    // タイマー
    private float timer;
    private GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        // UIの設定
        ctui = GetComponent<CoolTimeUI>();
        ctui.SetCoolTime(intervalTime, timer);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ctui.SetCoolTime(intervalTime, timer);

        if (timer > intervalTime)
        {
            timer = 0;
            controller.MaxSoldiorNum += spownSoldiorNum;
            controller.CurrentSoldiorNum += spownSoldiorNum;
        }
    }
}
