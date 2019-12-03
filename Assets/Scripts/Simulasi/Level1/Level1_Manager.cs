using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class Level1_Manager : MonoBehaviour
{
    public GameObject kepiting, ikanKecil, ikanBesar, biyawak, dekomposer, burung;
    public GameObject dropKepiting, dropIkanKecil, dropIkanBesar, dropBiyawak, dropDekomposer, dropBurung;
    public GameObject btnSelesai;
    GameObject btn;

    Vector2 kepitingInitialPos, ikanKecilInitialPos, ikanBesarInitialPos, biyawakInitialPos, dekomposerInitialPos, burungInitialPos;

    int scorekepiting, scoreIkanKecil, scoreIkanBesar, scoreBiyawak, scoreDekomposer, scoreBurung = 0;
    int hasilScore;

    string codeKepiting, codeIkanK, codeIkanB, codeBiyawak, codeDekomposer, codeBurung;
    string Url = "http://gomangrove.com/backend/api/v1/postNilaiSimulasi";
    string id_murid;

    public Text textTimer;
    float timeLeft = 120.0f;


    // Start is called before the first frame update
    void Start()
    {
        codeKepiting = "codeKepiting";
        codeIkanK = "codeIkanK";
        codeIkanB = "codeIkanB";
        codeBiyawak = "codeBiyawak";
        codeDekomposer = "codeDekomposer";
        codeBurung = "codeBurung";

        kepitingInitialPos = kepiting.transform.position;
        ikanKecilInitialPos = ikanKecil.transform.position;
        ikanBesarInitialPos = ikanBesar.transform.position;
        biyawakInitialPos = biyawak.transform.position;
        dekomposerInitialPos = dekomposer.transform.position;
        burungInitialPos = burung.transform.position;

        id_murid = PlayerPrefs.GetString("id_murid");

        btn = Instantiate(btnSelesai) as GameObject;
        btnSelesai.SetActive(true);
        btn.transform.SetParent(btnSelesai.transform.parent, false);
        Finish();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        textTimer.text = ((timeLeft).ToString("0"));
        if (timeLeft < 0)
        {
            //Game OVer
        }
    }

    public void DragKepiting()
    {
        kepiting.transform.position = Input.mousePosition;
    }

    public void DragIkanKecil()
    {
        ikanKecil.transform.position = Input.mousePosition;
    }

    public void DragIkanBesar()
    {
        ikanBesar.transform.position = Input.mousePosition;
    }

    public void DragBiyawak()
    {
        biyawak.transform.position = Input.mousePosition;
    }

    public void DragDekomposer()
    {
        dekomposer.transform.position = Input.mousePosition;
    }

    public void DragBurung()
    {
        burung.transform.position = Input.mousePosition;
    }

    void RawScore(string initial, int value)
    {
        if (initial == codeKepiting)
        {
            scorekepiting = value;
        }
        else if (initial == codeIkanK)
        {
            scoreIkanKecil = value;
        }
        else if (initial == codeIkanB)
        {
            scoreIkanBesar = value;
        }
        else if (initial == codeBiyawak)
        {
            scoreBiyawak = value;
        }
        else if (initial == codeDekomposer)
        {
            scoreDekomposer = value;
        }
        else if (initial == codeBurung)
        {
            scoreBurung = value;
        }
    }

    void RawDropObject(Vector2 initialVector ,GameObject initial, string codeName, int scoreKepiting, int scoreIkanK, int scoreIkanB, int scoreBiyawak, int scoreDekomposer, int scoreBurung)
    {
        float Distance1 = Vector3.Distance(initial.transform.position, dropKepiting.transform.position);
        float Distance2 = Vector3.Distance(initial.transform.position, dropIkanKecil.transform.position);
        float Distance3 = Vector3.Distance(initial.transform.position, dropIkanBesar.transform.position);
        float Distance4 = Vector3.Distance(initial.transform.position, dropBiyawak.transform.position);
        float Distance5 = Vector3.Distance(initial.transform.position, dropDekomposer.transform.position);
        float Distance6 = Vector3.Distance(initial.transform.position, dropBurung.transform.position);

        if (Distance1 < 50)
        {
            initial.transform.position = dropKepiting.transform.position;
            RawScore(codeName, scoreKepiting);
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
            initial.transform.position = dropBiyawak.transform.position;
            RawScore(codeName, scoreBiyawak);
        }
        else if (Distance5 < 50)
        {
            initial.transform.position = dropDekomposer.transform.position;
            RawScore(codeName, scoreDekomposer);
        }
        else if (Distance6 < 50)
        {
            initial.transform.position = dropBurung.transform.position;
            RawScore(codeName, scoreBurung);
        }
        else
        {
            initial.transform.position = initialVector;
        }
    }

    public void DropKepiting()
    {
        RawDropObject(kepitingInitialPos, kepiting, codeKepiting, 10, 0, 0, 0, 0, 0);
    }

    public void DropIkanKecil()
    {
        RawDropObject(ikanKecilInitialPos, ikanKecil, codeIkanK, 0, 10, 0, 0, 0, 0);
    }

    public void DropIkanBesar()
    {
        RawDropObject(ikanBesarInitialPos, ikanBesar, codeIkanB, 0, 0, 10, 0, 0, 0);
    }

    public void DropBiyawak()
    {
        RawDropObject(biyawakInitialPos, biyawak, codeBiyawak, 0, 0, 0, 10, 0, 0);
    }

    public void DropDekomposer()
    {
        RawDropObject(dekomposerInitialPos, dekomposer, codeDekomposer, 0, 0, 0, 0, 10, 0);
    }

    public void DropBurung()
    {
        RawDropObject(burungInitialPos, burung, codeBurung, 0, 0, 0, 0, 0, 10);
    }

    public void Finish()
    {
        hasilScore = scorekepiting + scoreIkanKecil + scoreIkanBesar + scoreBiyawak + scoreDekomposer + scoreBurung;
        btn.gameObject.GetComponent<Button>().onClick.AddListener(() => ClickButtonFinish(hasilScore));
    }

    void ClickButtonFinish(int score)
    {
        PostData(id_murid, "Level Simulasi 1", score);
        Debug.Log("hasil : " + hasilScore);
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
