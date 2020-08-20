using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{   
    public CriAtomSource menu_dicision;
    public CriAtomSource menu_cancel;
    public CriAtomSource game_dicision;
    public CriAtomSource cursol;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
    }
    public void PlaySe(int senum)
    {
        switch (senum)
        {
            case 0:
                PlayMenuCancel();
                break;
            case 1:
                PlayMenuDicision();
                break;
            case 3:
                PlayCursol();
                break;
            case 4:
                PlayGameDicision();
                break;
        }
    }
    public void PlayCursol()
    {
        cursol.Play();
    }
    public void PlayMenuDicision()
    {
        menu_dicision.Play();
    }
    public void PlayMenuCancel()
    {
        menu_cancel.Play();
    }
    public void PlayGameDicision()
    {
        game_dicision.Play();
    }
}
