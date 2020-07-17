using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private GameObject CrearPrefab;
    private float IntervalTime;
    private bool ClearTrigger = false;
    private SE se;

    // Start is called before the first frame update
    void Start()
    {
        se = GameObject.FindGameObjectWithTag("SE").GetComponent<SE>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            ClearTrigger = true;
        }
        if (ClearTrigger)
        {
            IntervalTime -= Time.deltaTime;
            if (IntervalTime < 0)
            {
                SceneManager.LoadScene("ClearScene");
            }
        }
    }
    public void Crear(float IntervalTime)
    {
        if (!ClearTrigger)
        {
            this.IntervalTime = IntervalTime;
            ClearTrigger = true;
        }
    }
    public void PlaySE(int senum)
    {
        se.PlaySe(senum);
    }
}
