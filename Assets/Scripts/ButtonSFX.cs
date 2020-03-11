using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip clickFX;

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFX);
    }
}
