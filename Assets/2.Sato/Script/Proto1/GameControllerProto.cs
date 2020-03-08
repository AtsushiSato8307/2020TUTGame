using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerProto : MonoBehaviour
{
    public bool timeStop = false;
    [SerializeField, Tooltip("ストップ中のウィンドウ")]
    private GameObject StopWindow = null;
    // Start is called before the first frame update
    void Start()
    {
        StopWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 停止処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeStop = !timeStop;
            if (timeStop == true){
                StopGame();
            }
            else {
                PlayGame();
            }
        }
    }
    public void StopGame()
    {
        Time.timeScale = 0;
        StopWindow.SetActive(true);
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        StopWindow.SetActive(false);
    }
}
