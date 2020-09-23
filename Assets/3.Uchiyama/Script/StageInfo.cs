using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        GameObject work = GameObject.Find("Scrollbar1");
            if (work)
            {
                float aRatio = work.GetComponent<Scrollbar>().value;
                aRatio = (float)num / (StageInfos.Length -1);
                work.GetComponent<Scrollbar>().value = 1 - aRatio;
            }
        
    }
}
