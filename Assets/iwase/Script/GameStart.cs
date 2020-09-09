using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//ic class helpbox  MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

public class GameStart : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
{
    public  /*static*/ bool title_pushbutton;
    // Vector2 mousepos = Input.mousePosition;


    

    //GameObject opButton = GameObject.Find("OptionButton");
    //GameObject exButton = GameObject.Find("EXITButton");

  /*  public void OnPointerEnter(PointerEventData eventData)
    {
        title_pushbutton = true;
        Debug.Log(title_pushbutton);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //  title_pushbutton = (false);
        Debug.Log(title_pushbutton);
    }


    // Start is called before the first frame update
    void Start()
    {
       // title_pushbutton = false;
    }


    */

 
    // Update is called once per frame
    void Update()
    {
       

        //s Debug.Log(title_pushbutton); 
        if (
          !EventSystem.current.IsPointerOverGameObject() &&
          Input.GetMouseButtonDown(0)
            )
        {
            Invoke("GoStageSelect", 1);
            GameObject.FindGameObjectWithTag("SE").GetComponent<SE>().PlaySe(1);
        }

    }
    private void GoStageSelect()
    {
        SceneManager.LoadScene("m_StageSelect");
    }



    /*  if (title_pushbutton == false)
      {
          if (Input.GetMouseButtonDown(0))
          { SceneManager.LoadScene("New Scene 1"); }

      }
     */

  //}
}
 