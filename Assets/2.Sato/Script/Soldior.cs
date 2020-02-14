using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoldiorMoveState
{
    Collective, // 集団
    Target,     // ターゲットに移動中
    Attack,     // 攻撃中
    Work,       // 作業中
    Return      // 帰還中
}
public class Soldior : MonoBehaviour

{
    private GameObject player;

    public SoldiorMoveState moveState; 

    [SerializeField, Tooltip("プレイヤーとのオフセット")]
    public Vector3 OffsetPosition;

    public Soldiortype type;

    public float speed;

    public Vector3 PlayerPosition { get { if (player != null) return player.transform.position; else return Vector2.zero; } }

    private Vector3 position;
    public Vector3 Position { get { return transform.position; } set { transform.position = value; } } 
    
    // Start is called before the first frame update
    void Start()
    {
        // キャッシュ
        player = GameObject.FindGameObjectWithTag("Player");
        // 位置初期化
        Position = PlayerPosition + OffsetPosition;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
