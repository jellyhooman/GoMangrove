using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using LitJson;

public class ManagerLatihan : MonoBehaviour
{
    bool stopScript = true;

    string[] arrSoal = new string[] { "Soal1", "Soal2","Soal3", "Soal4" };

    string[] arrJwb1 = new string[] { "A", "D", "B", "B" };
    string[] arrJwb2 = new string[] { "B", "C", "A", "B" };
    string[] arrJwb3 = new string[] { "C", "A", "D", "B" };
    string[] arrJwb4 = new string[] { "D", "B", "C", "B" };
    string[] arrJwbB = new string[] { "A", "C", "D", "B" };
    int[] arrScore = new int[] { 20,30 };

    int arrsize;
    int count = 0;

    public Text getSoal, getJawaban1, getJawaban2, getJawaban3, getJawaban4, getJawabanB;

    GameObject btn1, btn2, btn3, btn4;
    public GameObject btnTemp1, btnTemp2, btnTemp3, btnTemp4;

    // Start is called before the first frame update
    void Start()
    {
        btn1 = Instantiate(btnTemp1) as GameObject;
        btn1.SetActive(true);
        
        btn2 = Instantiate(btnTemp2) as GameObject;
        btn2.SetActive(true);
        
        btn3 = Instantiate(btnTemp3) as GameObject;
        btn3.SetActive(true);

        btn4 = Instantiate(btnTemp4) as GameObject;
        btn4.SetActive(true);

        arrsize = arrSoal.Length;
    }

    private void Update()
    {
        if(count < arrsize)
        {
            string isiSoal = arrSoal[count];
            string jawaban_1 = arrJwb1[count];
            string jawaban_2 = arrJwb2[count];
            string jawaban_3 = arrJwb3[count];
            string jawaban_4 = arrJwb4[count];
            string jawaban_B = arrJwbB[count];
            getSoal.text = isiSoal;

            FunctionButtonChange(count);

            FunctionClickedButton(jawaban_1, jawaban_2, jawaban_3, jawaban_4, jawaban_B);
        } else if (count == arrsize)
        {
            Application.LoadLevel("Main Menu");
        }
        
    }

    void FunctionButtonChange(int number)
    {
        btn1.GetComponent<ManagerText>().setJawban1(arrJwb1[number]);
        btn1.transform.SetParent(btnTemp1.transform.parent, false);
        btn2.GetComponent<ManagerText>().setJawban2(arrJwb2[number]);
        btn2.transform.SetParent(btnTemp2.transform.parent, false);
        btn3.GetComponent<ManagerText>().setJawban3(arrJwb3[number]);
        btn3.transform.SetParent(btnTemp3.transform.parent, false);
        btn4.GetComponent<ManagerText>().setJawban4(arrJwb4[number]);
        btn4.transform.SetParent(btnTemp4.transform.parent, false);
    }
   

    void FunctionClickedButton(string jawaban1, string jawaban2, string jawaban3, string jawaban4, string jawabanB)
    {
        stopScript = true;
        btn1.gameObject.GetComponent<Button>().onClick.AddListener(() => FunctionCheckAnswer(jawaban1, jawabanB, 1));
        btn2.gameObject.GetComponent<Button>().onClick.AddListener(() => FunctionCheckAnswer(jawaban2, jawabanB, 1));
        btn3.gameObject.GetComponent<Button>().onClick.AddListener(() => FunctionCheckAnswer(jawaban3, jawabanB, 1));
        btn4.gameObject.GetComponent<Button>().onClick.AddListener(() => FunctionCheckAnswer(jawaban4, jawabanB, 1));
    }
    
    void FunctionCheckAnswer(string jawaban, string jawabanBenar, int i)
    {
        Debug.Log(count);
       
        if (jawaban == jawabanBenar && stopScript == true)
        {
            getSoal.text = arrSoal[count];
            FunctionButtonChange(count);
            count = count + i;
            stopScript = false;
        }
        else if (jawaban != jawabanBenar && stopScript == true)
        {
            getSoal.text = arrSoal[count];
            FunctionButtonChange(count);
            count = count + i;
            stopScript = false;
        }
        else if (count == arrsize)
        {
            Application.LoadLevel("Main Menu");
        }
    }


}
