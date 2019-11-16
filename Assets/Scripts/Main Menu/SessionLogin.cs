using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionLogin : MonoBehaviour
{
    
    string id_siswa;
    // Start is called before the first frame update
    void Start()
    {
        id_siswa = PlayerPrefs.GetString("id_siswa");
    }

    public void StartToMenu()
    {
        PlayerPrefs.SetString("id_siswa", id_siswa);
        Application.LoadLevel("Main Menu");
    }

    
}
