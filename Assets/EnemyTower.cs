﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour
{
    private bool IsDead { get { return GetComponent<HitPoint>().is_Dead; } }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead == true)
        {
            Destroy(gameObject);
        }
    }
}
