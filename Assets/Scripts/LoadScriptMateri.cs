using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScriptMateri : MonoBehaviour
{
    public Text hasilText;

    public GameObject isiMateriObject;
    public ListMateriControl isiMateriScript;

    public void Start()
    {

        hasilText.text = PlayerPrefs.GetString("id");
    }
}
