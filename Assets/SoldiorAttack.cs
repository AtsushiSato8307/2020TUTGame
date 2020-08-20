using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiorAttack : MonoBehaviour
{
    private SoldiorStatas statas;
    private float timer;
    private Vector3 beforeVect;
    private AudioSource audio;

    private GameObject Target { get { return statas.Target; } }
    private int Damage { get { return statas.Damage; } }
    // Start is called before the first frame update
    void Start()
    {
        statas = GetComponent<SoldiorStatas>();
        timer = statas.AttackIntervalTime;
        beforeVect = transform.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null && Vector3.Distance(transform.position, Target.transform.position) < statas.AttackRange)
        {
            GetComponent<SoldiorMotion>().m_state = SoldiorMotion.SoldiorMotionState.Attack;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = statas.AttackIntervalTime;
                Attack();
            }
        }
        else
        {
            GetComponent<SoldiorMotion>().m_state = SoldiorMotion.SoldiorMotionState.Walk;
        }
        beforeVect = transform.position;
    }

    void Attack()
    {
        audio.PlayOneShot(audio.clip);
        if (Target != null)
        {
            Target.GetComponent<HitPoint>().currentHitPoint -= Damage;
        }
    }
}
