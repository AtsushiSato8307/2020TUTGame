using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMoveSerect : MonoBehaviour
{
    public string RSceneName;
    public string SSceneName;
    public string NSceneName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnbuttonR()
    {
        SceneManager.LoadScene(RSceneName);
    }

    public void OnbuttonS()
    {
        SceneManager.LoadScene(SSceneName);
    }

    public void OnbuttonN()
    {
        SceneManager.LoadScene(NSceneName);
    }
}
