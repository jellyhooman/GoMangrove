using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class GameLevel : MonoBehaviour
{
    public Button btnLevel1, btnLevel2, btnLevel3;

    public Text text_Level1, text_Level2, text_Level3;
    public Text totalLevel1, totalLevel2, totalLevel3;

    public int nilaiS_1, nilaiS_2, nilaiS_3;
    bool conLevel = false;
    bool conLeve2 = false;
    bool conLeve3 = false;

    int resultScore1;

    JsonData stateData;

    GetNilaiSimulasi mGetNilaiSimulasi;
    string id_murid;

    //unlock level
    int sLvl1 = -1;
    int sLvl2 = -1;
    int sLvl3 = -1;

    int scorelevel1;
    int scorelevel2;
    int scorelevel3;

    // Start is called before the first frame update
    void Start()
    {
        id_murid = PlayerPrefs.GetString("id_murid");
        PlayerPrefs.SetString("id_murid", id_murid);
        Debug.Log(id_murid);
        totalLevel1.text = "/100";
        totalLevel2.text = "/100";
        totalLevel3.text = "/100";
        btnLevel2.interactable = false;
        btnLevel3.interactable = false;
        StartCoroutine(RetriveData());
    }

    // Sample JSON for the following script has attached.
    IEnumerator RetriveData()
    {
        string url = "http://gomangrove.com/backend/api/v1/getNilaiSimulasi?id_murid=" + id_murid;
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            mGetNilaiSimulasi = JsonUtility.FromJson<GetNilaiSimulasi>("{\"nilaiSimulasi\":" + www.text + "}");
            int array = mGetNilaiSimulasi.nilaiSimulasi.Count;

            scorelevel1 = mGetNilaiSimulasi.nilaiSimulasi[0].score_simulasi;
            sLvl1 = mGetNilaiSimulasi.nilaiSimulasi[0].score_simulasi;
            ConditionLevel1(sLvl1);
            TextLevel(sLvl1, text_Level1);
            StatusVariableL1(sLvl1);
            StatusVariableL2(sLvl2);
            StatusVariableL3(sLvl3);

            scorelevel2 = mGetNilaiSimulasi.nilaiSimulasi[1].score_simulasi;
            sLvl2 = mGetNilaiSimulasi.nilaiSimulasi[1].score_simulasi;
            ConditionLevel2(sLvl2);
            TextLevel(sLvl2, text_Level2);
            StatusVariableL1(sLvl1);
            StatusVariableL2(sLvl2);
            StatusVariableL3(sLvl3);

            scorelevel3 = mGetNilaiSimulasi.nilaiSimulasi[2].score_simulasi;
            sLvl3 = mGetNilaiSimulasi.nilaiSimulasi[2].score_simulasi;
            TextLevel(sLvl3, text_Level3);
            StatusVariableL1(sLvl1);
            StatusVariableL2(sLvl2);
            StatusVariableL3(sLvl3);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
            PlayerPrefs.SetString("status_lvl1", "null");
        }
    }
    
    void StatusVariableL1(int score1)
    {
        if (score1 < 0 || score1 == null)
        {
            PlayerPrefs.SetString("status_lvl1", "null");
            PlayerPrefs.SetInt("nilai_lvl1", scorelevel1);
            Debug.Log("state null");
        }
        else if (score1 >= 0)
        {
            PlayerPrefs.SetString("status_lvl1", "not_null");
            PlayerPrefs.SetInt("nilai_lvl1", scorelevel1);
            Debug.Log("state not_null");
        }
    }

    void StatusVariableL2(int score2)
    {
        if (score2 == null || score2 < 0)
        {
            PlayerPrefs.SetString("status_lvl2", "null");
            PlayerPrefs.SetInt("nilai_lvl2", scorelevel2);
            Debug.Log("state null");
        }
        else if (score2 >= 0)
        {
            PlayerPrefs.SetString("status_lvl2", "not_null");
            PlayerPrefs.SetInt("nilai_lvl2", scorelevel2);
            Debug.Log("state not_null");
        }
    }

    void StatusVariableL3(int score3)
    {
        if (score3 == null || score3 < 0)
        {
            PlayerPrefs.SetString("status_lvl3", "null");
            PlayerPrefs.SetInt("nilai_lvl3", scorelevel3);
            Debug.Log("state null");
        }
        else if (score3 >= 0)
        {
            PlayerPrefs.SetString("status_lvl3", "not_null");
            PlayerPrefs.SetInt("nilai_lvl3", scorelevel3);
            Debug.Log("state not_null");
        }
    }

    
    void TextLevel(int score, Text teks)
    {
        if (score == null)
        {
            teks.text = "0";
        } else if (score >= 0)
        {
            teks.text = score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelGame(int score1, int score2, int score3)
    {
        ConditionLevel1(score1);
        ConditionLevel2(score2);
        ConditionLevel3(score3);
        
    }

    void ConditionLevel1(int score1)
    {
        if (score1 <= 59 || score1 == null)
        {
            btnLevel2.interactable = false;
            btnLevel3.interactable = false;
        }
        else
        {
            btnLevel2.interactable = true;
        }
    }

    void ConditionLevel2(int score2)
    {
        if (score2 <= 59 || score2 == null)
        {
            btnLevel3.interactable = false;
        }
        else
        {
            btnLevel3.interactable = true;
        }
    }

    void ConditionLevel3(int score3)
    {

    }

    public void BtnLevel2()
    {
        Debug.Log("asdasd");
    }

}
