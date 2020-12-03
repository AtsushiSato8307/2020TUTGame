using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class SEBGM_tyousei : MonoBehaviour
{
    // [SerializeField] float maxvolume;
    [SerializeField] public static float BGMvol =0.5f ;
    [SerializeField] public static float SEvol =0.5f ;
    [SerializeField] Slider BGMslider;
    [SerializeField] Slider SEslider;

   // public AudioMixer mixer;

    // GameObject   hikitsugi  = UIhikitsugi.Instance;
    void Start()
    {
        float bgmvol = PlayerPrefs.GetFloat("BGMvol", BGMvol);
        BGMslider.value = BGMvol;
        float sevol = PlayerPrefs.GetFloat("SEvol", SEvol);
        SEslider.value = SEvol;
        CriAtomExCategory.SetVolume("BGM", BGMvol);
        CriAtomExCategory.SetVolume(1, SEvol);
    }

    
    void Update()
    {
        BGMvol = BGMslider.value;
        SEvol = SEslider.value;
        CriAtomExCategory.SetVolume("BGM", BGMvol);
        CriAtom.SetCategoryVolume(1,SEvol);
        Debug.Log("0:" + CriAtom.GetCategoryVolume(0));
        Debug.Log("1:" + CriAtom.GetCategoryVolume(1));
        Debug.Log("2:" + CriAtom.GetCategoryVolume(2));

    }
    public void SetVolChange()
    {
        PlayerPrefs.SetFloat("BGMvol", BGMvol);
        PlayerPrefs.SetFloat("SEvol", SEvol);
    }
     

    //  public void SetGameData(float BGMvol) { this.BGMvol = BGMvol; }


}