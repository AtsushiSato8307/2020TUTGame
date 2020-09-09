using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void Playgame()
    {
        
        SceneManager.LoadScene("New Scene 1");
       
    }

    //イベントハンドラー
   
    public void Exit() 
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit(); }
}
