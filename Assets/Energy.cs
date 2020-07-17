using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField, Tooltip("制限速度")]
    private float limitSpeed;
    [SerializeField, Tooltip("速度")]
    private float speed;
    private GameObject Player;
    private GameController Controller;
    private Vector3 distination;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            distination = Player.transform.position;
            transform.position = Vector3.Slerp(transform.position, distination, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, distination) < 0.1f)
            {
                Controller.ReinforcedPoint++;
                Destroy(gameObject);
            }
        }
    }
}
