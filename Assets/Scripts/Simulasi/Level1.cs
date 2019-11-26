using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.Text;

public class Level1 : MonoBehaviour
{

    // Use this for initialization
    string Url;
    void Start()
    {
        Url = "http://gomangrove.com/backend/api/v1/postNilaiSimulasi";
        PostData("3", "Dari Unity Lagi", "30");
    }
    // Update is called once per frame
    void Update()
    {

    }
    void PostData(string Id, string Name, string Score)
    {
        WWWForm dataParameters = new WWWForm();
        dataParameters.AddField("id_murid", Id);
        dataParameters.AddField("nama_simulasi", Name);
        dataParameters.AddField("score_simulasi", Score);
        WWW www = new WWW(Url, dataParameters);
        StartCoroutine("PostdataEnumerator", Url);
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
