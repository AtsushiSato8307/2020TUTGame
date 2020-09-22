using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domination : MonoBehaviour
{
    private CoolTimeUI coolui;
    [SerializeField, Tooltip("設置オブジェクト")]
    private GameObject objPrefs;

    [SerializeField, Tooltip("設置までにかかる時間")]
    private float time;
    // 設置しているか
    public bool is_build;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        coolui = GetComponent<CoolTimeUI>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_build)
        {
            coolui.enabled = true;
            if (timer > time)
            {
                Build();
            }
            coolui.SetCoolTime(time, timer);
        }
        else
        {
            coolui.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
        }
    }
    private void Build()
    {
        Instantiate(objPrefs, transform.position, Quaternion.identity);
        is_build = true;
        timer = 0;
    }
}
