using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{
    public GameObject[] StageInfos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageScen(int num)
    {
        foreach(var i in StageInfos)
        {
            i.SetActive(false);
        }
        StageInfos[num].SetActive(true);
    }
}
