using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;

public class Active : MonoBehaviour
{
    [SerializeField]  //オプションボタンを押すとオプションメニュー表示
    private GameObject OptionButton;
    //　ゲーム再開ボタン
  //  [SerializeField]　//Titleボタンや再開ボタンでオプションメニュー非表示
   // private GameObject reStartButton;
    //　アイテムメニューパネル
    [SerializeField]
    private GameObject OptionUIPanel;

    public void StopGame()
    {
        Time.timeScale = 0f;
        OptionButton.SetActive(false);
        //  reStartButton.SetActive(true);
        OptionUIPanel.SetActive(true);
    }

    public void ReStartGame()
    {
        OptionUIPanel.SetActive(false);
      //  reStartButton.SetActive(false);
        OptionButton.SetActive(true);
        Time.timeScale = 1f;
    }

}

 
