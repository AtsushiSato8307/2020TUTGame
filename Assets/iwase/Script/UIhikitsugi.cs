using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI; using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIhikitsugi : MonoBehaviour
{
    public static float BGMvol = SEBGM_tyousei.BGMvol;
    public static float SEvol = SEBGM_tyousei.SEvol;

   // public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {       
    }

      public static void hikitsugi()
      {
          PlayerPrefs.SetFloat("BGMvol", BGMvol);
          PlayerPrefs.Save();
          PlayerPrefs.SetFloat("SEvol", SEvol);
          PlayerPrefs.Save();
      }

   /* public void ChangeMusicVolume(float vol)
    {
        mixer.SetFloat("MusicVolume", vol);

    }*/




    private static Slider mInstance;

    public static Slider Instance {
        get {
            return mInstance;
        }
    }

  
    void Update()
    {
        
    }
}
