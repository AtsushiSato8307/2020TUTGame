using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.Audio;using UnityEngine.UI;

public class music_zanntei : MonoBehaviour
{
    Slider BGMslider;
    
 // public  float volume_now;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    
  

  //  [SerializeField]
    public AudioMixer mixer;



    public void ChangeMusicVolume(float vol)
    {
        mixer.SetFloat("MusicVolume",vol);
    }

    public void ChangeSfxVolume(float vol)
    {
        mixer.SetFloat("SfxVolume", vol);
    }

    public void masterVol(Slider slider)
    {
        mixer.SetFloat("BGM", slider.value);
    }



    // Update is called once per frame
    void Update()
    {
      // bgmslider.value = mixer."MusicVolume"; 
    }
}
