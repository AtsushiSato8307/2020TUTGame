using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField, Tooltip("探知用コライダー")]
    private GameObject DetectionSphere;

    [SerializeField, Tooltip("生成するオブジェクトのプレファブ")]
    private GameObject enemy = null;

    [SerializeField]
    private GameObject explosion;

    [SerializeField, Tooltip("生成したボス")]
    private GameObject boss;

    private bool trigger = false;

    private bool explTrigger;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectionSphere.GetComponent<DetectionSphere>().PlayerDetectionTrigger)
        {
            if (!trigger)
            {
                trigger = true;
                explTrigger = true;
                boss = Instantiate(enemy, gameObject.transform.position ,Quaternion.identity);
            }
        }
        if (isDead == true)
        {
            var explo = Instantiate(explosion, transform.position ,Quaternion.identity);
            explo.transform.localScale = new Vector3(5, 5, 5);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().Crear(1.5f);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (boss == null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (explTrigger)
                {
                    isDead = true;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (boss == null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (explTrigger)
                {
                    isDead = true;
                }
            }
        }
    }
}
