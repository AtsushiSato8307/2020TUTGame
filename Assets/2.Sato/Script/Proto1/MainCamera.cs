using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    private GameObject Player;

    [SerializeField, Tooltip("オフセット")]
    private Vector3 offset;
    [SerializeField, Tooltip("プレイヤーとの距離のしきい値")]
    private Vector3 distanceLimit;

    private Vector3 PlayerPosition { get { return Player.transform.position; } }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = PlayerPosition + offset;
    }

    // Update is called once per frame
    void Update()
    {
        float fixedx, fixedy, fixedz;
        fixedx =
        Mathf.Clamp(transform.position.x, PlayerPosition.x - distanceLimit.x, PlayerPosition.x + distanceLimit.x);
        fixedy =
        Mathf.Clamp(transform.position.y, PlayerPosition.y - distanceLimit.y, PlayerPosition.y + distanceLimit.y);
        fixedz =
        Mathf.Clamp(transform.position.z, PlayerPosition.z - distanceLimit.z, PlayerPosition.z + distanceLimit.z);

        transform.position = new Vector3(fixedx, fixedy, fixedz) + offset;

    }
}
