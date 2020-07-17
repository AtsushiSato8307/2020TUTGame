using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneController : MonoBehaviour
{
    private SE se;
    private string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        se = GameObject.FindGameObjectWithTag("SE").GetComponent<SE>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySE(int SENum)
    {
        se.PlaySe(1);
    }
    public void ChangeScene(string SceneName)
    {
        nextSceneName = SceneName;
        Invoke("GoNextScene", 1);
    }
    private void GoNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
