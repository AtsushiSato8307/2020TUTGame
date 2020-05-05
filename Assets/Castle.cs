using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField, Tooltip("探知用コライダー")]
    private GameObject DetectionSphere;

    [SerializeField, Tooltip("生成するオブジェクトのプレファブ")]
    private GameObject enemy = null;

    private bool trigger = false;
    private bool IsDead { get { return GetComponent<HitPoint>().is_Dead; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectionSphere.GetComponent<DetectionSphere>().PlayerDetectionTrigger)
        {
            gameObject.tag = "Enemy";
            if (!trigger)
            {
                trigger = true;
                Instantiate(enemy, gameObject.transform);
            }
        }
        if (IsDead == true)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().Crear(5);
            Destroy(gameObject);
        }
    }
}
