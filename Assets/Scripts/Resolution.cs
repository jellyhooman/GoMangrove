using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    //inisialisasi obejk
    public Image changeImage;
    //inisialisasi sprite untuk merubah objek
    public Sprite res1080, res1080x2016, res720, defaultRes;

    void Start()
    {
        if ((Screen.height == 1920 && Screen.width == 1080) || (Screen.height == 1080 && Screen.width == 1920))
        {
            Debug.Log("1080");
            changeImage.sprite = res1080;
        }
        else if ((Screen.height == 1080 && Screen.width == 2160) || (Screen.height == 2160 && Screen.width == 1080))
        {
            Debug.Log("1080x2016");
            changeImage.sprite = res1080x2016;
        }
        else if ((Screen.height == 1280 && Screen.width == 720) || (Screen.height == 720 && Screen.width == 1280))
        {
            Debug.Log("720");
            changeImage.sprite = res720;
        }
        else
        {
            changeImage.sprite = defaultRes;
        }
    }
}
