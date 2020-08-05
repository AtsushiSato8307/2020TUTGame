using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpownRandPoint : MonoBehaviour
{
    [SerializeField, Tooltip("生成間隔")]
    private float intervalTime = 0;

    [SerializeField, Tooltip("生成するオブジェクトのプレファブ")]
    public GameObject[] enemy;

    // タイマー
    private float timer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > intervalTime)
        {
            timer = 0;
            GameObject Enemy = enemy[Random.Range(0, enemy.Length)];
            Instantiate(Enemy, gameObject.transform);
        }
    }
}