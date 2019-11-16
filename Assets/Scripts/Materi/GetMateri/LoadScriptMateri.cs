using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScriptMateri : MonoBehaviour
{
    public Text judul;
    public Text isi;

    public GameObject isiMateriObject;
    public ListMateriControl isiMateriScript;

    public void Start()
    {
        judul.text = PlayerPrefs.GetString("judul_materi");
        isi.text = PlayerPrefs.GetString("isi_materi");
    }
}
