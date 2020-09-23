using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiorStatas : MonoBehaviour
{
    public float Speed = 2;
    public int MaxHitPoint = 50;
    public int CurrentHitPoint = 50;
    public int Damage = 30;
    public float AttackIntervalTime = 2;
    public float AttackRange = 5;
    public GameObject Target;
    private bool IsDead { get { return GetComponent<HitPoint>().is_Dead; } }

    private HitPoint hp;
    private SoldiorNavMove move;

    void Start()
    {
        hp = GetComponent<HitPoint>();
        move = GetComponent<SoldiorNavMove>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxHitPoint = hp.maxHitPoint;
        CurrentHitPoint = hp.currentHitPoint;
        if (IsDead == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
