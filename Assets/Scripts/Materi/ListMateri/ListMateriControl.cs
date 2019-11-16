using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ListMateriControl : MonoBehaviour
{
    [SerializeField]
    public GameObject buttonTemplate;

    string BASE_URL = "http://gomangrove.com/backend/api/v1/getMateri";
    JsonData stateData;
    GetMateri getMateri, getMateriLength;

    // Sample JSON for the following script has attached.
    IEnumerator Start()
    {
        string url = "http://gomangrove.com/backend/api/v1/getMateri";
        WWW www = new WWW(url);
        yield return www;
        
        if (www.error == null)
        {
            getMateri = JsonUtility.FromJson<GetMateri>("{\"getMateri\":" + www.text + "}");
            getMateriLength = JsonUtility.FromJson<GetMateri>("{\"arrayMateri\":" + www.text + "}");
            int arrSize = getMateriLength.arrayMateri.Length;
            for (int i = 0; i < arrSize; i++)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ListMateri>().setText(getMateri.getMateri[i].judul_materi);
                button.transform.SetParent(buttonTemplate.transform.parent, false);

                string mId = getMateri.getMateri[i].id;
                string mJudul = getMateri.getMateri[i].judul_materi;
                string mIsi = getMateri.getMateri[i].isi_materi;

                button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(mId, mJudul, mIsi));
            }

        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
 
    public void OnButtonClick(string mId, string mJudul, string mIsi)
    {
        PlayerPrefs.SetString("id_materi", mId);
        PlayerPrefs.SetString("judul_materi", mJudul);
        PlayerPrefs.SetString("isi_materi", mIsi);
        Application.LoadLevel("ListGetMateriScene");
    }

}
