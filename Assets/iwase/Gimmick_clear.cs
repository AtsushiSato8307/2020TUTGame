using System.Collections;
using System.Collections.Generic;
using UnityEngine;using gimmick_durability;using UnityEngine.UI;

public class Gimmick_clear : MonoBehaviour
{  //ギミックが達成された時の反応（ギミックに付けるスクリプト）
   
    [SerializeField] Slider slider;
    [SerializeField] Transform gimmick_slider;
 
    //ギミックが達成されたかどうか
    bool gimiick_status;

    //耐久値の取得
   // [SerializeField]
 //  public float durability_now; 


    // Start is called before the first frame update
    void Start()
    {
        gimmick_slider = transform.Find("Gimmick_slider");
        slider = gimmick_slider.transform.Find("Slider").GetComponent<Slider>();
       // durability_now = transform.Find("durability_now");

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0)
        { //ギミックが達成された時の反応//現状は消すだけ
            Destroy(this.gameObject);
        }

    }
}
