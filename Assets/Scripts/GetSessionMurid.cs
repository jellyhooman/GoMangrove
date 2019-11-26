using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSessionMurid : MonoBehaviour
{
    string id_murid;

    // Start is called before the first frame update
    void Start()
    {
        id_murid = PlayerPrefs.GetString("id_murid");
        PlayerPrefs.SetString("id_murid", id_murid);
        Debug.Log("masuk id");
        Debug.Log("id_murid : "+id_murid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
