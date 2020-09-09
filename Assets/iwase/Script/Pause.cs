using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseUIPrefab;
  //  [SerializeField] GameObject pauseUIInstance;
 
    // Start is called before the first frame update
    void Start()
    {
        // Destroy(pauseUIInstance);
        //  pauseUIPrefab.SetActive(false);
       // pauseUIPrefab.SetActive(!pauseUIPrefab.activeself);
    }

    public void PausemenuActivate()
     {
        // pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;

        //
        pauseUIPrefab.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PausemenuDesactivate()
    {// Destroy(pauseUIInstance); Time.timeScale = 1f;
        pauseUIPrefab.SetActive(false);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
