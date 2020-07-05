using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarpenterNavMove : MonoBehaviour
{
    private GameController controller;
    private NavMeshAgent agent;
    private float speed = 2;
    private Queue<GameObject> TargetPoints = new Queue<GameObject>();
    private GameObject CurrentTarget;
    private GameObject TransTargetObj;
    public delegate void Bilding();
    private Bilding bilding;
    private GameObject makePrefab;

    [SerializeField, Tooltip("目的地指定用プレファブ")]
    private GameObject TargetObj;

    [SerializeField, Tooltip("建築中プレファブ")]
    private GameObject underConstructionPref;

    private float timer = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        agent = GetComponent<NavMeshAgent>();
        // 初期値設定
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (makePrefab != null)
        {
            var coolui = makePrefab.GetComponent<CoolTimeUI>();
            coolui.MaxTime = controller.buildtime.DefaltBuildTime;
            coolui.CurrentTime = controller.buildtime.DefaltBuildTime + timer;
        }
        // 建築中は優先して停止
        if (timer > -controller.buildtime.DefaltBuildTime && timer < 0)
        {
            agent.destination = transform.position;
        }
        else if (timer > 0 && timer < controller.buildtime.DefaltBuildTime)
        {
            timer = float.MaxValue;
            bilding.Invoke();
            Destroy(makePrefab);
        }
        else
        {
            // ターゲットできていれば移動
            if (CurrentTarget != null)
            {
                agent.destination = CurrentTarget.transform.position;

                // TransFormに到着時プレファブを消去
                if (CurrentTarget == TransTargetObj
                    && Vector3.Distance(transform.position, CurrentTarget.transform.position) < 0.5f)
                {
                    GameObject.Destroy(TransTargetObj);
                    makePrefab = Instantiate(underConstructionPref, transform.position, Quaternion.identity);
                    timer = -controller.buildtime.DefaltBuildTime;
                }
            }
            // ターゲットがなければ次のターゲットへ
            else
            {
                GoToNextTarget();
            }
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
        // キューが空ならプレイヤーをターゲットに
        else if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 0.5f)
        {
            agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetBilding(Bilding bilding)
    {
        this.bilding = bilding;
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
