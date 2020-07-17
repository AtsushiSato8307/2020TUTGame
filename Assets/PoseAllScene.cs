using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoseAllScene : MonoBehaviour
{
    private bool isPose;
    [SerializeField, Tooltip("ポーズプレファブ")]
    private GameObject posePrefs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPose = !isPose;
        }
        if (isPose)
        {
            Time.timeScale = 0;
            posePrefs.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            posePrefs.SetActive(false);
        }
    }
    public void Contenu()
    {
        isPose = false;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        isPose = false;
    }
}
