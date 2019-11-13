using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Button : MonoBehaviour
{
    //Setting Right
    public Image changeIconMusic, changeIconSound;
    public Sprite iconMusicOn, iconSoundOn, iconMusicOff, iconSoundOff;

    private bool conMusic = true;
    private bool conSound = true;

    //Setting Left
    public Image slideBot;
    public Sprite iconSlideBot, iconSlideTop;

    private bool conSlide = true;

    //----------------------------------------------------

    public void btnSlide()
    {
        if (conSlide == true)
        {
            slideBot.sprite = iconSlideTop;
            conSlide = false;
        }
        else if (conSlide == false)
        {
            slideBot.sprite = iconSlideBot;
            conSlide = true;
        }
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

    //Button Back
    public void btnBackToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void btnBackToAkun()
    {
        Application.LoadLevel("Akun Scene");
    }

    //Button Next
    public void btnNextToAkun()
    {
        Application.LoadLevel("Akun Scene");
    }

    public void btnNextToNilaiLatihan()
    {
        Application.LoadLevel("Nilai Latihan Scene");
    }

    public void btnNextToNilaiSimulasi()
    {
        Application.LoadLevel("Nilai Latihan Simulasi");
    }

    public void btnStart()
    {
        Application.LoadLevel("Menu Konten");
    }

    public void btnToMateri()
    {
        Application.LoadLevel("ListMateriScene");
    }

    public void btnToSimulasi()
    {
        Application.LoadLevel("LevelSimulasi");
    }

    public void btnToLevel1()
    {
        Application.LoadLevel("Level1");
    }

}
