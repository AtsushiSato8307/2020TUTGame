using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerDead>().HitLand();
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerDead>().HitLand();
        }
    }
    //private void OnTriggerExit(Collider col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        col.gameObject.GetComponent<PlayerDead>().Hit_Land = false;
    //    }
    //}
}
