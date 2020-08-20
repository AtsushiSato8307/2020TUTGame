using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("Speed")]
    private float speed = 0;
    [SerializeField, Tooltip("移動音")]
    private CriAtomSource audio;

    public bool CompulsionStop = false;
    // 移動許可
    bool is_move;
    // 目的地
    private Vector3 distination;
    // 向き
    private Vector3 dir;
    // 
    private float logtime = 0.5f;
    private float logtimer = 0;
    // 0.25秒前の位置
    private Vector3 transLog;

    // 移動終了通知
    public delegate void callback();
    private callback moveEndCall;

    // Start is called before the first frame update
    void Start()
    {
        is_move = false;
        distination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        logtimer += Time.deltaTime;
        if (logtimer > logtime)
        {
            logtimer = 0;
            if (CompulsionStop == false)
            {
                transLog = transform.position;
            }
        }
        if (is_move)
        {
            if (audio.status != CriAtomSource.Status.Playing)
            {
                audio.Play();
            }
        }
        // 2点間の距離が0.1以上離れていたら移動
        if (CompulsionStop)
        {
            CompulsionStop = false;
            distination = transLog;
            dir = Vector3.Normalize(distination - transform.position);
            transform.position += dir * speed * Time.deltaTime;
        }
        else if (Vector3.Distance(transform.position, distination) > 0.1f)
        {
            dir = Vector3.Normalize(distination - transform.position);
            transform.position += dir * speed * Time.deltaTime;
        }
        else if (is_move == true)
        {
            is_move = false;
            moveEndCall.Invoke();
        }
    }
    /// <summary>
    /// </summary>
    /// <param name="distination">目的地</param>
    /// <param name="endMove">コールバック</param>
    public void MovePlayer(Vector3 distination, callback endMove)
    {
        this.distination = distination;
        moveEndCall = endMove;
        is_move = true;
    }
}
