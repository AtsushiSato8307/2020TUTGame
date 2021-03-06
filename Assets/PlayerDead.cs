﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private float timer;
    private HitPoint hp;
    private bool hit_Land;
    private float canHitTime = 0.05f;
    [SerializeField, Tooltip("死亡時エフェクト")]
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HitPoint>();
        timer = canHitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.is_Dead)
        {
            GetComponent<PlayerStatas>().is_Dead = true;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().Over(1.5f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        timer -=Time.deltaTime;
        
    }
    // 水に触れてもいい時間加算
    public void HitLand()
    {
        timer = canHitTime;
    }
    public void WaterHazard()
    {
        if (timer < 0)
        {
            GetComponent<PlayerMove>().CompulsionStop = true;
        }
    }
}
