using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Button : MonoBehaviour
{
    //Setting Right
    public Image changeIconMusic, changeIconSound;
    public Sprite iconMusicOn, iconSoundOn, iconMusicOff, iconSoundOff;

    string id_murid;

    private bool conMusic = true;
    private bool conSound = true;

    //Setting Left
    public Image slideBot;
    public Sprite iconSlideBot, iconSlideTop;

    private bool conSlide = true;

    //----------------------------------------------------

    public void Start()
    {
        id_murid = PlayerPrefs.GetString("id_murid");
    }

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
        PlayerPrefs.SetString("id_murid", id_murid);
        Application.LoadLevel("Menu Konten");
    }

    public void btnToMateri()
    {
        PlayerPrefs.SetString("id_murid", id_murid);
        Application.LoadLevel("ListMateriScene");
    }

    public void btnToSimulasi()
    {
        PlayerPrefs.SetString("id_murid", id_murid);
        Application.LoadLevel("LevelSimulasi");
    }

    public void btnToLevel1()
    {
        PlayerPrefs.SetString("id_murid", id_murid);
        Application.LoadLevel("Level1");
    }

    public void btnToLatihan()
    {
        Application.LoadLevel("ListLatihanScene");
    }

}
