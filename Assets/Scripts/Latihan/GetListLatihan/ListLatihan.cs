using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListLatihan : MonoBehaviour
{
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ListLatihanManager latihanManager;

    private string myTextString;

    public void setText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }
}
