using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpownPoint : MonoBehaviour
{
    [SerializeField, Tooltip("生成間隔")]
    private float intervalTime = 0;

    [SerializeField, Tooltip("生成するオブジェクトのプレファブ")]
    private GameObject enemy = null;

    [SerializeField, Tooltip("初期生成ありか")]
    private bool StartSpown = false;

    // タイマー
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        if (StartSpown)
        {
            timer = intervalTime;
        }
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
