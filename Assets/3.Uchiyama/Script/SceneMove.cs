using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    private string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton(string SceneName)
    {
        nextScene = SceneName;
        Invoke("ChangeScene", 0.5f);
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);

    }
}
