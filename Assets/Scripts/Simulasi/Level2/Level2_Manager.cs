using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using SimpleHTTP;

public class Level2_Manager : MonoBehaviour
{
    string CHECK_TRUE = "check_true";
    string CHECK_FALSE = "check_false";

    public Animator kepitingAnim, ikankAnim, ikanbAnim, biyawakAnim, dekomposerAnim, burungAnim;

    public GameObject kepiting, ikanKecil, ikanBesar, biyawak, dekomposer, burung;
    public GameObject dropKepiting, dropIkanKecil, dropIkanBesar, dropBiyawak, dropDekomposer, dropBurung;
    public GameObject btnSelesai;
    public GameObject disableAllButton;
    GameObject btn;

    Vector2 kepitingInitialPos, ikanKecilInitialPos, ikanBesarInitialPos, biyawakInitialPos, dekomposerInitialPos, burungInitialPos;

    int scorekepiting, scoreIkanKecil, scoreIkanBesar, scoreBiyawak, scoreDekomposer, scoreBurung = 0;
    int hasilScore;
    float scoreSoal = 16.666667f;

    string codeKepiting, codeIkanK, codeIkanB, codeBiyawak, codeDekomposer, codeBurung;
    string checkAnswerKepiting, checkAnswerIkanK, checkAnswerIkanB, checkAnswerBiyawak, checkAnswerBurung, checkAnswerDekomposer, checkAnswer;
    string answerKepiting, answerIkanK, answerIkanB, answerDekomposer, answerBurung, answerBiyawak;
    int statAnswer;

    string Url = "http://gomangrove.com/backend/api/v1/postNilaiSimulasi";
    string id_murid;

    public Text textTimer;
    float timeLeft = 120.0f;
    float targetTime1 = 1f;
    float targetTime2 = 2.30f;
    float targetTime3 = 3.60f;
    float targetTime4 = 4.90f;
    float targetTime5 = 6.20f;
    float targetTime6 = 7.50f;
    bool timerIsActive = true;
    int allFinished = 0;

    string statusLevel;

    JsonData stateData;

    GetNilaiSimulasi mGetNilaiSimulasi;
    string mId_simulasi;


    // Start is called before the first frame update
    void Start()
    {
        disableAllButton.SetActive(false);

        statusLevel = PlayerPrefs.GetString("status_lvl2");
        id_murid = PlayerPrefs.GetString("id_murid");

        kepitingAnim = dropKepiting.GetComponent<Animator>();
        burungAnim = dropBurung.GetComponent<Animator>();
        ikanbAnim = dropIkanBesar.GetComponent<Animator>();
        ikankAnim = dropIkanKecil.GetComponent<Animator>();
        dekomposerAnim = dropDekomposer.GetComponent<Animator>();
        biyawakAnim = dropBiyawak.GetComponent<Animator>();

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

        answerKepiting = "check_kepiting";
        answerIkanK = "check_ikank";
        answerIkanB = "check_ikanb";
        answerDekomposer = "check_dekomposer";
        answerBurung = "check_burung";
        answerBiyawak = "check_biyawak";
        statAnswer = 0;

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

        if (timerIsActive)
        {
            timeLeft -= Time.deltaTime;
            textTimer.text = ((timeLeft).ToString("0"));
            if (timeLeft <= 0)
            {
                PlayerPrefs.SetInt("nilai_simulasi", 0);
                Application.LoadLevel("FailedScene");
            }
        }
        else if (statAnswer == 1)
        {
            allFinished = 1;
            string answer_1 = "check_kepiting";
            string answer_2 = "check_ikank";
            string answer_3 = "check_ikanb";
            string answer_4 = "check_dekomposer";
            string answer_5 = "check_burung";
            string answer_6 = "check_biyawak";

            targetTime1 -= Time.deltaTime;
            targetTime2 -= Time.deltaTime;
            targetTime3 -= Time.deltaTime;
            targetTime4 -= Time.deltaTime;
            targetTime5 -= Time.deltaTime;
            targetTime6 -= Time.deltaTime;

            Debug.Log("waktu : " + targetTime1);

            if (targetTime1 <= 0.0f)
            {
                targetTime1 = 9999999999f;
                InitialCheckAnswer(answer_6, checkAnswerBiyawak, CHECK_TRUE, CHECK_FALSE, biyawakAnim);
            }
            else if (targetTime2 <= 0.0f)
            {
                targetTime2 = 9999999999f;
                InitialCheckAnswer(answer_1, checkAnswerKepiting, CHECK_TRUE, CHECK_FALSE, kepitingAnim);
            }
            else if (targetTime3 <= 0.0f)
            {
                targetTime3 = 9999999999f;
                InitialCheckAnswer(answer_4, checkAnswerDekomposer, CHECK_TRUE, CHECK_FALSE, dekomposerAnim);
            }
            else if (targetTime4 <= 0.0f)
            {
                targetTime4 = 9999999999f;
                InitialCheckAnswer(answer_2, checkAnswerIkanK, CHECK_TRUE, CHECK_FALSE, ikankAnim);
            }
            else if (targetTime5 <= 0.0f)
            {
                targetTime5 = 9999999999f;
                InitialCheckAnswer(answer_3, checkAnswerIkanB, CHECK_TRUE, CHECK_FALSE, ikanbAnim);
            }
            else if (targetTime6 <= 0.0f)
            {
                targetTime6 = 9999999999f;
                InitialCheckAnswer(answer_5, checkAnswerBurung, CHECK_TRUE, CHECK_FALSE, burungAnim);
            }
        }
    }

    void InitialCheckAnswer(string answer, string checkAnswer, string animTrue, string animFalse, Animator animator)
    {
        if (answer == checkAnswer)
        {
            animator.SetTrigger(animTrue);
        }
        else if (answer != checkAnswer)
        {
            animator.SetTrigger(animFalse);
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

    void RawScore(string initial, int value, string checkAnswer)
    {
        if (initial == codeKepiting)
        {
            scorekepiting = value;
            checkAnswerKepiting = checkAnswer;
        }
        else if (initial == codeIkanK)
        {
            scoreIkanKecil = value;
            checkAnswerIkanK = checkAnswer;
        }
        else if (initial == codeIkanB)
        {
            scoreIkanBesar = value;
            checkAnswerIkanB = checkAnswer;
        }
        else if (initial == codeBiyawak)
        {
            scoreBiyawak = value;
            checkAnswerBiyawak = checkAnswer;
        }
        else if (initial == codeDekomposer)
        {
            scoreDekomposer = value;
            checkAnswerDekomposer = checkAnswer;
        }
        else if (initial == codeBurung)
        {
            scoreBurung = value;
            checkAnswerBurung = checkAnswer;
        }
    }

    void RawDropObject(Vector2 initialVector, GameObject initial, string codeName, int scoreKepiting, int scoreIkanK, int scoreIkanB, int scoreBiyawak, int scoreDekomposer, int scoreBurung,
        string checkKepiting, string checkIkanK, string checkIkanB, string checkBiyawak, string checkDekomposer, string checkBurung)
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
            RawScore(codeName, scoreKepiting, checkKepiting);
        }
        else if (Distance2 < 50)
        {
            initial.transform.position = dropIkanKecil.transform.position;
            RawScore(codeName, scoreIkanK, checkIkanK);
        }
        else if (Distance3 < 50)
        {
            initial.transform.position = dropIkanBesar.transform.position;
            RawScore(codeName, scoreIkanB, checkIkanB);

        }
        else if (Distance4 < 50)
        {
            initial.transform.position = dropBiyawak.transform.position;
            RawScore(codeName, scoreBiyawak, checkBiyawak);
        }
        else if (Distance5 < 50)
        {
            initial.transform.position = dropDekomposer.transform.position;
            RawScore(codeName, scoreDekomposer, checkDekomposer);
        }
        else if (Distance6 < 50)
        {
            initial.transform.position = dropBurung.transform.position;
            RawScore(codeName, scoreBurung, checkBurung);
        }
        else
        {
            initial.transform.position = initialVector;
        }
    }

    public void DropKepiting()
    {
        RawDropObject(kepitingInitialPos, kepiting, codeKepiting, 20, 0, 0, 0, 0, 0, answerKepiting, "", "", "", "", "");
    }

    public void DropIkanKecil()
    {
        RawDropObject(ikanKecilInitialPos, ikanKecil, codeIkanK, 0, 20, 0, 0, 0, 0, "", answerIkanK, "", "", "", "");
    }

    public void DropIkanBesar()
    {
        RawDropObject(ikanBesarInitialPos, ikanBesar, codeIkanB, 0, 0, 10, 0, 0, 0, "", "", answerIkanB, "", "", "");
    }

    public void DropBiyawak()
    {
        RawDropObject(biyawakInitialPos, biyawak, codeBiyawak, 0, 0, 0, 20, 0, 0, "", "", "", answerBiyawak, "", "");
    }

    public void DropDekomposer()
    {
        RawDropObject(dekomposerInitialPos, dekomposer, codeDekomposer, 0, 0, 0, 0, 20, 0, "", "", "", "", answerDekomposer, "");
    }

    public void DropBurung()
    {
        RawDropObject(burungInitialPos, burung, codeBurung, 0, 0, 0, 0, 0, 10, "", "", "", "", "", answerBurung);
    }

    public void Finish()
    {
        btn.gameObject.GetComponent<Button>().onClick.AddListener(() => ClickButtonFinish(hasilScore));
    }

    void ClickButtonFinish(int score)
    {
        statAnswer = 1;
        timeLeft = 0;
        timerIsActive = false;
        disableAllButton.SetActive(true);

        if (allFinished == 1)
        {
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
