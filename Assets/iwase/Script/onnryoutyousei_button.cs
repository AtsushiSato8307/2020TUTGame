using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onnryoutyousei_button : MonoBehaviour
{
    public static float BGMvol = SEBGM_tyousei.BGMvol;
    public static float SEvol = SEBGM_tyousei.SEvol;
    // Start is called before the first frame update

    void Start()
    {
         
        
       
    }

    public void BGMVol_up()
    {
        float bgmvol = PlayerPrefs.GetFloat("BGMvol", BGMvol);
        BGMvol = BGMvol + 0.1f;
        PlayerPrefs.SetFloat("BGMvol", BGMvol);
        PlayerPrefs.Save();
    }

    public void BGMVol_down()
    {
        float bgmvol = PlayerPrefs.GetFloat("BGMvol", BGMvol);
        BGMvol = BGMvol - 0.1f;
        PlayerPrefs.SetFloat("BGMvol", BGMvol);
        PlayerPrefs.Save();
    }

    public void SEVol_up()
    {
        float bgmvol = PlayerPrefs.GetFloat("SEvol", SEvol);
        SEvol = SEvol + 0.1f;
        PlayerPrefs.SetFloat("SEvol", SEvol);
        PlayerPrefs.Save();
    }

    public void SEVol_down()
    {
        float sevol = PlayerPrefs.GetFloat("SEvol", SEvol);
        BGMvol = sevol - 0.1f;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
