using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPoint : MonoBehaviour
{
    private bool hit_Player;
    [SerializeField]
    TutorialSystem tsystem;
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
        Debug.Log(col.gameObject);
        if (col.gameObject.CompareTag("Player"))
        {
            tsystem.CurrentEventNum = 2;
            tsystem.EnubledOk();
        }
    }
    private void OnTriggerStay(Collider col)
    {
        Debug.Log(col.gameObject);

        if (col.gameObject.CompareTag("Player"))
        {
            hit_Player = true;
            tsystem.CurrentEventNum = 2;
            tsystem.EnubledOk();
        }
    }
}
