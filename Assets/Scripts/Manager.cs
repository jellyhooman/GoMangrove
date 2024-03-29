﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject satu, dua, tiga, satuHitam, duaHitam, tigaHitam,
        btnFinish, btn;

    Vector2 satuInitialPos, duaInitialPos, tigaInitialPos;

    public GameObject check1, check2;

    int score1 = 0;
    int score2 = 0;
    bool firstState = true;
    string Url;

    string id_murid;

    public int hasil;

    public void Start()
    {
        Url = "http://gomangrove.com/backend/api/v1/postNilaiSimulasi";
        satuInitialPos = satu.transform.position;
        duaInitialPos = dua.transform.position;

        id_murid = PlayerPrefs.GetString("id_murid");

        //tigaInitialPos = tiga.transform.position;
        btn = Instantiate(btnFinish) as GameObject;
        btnFinish.SetActive(true);
        btn.transform.SetParent(btnFinish.transform.parent, false);
        Finish();
    }

    public void Update()
    {
        hasil = score1 + score2;
        Debug.Log(hasil);
    }

    public void DragSatu()
    {
        satu.transform.position = Input.mousePosition;
    }

    public void DragDua()
    {
        dua.transform.position = Input.mousePosition;
    }

    //public void DragTiga()
    //{
    //    tiga.transform.position = Input.mousePosition;
    //}

    public void DropSatu() 
    {
        Debug.Log("drop");
        float Distance1 = Vector3.Distance(satu.transform.position, satuHitam.transform.position);
        float Distance2 = Vector3.Distance(satu.transform.position, duaHitam.transform.position);
        //float Distance3 = Vector3.Distance(satu.transform.position, tigaHitam.transform.position);

        if (Distance1 < 50)
        {
            satu.transform.position = satuHitam.transform.position;
            score1 = 20;
        }
        else if (Distance2 < 50)
        {
            satu.transform.position = duaHitam.transform.position;
            score1 = 0;
        }
        //else if (Distance3 < 50)
        //{
        //    satu.transform.position = tigaHitam.transform.position;
        //    score1 = 0;
        //}
        else
        {
            satu.transform.position = satuInitialPos;
        }
    }

    public void DropDua()
    {
        Debug.Log("drop");
        float Distance1 = Vector3.Distance(dua.transform.position, satuHitam.transform.position);
        float Distance2 = Vector3.Distance(dua.transform.position, duaHitam.transform.position);
        //float Distance3 = Vector3.Distance(dua.transform.position, tigaHitam.transform.position);

        if (Distance1 < 50)
        {
            dua.transform.position = satuHitam.transform.position;
            score2 = 0;
            
        }
        else if (Distance2 < 50)
        {
            dua.transform.position = duaHitam.transform.position;
            score2 = 20;
        }
        //else if (Distance3 < 50)
        //{
        //    dua.transform.position = tigaHitam.transform.position;
        //    score2 = 0;
        //}
        else
        {
            dua.transform.position = duaInitialPos;
        }
    }

    public void DropTiga()
    {
        float Distance = Vector3.Distance(tiga.transform.position, tigaHitam.transform.position);
        if (Distance < 50)
        {
            tiga.transform.position = tigaHitam.transform.position;
        }
        else
        {
            tiga.transform.position = tigaInitialPos;
        }
    }

    public void Finish()
    {
        btn.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(hasil));
    }

    public void OnButtonClick(int score)
    {
        firstState = false;
        Application.LoadLevel("LevelSimulasi");
        PostData(id_murid, "Level Simulasi 1", score);
    }

    void PostData(string id_murid, string nama_simulasi, int score)
    {
        WWWForm dataParameters = new WWWForm();
        dataParameters.AddField("id_murid", id_murid);
        dataParameters.AddField("nama_simulasi", nama_simulasi);
        dataParameters.AddField("score_simulasi", score);
        WWW www = new WWW(Url, dataParameters);
        StartCoroutine("PostdataEnumerator", Url);
    }

}
