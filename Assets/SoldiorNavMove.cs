using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldiorNavMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private EnemyStatas statas;
    private GameObject Target { get { return statas.target; } }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        statas = GetComponent<EnemyStatas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            agent.destination = Target.transform.position;
        }
    }
}
