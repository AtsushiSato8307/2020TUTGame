using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

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

    [SerializeField, Tooltip("バリア")]
    private GameObject barria;

    [SerializeField, Tooltip("電撃")]
    private GameObject lightning;

    private bool trigger = false;

    private bool explTrigger;
    private bool isDead = false;
    private bool BreakBarria;

    // Start is called before the first frame update
    void Start()
    {
        lightning.SetActive(false);
        if (enemy == null)
        {
            // ボス無し
            barria.SetActive(false);
            BreakBarria = true;
        }
        else
        {
            barria.SetActive(true);
        }
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
                if (enemy != null)
                {
                    boss = Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
                    lightning.GetComponent<LightningBoltScript>().EndObject = boss;
                    lightning.SetActive(true);
                }
                else
                {
                }
            }
        }
        if (boss == null && trigger)
        {
            lightning.SetActive(false);
            // ボス無し
            barria.SetActive(false);
            if (BreakBarria == false)
            {
                BreakBarria = true;
                GetComponent<CriAtomSource>().Play();
            }
        }
        // 城破壊時
        if (isDead == true)
        {
            // ボム荷下ろし
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatas>().HasBomb = false;
            var explo = Instantiate(explosion, transform.position, Quaternion.identity);
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
