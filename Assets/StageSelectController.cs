using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectController : MonoBehaviour
{
    private SE se;
    // Start is called before the first frame update
    void Start()
    {
        se = GameObject.FindGameObjectWithTag("SE").GetComponent<SE>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySE(int senum)
    {
        se.PlaySe(senum);
    }
}
