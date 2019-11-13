using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject satu, dua, tiga, satuHitam, duaHitam, tigaHitam;

    Vector2 satuInitialPos, duaInitialPos, tigaInitialPos;

    public GameObject check1, check2;

    int score1 = 0;
    int score2 = 0;

    void Start()
    {
        satuInitialPos = satu.transform.position;
        duaInitialPos = dua.transform.position;
        tigaInitialPos = tiga.transform.position;
    }

    public void DragSatu()
    {
        satu.transform.position = Input.mousePosition;
    }

    public void DragDua()
    {
        dua.transform.position = Input.mousePosition;
    }

    public void DragTiga()
    {
        tiga.transform.position = Input.mousePosition;
    }

    public void DropSatu() 
    {
        Debug.Log("drop");
        float Distance1 = Vector3.Distance(satu.transform.position, satuHitam.transform.position);
        float Distance2 = Vector3.Distance(satu.transform.position, duaHitam.transform.position);
        float Distance3 = Vector3.Distance(satu.transform.position, tigaHitam.transform.position);

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
        else if (Distance3 < 50)
        {
            satu.transform.position = tigaHitam.transform.position;
            score1 = 0;
        }
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
        float Distance3 = Vector3.Distance(dua.transform.position, tigaHitam.transform.position);

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
        else if (Distance3 < 50)
        {
            dua.transform.position = tigaHitam.transform.position;
            score2 = 0;
        }
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

    public void btnSelesai()
    {
        int hasil = score1 + score2;
        Debug.Log(hasil);
    }

}
