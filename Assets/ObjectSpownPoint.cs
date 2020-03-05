using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpownPoint : MonoBehaviour
{
    [SerializeField, Tooltip("生成間隔")]
    private float intervalTime;

    [SerializeField, Tooltip("生成するオブジェクトのプレファブ")]
    private GameObject enemy;

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
            Instantiate(enemy, gameObject.transform);
        }
    }
}
