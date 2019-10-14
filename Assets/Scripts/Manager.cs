using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject satu, dua, tiga, satuHitam, duaHitam, tigaHitam;

    Vector2 satuInitialPos, duaInitialPos, tigaInitialPos;
    
    void Start()
    {
        satuInitialPos = satu.transform.position;
        duaInitialPos = dua.transform.position;
        tigaInitialPos = tiga.transform.position;
    }

    public void DragSatu()
    {
        Debug.Log("one");
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
        float Distance = Vector3.Distance(satu.transform.position, satuHitam.transform.position);
        if (Distance < 50)
        {
            Debug.Log("drop true");
            satu.transform.position = satuHitam.transform.position;
        } else
        {
            Debug.Log("drop false");
            satu.transform.position = satuInitialPos;
        }
    }

    public void DropDua()
    {
        float Distance = Vector3.Distance(dua.transform.position, duaHitam.transform.position);
        if (Distance < 50)
        {
            dua.transform.position = duaHitam.transform.position;
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
}
