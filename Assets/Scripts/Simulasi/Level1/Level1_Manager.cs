using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class Level1_Manager : MonoBehaviour
{
    public GameObject ular, ikanKecil, ikanBesar, serasah, burung;
    public GameObject dropUlar, dropIkanKecil, dropIkanBesar, dropSerasah, dropBurung;
    public GameObject btnSelesai;
    GameObject btn;

    Vector2 ularInitialPos, ikanKecilInitialPos, ikanBesarInitialPos, serasahInitialPos, burungInitialPos;

    int scoreUlar, scoreIkanKecil, scoreIkanBesar, scoreSerasah, scoreBurung = 0;
    int hasilScore;

    string codeUlar, codeIkanK, codeIkanB, codeSerasah, codeBurung;
    string Url = "http://gomangrove.com/backend/api/v1/postNilaiSimulasi";
    string id_murid;

    public Text textTimer;
    float timeLeft = 120.0f;


    // Start is called before the first frame update
    void Start()
    {
        codeUlar = "codeUlar";
        codeIkanK = "codeIkanK";
        codeIkanB = "codeIkanB";
        codeSerasah = "codeSerasah";
        codeBurung = "codeBurung";

        ularInitialPos = ular.transform.position;
        ikanKecilInitialPos = ikanKecil.transform.position;
        ikanBesarInitialPos = ikanBesar.transform.position;
        serasahInitialPos = serasah.transform.position;
        burungInitialPos = burung.transform.position;

        id_murid = PlayerPrefs.GetString("id_murid");

        btn = Instantiate(btnSelesai) as GameObject;
        btnSelesai.SetActive(true);
        btn.transform.SetParent(btnSelesai.transform.parent, false);
        Finish();
    }

     //Update is called once per frame
    void Update()
    {
        hasilScore = scoreUlar + scoreIkanKecil + scoreIkanBesar + scoreSerasah + scoreBurung;
        timeLeft -= Time.deltaTime;
        textTimer.text = ((timeLeft).ToString("0"));
        if (timeLeft < 0)
        {
            //Game OVer
        }
        
    }

    public void DragUlar()
    {
        ular.transform.position = Input.mousePosition;
    }

    public void DragIkanKecil()
    {
        ikanKecil.transform.position = Input.mousePosition;
    }

    public void DragIkanBesar()
    {
        ikanBesar.transform.position = Input.mousePosition;
    }

    public void DragSerasah()
    {
        serasah.transform.position = Input.mousePosition;
    }
    
    public void DragBurung()
    {
        burung.transform.position = Input.mousePosition;
    }

    void RawScore(string initial, int value)
    {
        if (initial == codeUlar)
        {
            scoreUlar = value;
        }
        else if (initial == codeIkanK)
        {
            scoreIkanKecil = value;
        }
        else if (initial == codeIkanB)
        {
            scoreIkanBesar = value;
        }
        else if (initial == codeSerasah)
        {
            scoreSerasah = value;
        }
        else if (initial == codeBurung)
        {
            scoreBurung = value;
        }
    }

    void RawDropObject(Vector2 initialVector ,GameObject initial, string codeName, int scoreUlar, int scoreIkanK, int scoreIkanB, int scoreSerasah, int scoreBurung)
    {
        float Distance1 = Vector3.Distance(initial.transform.position, dropUlar.transform.position);
        float Distance2 = Vector3.Distance(initial.transform.position, dropIkanKecil.transform.position);
        float Distance3 = Vector3.Distance(initial.transform.position, dropIkanBesar.transform.position);
        float Distance4 = Vector3.Distance(initial.transform.position, dropSerasah.transform.position);
        float Distance5 = Vector3.Distance(initial.transform.position, dropBurung.transform.position);

        if (Distance1 < 50)
        {
            initial.transform.position = dropUlar.transform.position;
            RawScore(codeName, scoreUlar);
        }
        else if (Distance2 < 50)
        {
            initial.transform.position = dropIkanKecil.transform.position;
            RawScore(codeName, scoreIkanK);
        }
        else if (Distance3 < 50)
        {
            initial.transform.position = dropIkanBesar.transform.position;
            RawScore(codeName, scoreIkanB);

        }
        else if (Distance4 < 50)
        {
            initial.transform.position = dropSerasah.transform.position;
            RawScore(codeName, scoreSerasah);
        }
        else if (Distance5 < 50)
        {
            initial.transform.position = dropBurung.transform.position;
            RawScore(codeName, scoreBurung);
        }
        else
        {
            initial.transform.position = initialVector;
        }
    }

    public void DropUlar()
    {
        RawDropObject(ularInitialPos, ular, codeUlar, 10, 0, 0, 0, 0);
    }

    public void DropIkanKecil()
    {
        RawDropObject(ikanKecilInitialPos, ikanKecil, codeIkanK, 0, 10, 0, 0, 0);
    }

    public void DropIkanBesar()
    {
        RawDropObject(ikanBesarInitialPos, ikanBesar, codeIkanB, 0, 0, 10, 0, 0);
    }

    public void DropSerasah()
    {
        RawDropObject(serasahInitialPos, serasah, codeSerasah, 0, 0, 0, 10, 0);
    }

    public void DropBurung()
    {
        RawDropObject(burungInitialPos, burung, codeBurung, 0, 0, 0, 0, 10);
    }

    public void Finish()
    {
        btn.gameObject.GetComponent<Button>().onClick.AddListener(() => ClickButtonFinish(hasilScore));
    }

    void ClickButtonFinish(int score)
    {
        PostData(id_murid, "Level Simulasi 1", score);
        if (score > 10)
        {
            PlayerPrefs.SetInt("nilai_simulasi", score);
            Application.LoadLevel("VictoryScene");
        } else if ( score <= 10)
        {
            PlayerPrefs.SetInt("nilai_simulasi", score);
            Application.LoadLevel("FailedScene");
        }
        
    }

    void PostData(string id_murid, string nama_simulasi, int score)
    {
        WWWForm dataParameters = new WWWForm();
        dataParameters.AddField("id_murid", id_murid);
        dataParameters.AddField("nama_simulasi", nama_simulasi);
        dataParameters.AddField("score_simulasi", score);
        WWW www = new WWW(Url, dataParameters);
    }
}
