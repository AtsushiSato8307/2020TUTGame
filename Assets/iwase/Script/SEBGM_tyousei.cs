using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;using UnityEngine.SceneManagement;using UnityEngine.Audio;


public class SEBGM_tyousei : MonoBehaviour
{
    // [SerializeField] float maxvolume;
    [SerializeField] public static float BGMvol =0.1f ;
    [SerializeField] public static float SEvol =0.5f ;
    [SerializeField] Slider BGMslider;
    [SerializeField] Slider SEslider;
    private AudioSource BGM;
    private AudioSource SE;

   // public AudioMixer mixer;

    // GameObject   hikitsugi  = UIhikitsugi.Instance;
    void Start()
    {
        BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        SE = GameObject.FindGameObjectWithTag("SE").GetComponent<AudioSource>();

        float bgmvol = PlayerPrefs.GetFloat("BGMvol", BGMvol);
        BGMslider.value = BGMvol;

        float sevol = PlayerPrefs.GetFloat("SEvol", SEvol);
        SEslider.value = SEvol;

    }

    
    void Update()
    {
    //  slider.value  = BGMvol;
     BGM.volume = BGMslider.value;
     SE.volume =  SEslider.value;
      BGMvol=  BGM.volume;
    //  return BGMvol;
     }
     

    //  public void SetGameData(float BGMvol) { this.BGMvol = BGMvol; }


}