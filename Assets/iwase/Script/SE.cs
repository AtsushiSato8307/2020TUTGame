using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{   
    public AudioSource SEaudiosource;
    public AudioClip sound1;
    public AudioClip sound2;
    

    // Start is called before the first frame update
    void Start()
    {
        SEaudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {//SE再生条件
       if (Input.GetKeyDown(KeyCode.C)) {SEaudiosource.PlayOneShot(sound1); }
       if (Input.GetKeyDown(KeyCode.B)) {SEaudiosource.PlayOneShot(sound2); }
    }
    public void PlaySe(int num)
    {
        if (num == 0)
        {
            SEaudiosource.PlayOneShot(sound1);
        }
        else if (num == 1)
        {
            SEaudiosource.PlayOneShot(sound2);
        }
    }
}
