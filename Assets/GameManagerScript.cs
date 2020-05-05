using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private GameObject CrearPrefab;
    private float IntervalTime;
    private bool CrearTrigger = false;

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrearTrigger)
        {
            IntervalTime -= Time.deltaTime;
            if (IntervalTime < 0)
            {
                SceneManager.LoadScene("CrearScene");
            }
        }
    }
    public void Crear(float IntervalTime)
    {
        if (!CrearTrigger)
        {
            this.IntervalTime = IntervalTime;
            CrearTrigger = true;
        }
    }
}
