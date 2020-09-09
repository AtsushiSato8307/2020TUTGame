using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(hitPointUI))]
public class HitPoint : MonoBehaviour
{
    private hitPointUI HPUI;
    public int maxHitPoint = 1;
    public int currentHitPoint = 1;
    public bool is_Dead = false;

    [SerializeField, Tooltip("UIを有効化するか？")]
    private bool enabledUI = true;
    // Start is called before the first frame update
    void Start()
    {
        HPUI = GetComponent<hitPointUI>();
        HPUI.enabled = enabledUI;
    }

    // Update is called once per frame
    void Update()
    {
        // UI制御
        HPUI.SetHitPoint(maxHitPoint, currentHitPoint);
        if (currentHitPoint <= 0)
        {
            is_Dead = true;
        }
        HPUI.enabled = enabledUI;
    }
}
