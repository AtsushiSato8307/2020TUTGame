using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private GameObject CrearPrefab;
    private float IntervalTime;
    private bool ClearTrigger = false;
    private bool OverTrigger = false;
    private SE se;
    private bool isPose = false;
    [SerializeField]
    private bool isTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("SE") != null)
        se = GameObject.FindGameObjectWithTag("SE").GetComponent<SE>();
        GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>().beforeStageName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.F))
        //{
        //    ClearTrigger = true;
        //}
        if (ClearTrigger)
        {
            IntervalTime -= Time.deltaTime;
            if (IntervalTime < 0)
            {
                SceneManager.LoadScene("m_ClearScene");                
            }
        }
        else if (OverTrigger)
        {
            IntervalTime -= Time.deltaTime;
            if (IntervalTime < 0)
            {
                if (isTutorial)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else
                {
                    SceneManager.LoadScene("m_GameOver");
                }
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
    public void Over(float IntervalTime)
    {
        if (!ClearTrigger)
        {
            this.IntervalTime = IntervalTime;
            OverTrigger = true;
        }
    }
    public void PlaySE(int senum)
    {
        if(se != null)
        se.PlaySe(senum);
    }
}
