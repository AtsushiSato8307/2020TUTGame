using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    private string sceneName;
    private string reSceneName;
    [SerializeField, Tooltip("リトライ")]
    private GameObject retry;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != reSceneName)
        {
            ChangeState();
        }
        reSceneName = sceneName;
    }
    private void ChangeState()
    {
        switch (sceneName)
        {
            case "m_Title":
                retry.SetActive(false);
                break;
            case "m_ClearScene":
                retry.SetActive(false);
                break;
            case "m_GameOver":
                retry.SetActive(false);
                break;
            case "m_StageSelect":
                retry.SetActive(false);
                break;
            default:
                retry.SetActive(true);
                break;
        }
    }

}
