using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ListMateri : MonoBehaviour
{
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ListMateriControl materiControl;

    private string myTextString;

    public void setText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }
    
}
