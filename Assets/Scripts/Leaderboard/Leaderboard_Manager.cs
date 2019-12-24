using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class Leaderboard_Manager : MonoBehaviour
{
    [SerializeField]
    public GameObject buttonTemplate;

    JsonData stateData;

    string id_murid;

    GetLeaderboard mGetLeaderboard;

    // Sample JSON for the following script has attached.
    IEnumerator Start()
    {
        id_murid = PlayerPrefs.GetString("id_murid");
        string url = "http://gomangrove.com/backend/api/v1/getScoreLeaderboard";
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            mGetLeaderboard = JsonUtility.FromJson<GetLeaderboard>("{\"getLeaderboard\":" + www.text + "}");
            int arrSize = mGetLeaderboard.getLeaderboard.Count;

            for (int i = 0; i < arrSize; i++)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                button.GetComponent<Leaderboard_HelperText>().setTextNamaLatihan(mGetLeaderboard.getLeaderboard[i].nama);
                button.GetComponent<Leaderboard_HelperText>().setTextScore(mGetLeaderboard.getLeaderboard[i].nilai_akhir);
                button.transform.SetParent(buttonTemplate.transform.parent, false);


                //string mId_latihan = mGetListNilaiLatihan.getNilaiLatihan[i].idLatihan;
                //string mJudul = getMateri.getMateri[i].judul_materi;
                //string mIsi = getMateri.getMateri[i].isi_materi;

                //button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(mId_latihan));

            }
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }

    public void OnButtonClick(string id_latihan)
    {
        PlayerPrefs.SetString("id_latihan", id_latihan);
        Application.LoadLevel("ExLatihan");
    }
}
