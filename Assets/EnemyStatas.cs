using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 数値の保存場所
public class  EnemyStatas : MonoBehaviour
{
    public float Speed = 3;
    public int MaxHitPoint = 50;
    public int CurrentHitPoint = 50;
    public string TargetTag = "Player";
    public GameObject target;
    public int Damage = 30;
    public float AttackIntervalTime = 2;
    public float AttackRange = 2;
    public GameObject DropItem;

    public float retargetTime = 5;
    private float retargetTimer = 0;

    private HitPoint hp;
    private EnemyMove move;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HitPoint>();
        move = GetComponent<EnemyMove>();
        Retarget();
    }

    // Update is called once per frame
    void Update()
    {
        retargetTimer += Time.deltaTime;
        if (retargetTimer > retargetTime)
        {
            retargetTimer = 0;
            Retarget();
        }
        MaxHitPoint = hp.maxHitPoint;
        CurrentHitPoint = hp.currentHitPoint;
        if (target == null)
        {
            Retarget();   
        }
        else if (target.tag == "Untagged")
        {
            Retarget();
        }
    }
    void Retarget()
    {
        var tagets = GameObject.FindGameObjectsWithTag(TargetTag);
        target = GameObject.FindGameObjectWithTag(TargetTag);
        float distance = float.MaxValue;
        foreach (var i in tagets)
        {
            if (distance > Vector2.Distance(transform.position, i.transform.position))
            {
                distance = Vector2.Distance(transform.position, i.transform.position);
                target = i;
            }
        }
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
