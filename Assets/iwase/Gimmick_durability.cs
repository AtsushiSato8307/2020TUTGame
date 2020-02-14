using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace gimmick_durability
{
    public class Gimmick_durability : MonoBehaviour
    {
        [SerializeField] float maxdurability = 500f;
        [SerializeField] float durability_now = 500f;
        [SerializeField] Slider slider;
        [SerializeField] Transform gimmick_slider;

        //ギミックへのアクセス（ダメージ）判定 //現状の判定条件："//当たり判定" 
        [SerializeField] bool gimmick_hanntei = false;

        //当たり判定　    
        void OnCollisionEnter(Collision collision)
        //tagで管理する場合 
        {
            if (collision.gameObject.tag == "soldier")
            { gimmick_hanntei = true; }
        }
        void OnCollisionExit(Collision collision)
        {
            gimmick_hanntei = false;
        }
        // float Mathf.Clamp(durability_now,0, maxdurability)

        // Start is called before the first frame update
        void Start()
        {
            gimmick_slider = transform.Find("Gimmick_slider");
            slider = gimmick_slider.transform.Find("Slider").GetComponent<Slider>();
            maxdurability = slider.maxValue;

        }

        // Update is called once per frame
        void Update()
        {
            //ギミックにアクセスした際の処理　
            if (gimmick_hanntei == true) { durability_now--; Debug.Log("残り＝" + (durability_now)); }
            slider.value = durability_now;
        }
    }
}
