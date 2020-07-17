using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    private GameObject Player;

    [SerializeField, Tooltip("オフセット")]
    private Vector3 offset = Vector3.zero;
    [SerializeField, Tooltip("プレイヤーとの距離のしきい値")]
    private Vector3 distanceLimit = Vector3.zero;
    [SerializeField, Tooltip("オフセットリミット")]
    private Vector3 offsetLimit = new Vector3(0, 20, -10);

    private float scroll;

    private Vector3 PlayerPosition { get { if (Player != null) return Player.transform.position; else return transform.position; } }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = PlayerPosition + offset;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        float fixedx, fixedy, fixedz;
        fixedx =
        Mathf.Clamp(transform.position.x, PlayerPosition.x - distanceLimit.x, PlayerPosition.x + distanceLimit.x);
        fixedy =
        Mathf.Clamp(transform.position.y, PlayerPosition.y - distanceLimit.y, PlayerPosition.y + distanceLimit.y);
        fixedz =
        Mathf.Clamp(transform.position.z, PlayerPosition.z - distanceLimit.z, PlayerPosition.z + distanceLimit.z);
        
        // 調整
        if (offset.y < 1f)
        {
            offset = new Vector3(0, 1, -0.5f);
        }

        if (!(offset.y < offsetLimit.y && offset.y > -offsetLimit.y))
        {
            offset.y = offsetLimit.y;
            offset.z = offsetLimit.z;
        }
        if (Player != null)
        {
            transform.position = new Vector3(fixedx, fixedy, fixedz) + offset;
        }
    }
    /// <summary>オフセットを変更してカメラ操作する
    /// </summary>
    void MoveCamera()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");

        offset.y -= scroll * 10;
        offset.z -= scroll * -5;
    }
}
