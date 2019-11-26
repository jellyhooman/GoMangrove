using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class GameLevel : MonoBehaviour
{
    public Button btnLevel1, btnLevel2, btnLevel3;

    public Text hasilA;

    public int nilaiS_1, nilaiS_2, nilaiS_3;
    bool conLevel = false;
    bool conLeve2 = false;
    bool conLeve3 = false;

    int resultScore1;

    JsonData stateData;

    GetNilaiSimulasi mGetNilaiSimulasi;
    string id_murid;

    int sLvl1;

    // Start is called before the first frame update
    void Start()
    {
        id_murid = PlayerPrefs.GetString("id_murid");
        btnLevel2.interactable = false;
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
            sLvl1 = mGetNilaiSimulasi.nilaiSimulasi[0].score_simulasi;
            hasilA.text = sLvl1.ToString();

            LevelGame(sLvl1);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelGame(int score1)
    {

        if (score1 == 0 || score1 == null)
        {
            btnLevel2.interactable = false;
        }
        else
        {
            btnLevel2.interactable = true;
        }
        
    }

    public void BtnLevel2()
    {
        Debug.Log("asdasd");
    }

}
