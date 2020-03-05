using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("Speed")]
    private float speed = 0;
    // 移動許可
    bool is_move;
    // 目的地
    private Vector3 distination;
    // 向き
    private Vector3 dir;

    // 移動終了通知
    public delegate void callback();
    private callback moveEndCall;

    // Start is called before the first frame update
    void Start()
    {
        is_move = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 2点間の距離が0.1以上離れていたら移動
        if (Vector3.Distance(transform.position, distination) > 1f)
        {
            dir = Vector3.Normalize(distination - transform.position);
            transform.position += dir * speed * Time.deltaTime;
        }
        else if(is_move == true){
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
