using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Button : MonoBehaviour
{
    public Image changeIconMusic, changeIconSound;

    public Sprite iconMusicOn, iconSoundOn, iconMusicOff, iconSoundOff;

    private bool conMusic = true;
    private bool conSound = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnMusic()
    {
        if (conMusic == true)
        {
            changeIconMusic.sprite = iconMusicOff;
            conMusic = false;
        } else if (conMusic == false)
        {
            changeIconMusic.sprite = iconMusicOn;
            conMusic = true;
        }
    }

    public void btnSound()
    {
        if (conSound == true)
        {
            changeIconSound.sprite = iconSoundOff;
            conSound = false;
        }
        else if (conSound == false)
        {
            changeIconSound.sprite = iconSoundOn;
            conSound = true;
        }
    }

}
