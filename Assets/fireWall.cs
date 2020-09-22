using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireWall : MonoBehaviour
{
    [SerializeField, Tooltip("Damage")]
    private int damage;
    [SerializeField, Tooltip("CoolTime")]
    private int coolTime;

    private bool DamageFrame;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = coolTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        DamageFrame = false;

        if (timer < 0)
        {
            timer = coolTime;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (DamageFrame)
        {
            var tag = col.gameObject.tag;
            if (tag == "Player")
            {
                col.gameObject.GetComponent<PlayerDead>().WaterHazard();
            }
            if (tag == "Soldior")
            {
                col.gameObject.GetComponent<HitPoint>().currentHitPoint -= damage;
            }
            if (tag == "Buildig")
            {
                col.gameObject.GetComponent<HitPoint>().currentHitPoint -= damage;
            }
            if (tag == "Enemy")
            {
                col.gameObject.GetComponent<HitPoint>().currentHitPoint -= damage;
            }
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (DamageFrame)
        {
            var tag = col.gameObject.tag;
            if (tag == "Player")
            {
                col.gameObject.GetComponent<PlayerDead>().WaterHazard();
            }
            if (tag == "Soldior")
            {
                col.gameObject.GetComponent<HitPoint>().currentHitPoint -= damage;
            }
            if (tag == "Buildig")
            {
                col.gameObject.GetComponent<HitPoint>().currentHitPoint -= damage;
            }
            if (tag == "Enemy")
            {
                col.gameObject.GetComponent<HitPoint>().currentHitPoint -= damage;
            }
            DamageFrame = true;
            Debug.Log("hit");
        }
    }
}
