using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using SimpleHTTP;

public class Level2_Manager : MonoBehaviour
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

    string statusLevel;

    JsonData stateData;

    GetNilaiSimulasi mGetNilaiSimulasi;
    string mId_simulasi;


    // Start is called before the first frame update
    void Start()
    {
        
        statusLevel = PlayerPrefs.GetString("status_lvl2");
        id_murid = PlayerPrefs.GetString("id_murid");
        
        Debug.Log("start sim " + mId_simulasi);
        Debug.Log("start status  " + statusLevel);
        Debug.Log("start id m" + id_murid);

        StartCoroutine(RetriveData());
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
        hasilScore = scorekepiting + scoreIkanKecil + scoreIkanBesar + scoreBiyawak + scoreDekomposer + scoreBurung;
        timeLeft -= Time.deltaTime;
        textTimer.text = ((timeLeft).ToString("0"));
        if (timeLeft < 0)
        {
            PlayerPrefs.SetInt("nilai_simulasi", 0);
            Application.LoadLevel("FailedScene");
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

    void RawDropObject(Vector2 initialVector, GameObject initial, string codeName, int scoreKepiting, int scoreIkanK, int scoreIkanB, int scoreBiyawak, int scoreDekomposer, int scoreBurung)
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
        btn.gameObject.GetComponent<Button>().onClick.AddListener(() => ClickButtonFinish(hasilScore));
    }

    void ClickButtonFinish(int score)
    {
        Debug.Log("MASUK");
        if (statusLevel == "null")
        {
            PostData(id_murid, "Level Simulasi 2", score);
            StateResult(score);
        }
        else if (statusLevel == "not_null")
        {
            StartCoroutine(Put(mId_simulasi, score));
            StateResult(score);
        }
    }

    void StateResult(int score)
    {
        if (score > 10)
        {
            PlayerPrefs.SetInt("nilai_simulasi", score);
            Application.LoadLevel("VictoryScene");
        }
        else if (score <= 10)
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

    IEnumerator Put(string id, int score)
    {
        // Let's say that this the object you want to create
        PUTNilaiSimulasi put = new PUTNilaiSimulasi(id, "Simulasi Level 2", score);

        // Create the request object and use the helper function `RequestBody` to create a body from JSON
        Request request = new Request("http://gomangrove.com/backend/api/v1/putNilaiSimulasi")
            .Put(RequestBody.From<PUTNilaiSimulasi>(put));

        // Instantiate the client
        Client http = new Client();
        // Send the request
        yield return http.Send(request);

        // Use the response if the request was successful, otherwise print an error
        if (http.IsSuccessful())
        {
            Response resp = http.Response();
            Debug.Log("status: " + resp.Status().ToString() + "\nbody: " + resp.Body());
        }
        else
        {
            Debug.Log("error: " + http.Error());
        }
    }

    IEnumerator RetriveData()
    {
        string url = "http://gomangrove.com/backend/api/v1/getNilaiSimulasi?id_murid=" + id_murid;
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            mGetNilaiSimulasi = JsonUtility.FromJson<GetNilaiSimulasi>("{\"nilaiSimulasi\":" + www.text + "}");
            int array = mGetNilaiSimulasi.nilaiSimulasi.Count;
            Debug.Log("arrays : "+array);
            if (array > 1)
            {
                mId_simulasi = mGetNilaiSimulasi.nilaiSimulasi[1].id;
            } else if (array <= 1) {

            }
            
            Debug.Log("id simulasi :" + mId_simulasi);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
}
