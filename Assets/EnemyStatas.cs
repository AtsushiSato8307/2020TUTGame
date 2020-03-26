using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 数値の保存場所
public class  EnemyStatas : MonoBehaviour
{
    public float Speed = 10;
    public int MaxHitPoint = 50;
    public int CurrentHitPoint = 50;
    public string TargetTag = "Player";
    public GameObject target;
    public int Damage = 30;
    public float AttackIntervalTime = 2;
    public float AttackRange = 2; 

    private HitPoint hp;
    private EnemyMove move;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HitPoint>();
        move = GetComponent<EnemyMove>();
        target = GameObject.FindGameObjectWithTag(TargetTag);
    }

    // Update is called once per frame
    void Update()
    {
        MaxHitPoint = hp.maxHitPoint;
        CurrentHitPoint = hp.currentHitPoint;
        if (target == null)
        {
            Retarget();   
        }
    }
    void Retarget()
    {
        target = GameObject.FindGameObjectWithTag(TargetTag);
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
