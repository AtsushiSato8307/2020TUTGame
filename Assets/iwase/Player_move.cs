using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{　//移動する距離と方向
    [SerializeField]
    Vector3 speed;
    // [SerializeField]
    //プレイヤーの向き
   Vector3 F = new Vector3(0f,0f,100.0f);
   Vector3 B = new Vector3(0f,0f,-100.0f);
   Vector3 L = new Vector3(-100.0f,0f,0f);
   Vector3 R = new Vector3(100.0f,0f,0f);

    // Start is called before the first frame update

    void Start()
    {   
        //プレイヤーの向き 

        // if (child.transform) { }
    }



    // Update is called once per frame
    void Update()
    {
     
        // 向きを変更
        if (Input.GetKeyDown(KeyCode.UpArrow))
          {        
            var look = Quaternion.LookRotation(F);
            this.transform.localRotation = look;
          }
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
         {         
            var look = Quaternion.LookRotation(L);
            this.transform.localRotation = look;
          }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
         {
            var look = Quaternion.LookRotation(R);
            this.transform.localRotation = look;
          }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
         { 
            var look = Quaternion.LookRotation(B);
            this.transform.localRotation = look;
          }

        //前進   
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.LeftArrow)|| 
        Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.DownArrow)){ this.transform.Translate(0, 0, speed.z * Time.deltaTime); }
      
     
    }


}
