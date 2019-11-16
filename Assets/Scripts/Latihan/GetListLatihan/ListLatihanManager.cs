using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ListLatihanManager : MonoBehaviour
{
    [SerializeField]
    public GameObject buttonTemplate;

    JsonData stateData;
    //GetLatihan mGetLatihan, mArrayLatihan;
    //List<Latihan> getLatihan = new List<Latihan>();

    GetLatihan mGetLatihan, mArrayLatihan;

    // Sample JSON for the following script has attached.
    IEnumerator Start()
    {
        string url = "http://gomangrove.com/backend/api/v1/getLatihan";
        WWW www = new WWW(url);
        yield return www;
        
        if (www.error == null)
        {
            mGetLatihan = JsonUtility.FromJson<GetLatihan>("{\"getLatihan\":" + www.text + "}");
            mArrayLatihan = JsonUtility.FromJson<GetLatihan>("{\"arrayLatihan\":" + www.text + "}");
            int arrSize = mArrayLatihan.arrayLatihan.Length;

            Debug.Log(mArrayLatihan.arrayLatihan.Length);
            for (int i = 0; i < arrSize; i++)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                
                button.GetComponent<ListLatihan>().setText(mGetLatihan.getLatihan[i].nama_latihan);
                button.transform.SetParent(buttonTemplate.transform.parent, false);

                Debug.Log(i);

                //string mId = getMateri.getMateri[i].id;
                //string mJudul = getMateri.getMateri[i].judul_materi;
                //string mIsi = getMateri.getMateri[i].isi_materi;

                //button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(mId, mJudul, mIsi));
                button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(i));
            }
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }

    public void OnButtonClick(int i)
    {
        //PlayerPrefs.SetString("id_materi", mId);
        //PlayerPrefs.SetString("judul_materi", mJudul);
        //PlayerPrefs.SetString("isi_materi", mIsi);
        //Application.LoadLevel("ListGetMateriScene");
        Debug.Log(i);
    }

    //public void OnButtonClick(string mId, string mJudul, string mIsi)
    //{
    //    PlayerPrefs.SetString("id_materi", mId);
    //    PlayerPrefs.SetString("judul_materi", mJudul);
    //    PlayerPrefs.SetString("isi_materi", mIsi);
    //    Application.LoadLevel("ListGetMateriScene");
    //}
}
