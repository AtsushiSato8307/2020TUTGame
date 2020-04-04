using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldiorNavMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private SoldiorStatas statas;
    private Queue<GameObject> TargetPoints = new Queue<GameObject>();
    private GameObject CurrentTarget { set { statas.Target = value; } get { return statas.Target; } }
    private GameObject TransTargetObj;

    [SerializeField, Tooltip("目的地指定用プレファブ")]
    private GameObject TargetObj;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        statas = GetComponent<SoldiorStatas>();
        // 初期値設定
        agent.speed = statas.Speed;
        agent.stoppingDistance = statas.AttackRange;
    }

    // Update is called once per frame
    void Update()
    {
        // ターゲットできていれば移動
        if (CurrentTarget != null)
        {
            agent.destination = CurrentTarget.transform.position;

            // TransFormに到着時プレファブを消去
            if (CurrentTarget == TransTargetObj 
                && Vector3.Distance(transform.position, CurrentTarget.transform.position) < statas.AttackRange)
            {
                GameObject.Destroy(TransTargetObj);
            }
        }
        // ターゲットがなければ次のターゲットへ
        else
        {
            GoToNextTarget();
        }
    }
    /// <summary> 次の目的地へ
    /// </summary>
    private void GoToNextTarget()
    {
        if (TargetPoints.Count != 0)
        {
            CurrentTarget = TargetPoints.Dequeue();
        }
        // キューが空ならエネミーをターゲットに
        else {
            AddPoints(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    /// <summary>目的地オブジェクトの追加
    /// </summary>
    /// <param name="addObj">gameObject</param>
    public void AddPoints(GameObject addObj)
    {
        TargetPoints.Enqueue(addObj);
    }
    /// <summary>目的地Transfomeの追加
    /// </summary>
    /// <param name="addTrans">Transform</param>
    public void AddPoints(Transform addTrans)
    {
        TransTargetObj = Instantiate(TargetObj, addTrans);
        TargetPoints.Enqueue(TransTargetObj);
    }
    /// <summary>目的地位置の追加
    /// </summary>
    /// <param name="addPosition">位置</param>
    public void AddPoints(Vector3 addPosition)
    {
        TransTargetObj = Instantiate(TargetObj, addPosition, Quaternion.identity);
        TargetPoints.Enqueue(TransTargetObj);
    }
}
