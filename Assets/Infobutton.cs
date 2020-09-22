using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infobutton : MonoBehaviour
{
    private GameObject tutoinfo;
    // Start is called before the first frame update
    void Start()
    {
        tutoinfo = GameObject.FindGameObjectWithTag("Info").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutoinfo == null)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void PushButton()
    {
        tutoinfo.SetActive(true);
    }
}
