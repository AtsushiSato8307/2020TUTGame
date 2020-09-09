using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{
   // [SerializeField] Button button;


    // Start is called before the first frame update
    void Start()
    {
   //  this.Onclick     
    }
    public void Pushbutton()
    { SceneManager.LoadScene("Title"); }
    // Update is called once per frame
    void Update()
    {
        
    }
}
