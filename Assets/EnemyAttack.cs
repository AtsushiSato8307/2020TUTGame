using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyStatas statas;
    private Rigidbody rb;
    private float timer;
    private Vector3 beforeVect;

    private GameObject Target{ get { return statas.target; } }
    private int Damage { get { return statas.Damage; } }
    // Start is called before the first frame update
    void Start()
    {
        statas = GetComponent<EnemyStatas>();
        rb = GetComponent<Rigidbody>();
        timer = statas.AttackIntervalTime;
        beforeVect = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null && Vector3.Distance(transform.position, Target.transform.position) < statas.AttackRange)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = statas.AttackIntervalTime;
                Attack();
            }
        }
        beforeVect = transform.position;
    }

    void Attack()
    {
        Target.GetComponent<HitPoint>().currentHitPoint -= Damage;
    }
}
