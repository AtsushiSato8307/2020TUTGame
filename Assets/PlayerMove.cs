using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("Speed")]
    private float speed;
    // 目的地
    private Vector3 distination;
    // 向き
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 2点間の距離が0.1以上離れていたら移動
        if (Vector3.Distance(transform.position, distination) > 0.1f)
        {
            dir = Vector3.Normalize(distination - transform.position);
            transform.position += dir * speed * Time.deltaTime;
        }
    }
    public void MovePlayer(Vector3 distination)
    {
        this.distination = distination;
    }
}
