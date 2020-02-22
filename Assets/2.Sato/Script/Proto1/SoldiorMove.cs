using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiorMove : MonoBehaviour
{
    private Soldior soldiorPropaty;
    private SoldiorMoveState MoveState { get { return soldiorPropaty.moveState; } set { soldiorPropaty.moveState = value; } }

    private float Speed { get { return soldiorPropaty.speed; } set { soldiorPropaty.speed = value; } }

    public Vector3 TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        soldiorPropaty = GetComponent<Soldior>();
        // AI設定
        // 集団行動に
        MoveState = SoldiorMoveState.Collective;
    }

    // Update is called once per frame
    void Update()
    {
        // 集合
        if (Input.GetKeyDown(KeyCode.R))
        {
            MoveState = SoldiorMoveState.Return;
        }
        // 集団行動
        if (MoveState == SoldiorMoveState.Collective)
        {
            soldiorPropaty.Position = soldiorPropaty.PlayerPosition + soldiorPropaty.OffsetPosition;
        }
        // ターゲット移動
        if (MoveState == SoldiorMoveState.Target)
        {
            // 近づくまで移動する
            if(Mathf.Abs(TargetPosition.x - soldiorPropaty.Position.x) > 0.1f || Mathf.Abs(TargetPosition.z - soldiorPropaty.Position.z) > 0.1f)
            soldiorPropaty.Position = soldiorPropaty.Position + Vector3.Normalize(TargetPosition - soldiorPropaty.Position) * Speed * Time.deltaTime; 
        }
        // 帰還中
        if (MoveState == SoldiorMoveState.Return)
        {
            soldiorPropaty.Position = soldiorPropaty.Position + Vector3.Normalize(soldiorPropaty.PlayerPosition + soldiorPropaty.OffsetPosition - soldiorPropaty.Position) * Speed * Time.deltaTime;
            if (Mathf.Abs(soldiorPropaty.PlayerPosition.x + soldiorPropaty.OffsetPosition.x - soldiorPropaty.Position.x) < 0.1f && Mathf.Abs(soldiorPropaty.PlayerPosition.z + soldiorPropaty.OffsetPosition.z - soldiorPropaty.Position.z) < 0.1f)
            {
                MoveState = SoldiorMoveState.Collective;
            }
        }
    }
}
