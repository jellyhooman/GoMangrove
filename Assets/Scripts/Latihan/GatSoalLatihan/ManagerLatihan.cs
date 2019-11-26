using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using LitJson;

public class ManagerLatihan : MonoBehaviour
{
    bool stopScript = true;

    int arrsize;
    int count = 0;

    public Text getSoal, getJawaban1, getJawaban2, getJawaban3, getJawaban4, getJawabanB;

    GameObject btn1, btn2, btn3, btn4;
    public GameObject btnTemp1, btnTemp2, btnTemp3, btnTemp4;

    JsonData stateData;
    Latihan mGetLatihan, mArrayLatihan;

    string id_latihan;
    string id_murid;

    string isiSoal;
    string id_soal;
    string jawaban_1;
    string jawaban_2;
    string jawaban_3;
    string jawaban_4;
    string jawaban_B;
    int scoreLatihan;

    string url_post = "http://gomangrove.com/backend/api/v1/postNilaiLatihan";

    IEnumerator RetriveData()
    {
        string url = "http://gomangrove.com/backend/api/v1/getLatihan?id_latihan=" +id_latihan;
        WWW www = new WWW(url);
        yield return www;
        

        if(www.error == null)
        {
            mGetLatihan = JsonUtility.FromJson<Latihan>(www.text);
            mArrayLatihan = JsonUtility.FromJson<Latihan>(www.text);

            arrsize = mGetLatihan.soal.Count;
            if (count < arrsize)
            {
                id_soal = mGetLatihan.soal[count].idSoal;
                isiSoal = mGetLatihan.soal[count].isi_soal;
                jawaban_1 = mGetLatihan.soal[count].jawaban_1;
                jawaban_2 = mGetLatihan.soal[count].jawaban_2;
                jawaban_3 = mGetLatihan.soal[count].jawaban_3;
                jawaban_4 = mGetLatihan.soal[count].jawaban_4;
                jawaban_B = mGetLatihan.soal[count].jawaban_benar;
                scoreLatihan = mGetLatihan.soal[count].point;

                getSoal.text = isiSoal;

                FunctionButtonChange(jawaban_1, jawaban_2, jawaban_3, jawaban_4);

                FunctionClickedButton(jawaban_1, jawaban_2, jawaban_3, jawaban_4, jawaban_B);
            }
            else if (count == arrsize)
            {
                Application.LoadLevel("Main Menu");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        id_murid = PlayerPrefs.GetString("id_murid");
        id_latihan = PlayerPrefs.GetString("id_latihan");

        btn1 = Instantiate(btnTemp1) as GameObject;
        btn1.SetActive(true);
        
        btn2 = Instantiate(btnTemp2) as GameObject;
        btn2.SetActive(true);
        
        btn3 = Instantiate(btnTemp3) as GameObject;
        btn3.SetActive(true);

        btn4 = Instantiate(btnTemp4) as GameObject;
        btn4.SetActive(true);
        StartCoroutine(RetriveData());
    }

    void Update()
    {
      
    }

    void FunctionButtonChange(string jawaban1, string jawaban2, string jawaban3, string jawaban4)
    {
        btn1.GetComponent<ManagerText>().setJawban1(jawaban1);
        btn1.transform.SetParent(btnTemp1.transform.parent, false);
        btn2.GetComponent<ManagerText>().setJawban2(jawaban2);
        btn2.transform.SetParent(btnTemp2.transform.parent, false);
        btn3.GetComponent<ManagerText>().setJawban3(jawaban3);
        btn3.transform.SetParent(btnTemp3.transform.parent, false);
        btn4.GetComponent<ManagerText>().setJawban4(jawaban4);
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

    public void ButtonJ1()
    {
        StartCoroutine(RetriveData());
    }


    void FunctionCheckAnswer(string jawaban, string jawabanBenar, int i)
    {
        Debug.Log(count);

        if (jawaban == jawabanBenar && stopScript == true)
        {
            getSoal.text = isiSoal;
            FunctionButtonChange(jawaban_1, jawaban_2, jawaban_3, jawaban_4);
            PostData(id_murid, id_latihan, id_soal, jawaban, scoreLatihan);
            count = count + i;
            stopScript = false;
        }
        else if (jawaban != jawabanBenar && stopScript == true)
        {
            getSoal.text = isiSoal;
            FunctionButtonChange(jawaban_1, jawaban_2, jawaban_3, jawaban_4);
            PostData(id_murid, id_latihan, id_soal, jawaban, 0);
            count = count + i;
            stopScript = false;
        }
        else if (count == arrsize)
        {
            Application.LoadLevel("Main Menu");
        }
    }

    
    void PostData(string id_murid, string id_latihan, string id_soal, string jawaban_murid, int score_murid)
    {
        WWWForm dataParameters = new WWWForm();
        dataParameters.AddField("id_murid", id_murid);
        dataParameters.AddField("id_latihan", id_latihan);
        dataParameters.AddField("id_soal", id_soal);
        dataParameters.AddField("jawaban_murid", jawaban_murid);
        dataParameters.AddField("score_murid", score_murid);
        WWW www = new WWW(url_post, dataParameters);
        StartCoroutine("PostdataEnumerator", url_post);
    }

    IEnumerator PostdataEnumerator(WWW www)
    {
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Data Submitted");
            Debug.Log(www.text);
        }
        else
        {
            Debug.Log(www.error);
        }
    }


}
