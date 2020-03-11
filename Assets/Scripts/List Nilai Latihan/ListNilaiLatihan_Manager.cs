using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ListNilaiLatihan_Manager : MonoBehaviour
{
    [SerializeField]
    public GameObject buttonTemplate;

    JsonData stateData;

    string id_murid;

    GetListNilaiLatihan mGetListNilaiLatihan, mArrayNilaiLatihan;

    // Sample JSON for the following script has attached.
    IEnumerator Start()
    {
        id_murid = PlayerPrefs.GetString("id_murid");
        string url = "http://gomangrove.com/backend/api/v1/getNilaiLatihan?id_murid="+id_murid;
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            mGetListNilaiLatihan = JsonUtility.FromJson<GetListNilaiLatihan>("{\"getNilaiLatihan\":" + www.text + "}");
            int arrSize = mGetListNilaiLatihan.getNilaiLatihan.Count;
            
            for (int i = 0; i < arrSize; i++)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ListNilaiLatihan_HelperText>().setTextNamaLatihan(mGetListNilaiLatihan.getNilaiLatihan[i].nama_latihan);
                button.GetComponent<ListNilaiLatihan_HelperText>().setTextScore(mGetListNilaiLatihan.getNilaiLatihan[i].total_score);
                button.transform.SetParent(buttonTemplate.transform.parent, false);


                string mId_latihan = mGetListNilaiLatihan.getNilaiLatihan[i].idLatihan;
                //string mJudul = getMateri.getMateri[i].judul_materi;
                //string mIsi = getMateri.getMateri[i].isi_materi;

                button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(mId_latihan));

            }
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }

    public void OnButtonClick(string id_latihan)
    {
        //PlayerPrefs.SetString("id_latihan", id_latihan);
        //Application.LoadLevel("ExLatihan");
    }
}
