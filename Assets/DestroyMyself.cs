using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    [SerializeField, Tooltip("死亡時間")]
    private float DestroyTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTime -= Time.deltaTime;
        if (DestroyTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
