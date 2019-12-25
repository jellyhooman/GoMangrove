using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Akun_Manager : MonoBehaviour
{
    public Text textName;
    string name;

    // Start is called before the first frame update
    void Start()
    {
        name = PlayerPrefs.GetString("nama_murid");
        textName.text = name;
    }
    
}
