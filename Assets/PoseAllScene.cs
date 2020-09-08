using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoseAllScene : MonoBehaviour
{
    private bool isPose;
    [SerializeField, Tooltip("ポーズプレファブ")]
    private GameObject posePrefs;
    [SerializeField, Tooltip("ポーズオープン音")]
    private CriAtomSource poseAudio_Open;
    [SerializeField, Tooltip("ポーズクローズ音")]
    private CriAtomSource poseAudio_Close;
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
            if (isPose)
            {
                poseAudio_Open.Play();
            }
            else {
                poseAudio_Close.Play();
            }
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
    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPose = false;
    }
}
