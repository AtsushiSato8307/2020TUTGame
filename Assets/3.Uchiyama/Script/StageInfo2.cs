using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo2 : MonoBehaviour
{
    public GameObject Stage;
    public GameObject[] noStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageScen2()
    {
        Stage.SetActive(true);
        /*
        MyCanvas.SetActive("Stage2_Info", false);
        MyCanvas.SetActive("Stage3_Info", false);
        MyCanvas.SetActive("Stage4_Info", false);
        */

        for (int i = 0; i < 3; i++)
        {
            noStage[i].SetActive(false);
        }

    }
}
