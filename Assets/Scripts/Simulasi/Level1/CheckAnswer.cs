using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour
{
    public Image changeFinished;
    public Sprite iconFinished;

    public void changeImage()
    {
        changeFinished.sprite = iconFinished;
    }
}
