using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using SimpleHTTP;


public class Level3_Manager : MonoBehaviour
{
    string CHECK_TRUE = "check_true";
    string CHECK_FALSE = "check_false";

    public Animator kepitingAnim, ikankAnim, ikanbAnim, biyawakAnim, elangAnim, burungAnim, siputAnim, nelayanAnim, ularAnim;

    public GameObject kepiting, ikanKecil, ikanBesar, biyawak, elang, burung, siput, nelayan, ular;
    public GameObject dropKepiting, dropIkanKecil, dropIkanBesar, dropBiyawak, dropElang, dropBurung, dropSiput, dropNelayan, dropUlar;
    public GameObject btnSelesai, btnDone;
    public GameObject disableAllButton;
    GameObject btn, btnS;

    Vector2 kepitingInitialPos, ikanKecilInitialPos, ikanBesarInitialPos, biyawakInitialPos, elangInitialPos, burungInitialPos, siputInitialPos, nelayanInitialPos, ularInitialPos;

    int scorekepiting, scoreIkanKecil, scoreIkanBesar, scoreBiyawak, scoreElang, scoreBurung, scoreSiput, scoreNelayan, scoreUlar = 0;
    int hasilScore;
    int scoreSoal = 10;

    string codeKepiting, codeIkanK, codeIkanB, codeBiyawak, codeElang, codeBurung, codeSiput, codeNelayan, codeUlar;
    string checkAnswerKepiting, checkAnswerIkanK, checkAnswerIkanB, checkAnswerBiyawak, checkAnswerBurung, checkAnswerElang, checkAnswerSiput, checkAnswerNelayan, checkAnswerUlar, checkAnswer;
    string answerKepiting, answerIkanK, answerIkanB, answerElang, answerBurung, answerBiyawak, answerSiput, answerNelayan, answerUlar;
    int statAnswer;

    string Url = "http://gomangrove.com/backend/api/v1/postNilaiSimulasi";
    string id_murid;

    public Text textTimer;

    //+time 1.30f
    float timeLeft = 120.0f;
    float targetTime1 = 1f;
    float targetTime2 = 2.30f;
    float targetTime3 = 3.60f;
    float targetTime4 = 4.90f;
    float targetTime5 = 6.20f;
    float targetTime6 = 7.50f;
    float targetTime7 = 8.80f;
    float targetTime8 = 10.10f;
    float targetTime9 = 11.40f;
    bool timerIsActive = true;
    int allFinished = 0;

    string statusLevel;

    JsonData stateData;

    GetNilaiSimulasi mGetNilaiSimulasi;
    string mId_simulasi;
    int scorelevel3;

    // Start is called before the first frame update
    void Start()
    {
        disableAllButton.SetActive(false);

        statusLevel = PlayerPrefs.GetString("status_lvl3");
        id_murid = PlayerPrefs.GetString("id_murid");
        scorelevel3 = PlayerPrefs.GetInt("nilai_lvl3");

        kepitingAnim = dropKepiting.GetComponent<Animator>();
        burungAnim = dropBurung.GetComponent<Animator>();
        ikanbAnim = dropIkanBesar.GetComponent<Animator>();
        ikankAnim = dropIkanKecil.GetComponent<Animator>();
        elangAnim = dropElang.GetComponent<Animator>();
        biyawakAnim = dropBiyawak.GetComponent<Animator>();
        siputAnim = dropSiput.GetComponent<Animator>();
        nelayanAnim = dropNelayan.GetComponent<Animator>();
        ularAnim = dropUlar.GetComponent<Animator>();

        Debug.Log("start sim " + mId_simulasi);
        Debug.Log("start status  " + statusLevel);
        Debug.Log("start id m" + id_murid);

        StartCoroutine(RetriveData());
        codeKepiting = "codeKepiting";
        codeIkanK = "codeIkanK";
        codeIkanB = "codeIkanB";
        codeBiyawak = "codeBiyawak";
        codeElang = "codeElang";
        codeBurung = "codeBurung";
        codeSiput = "codeSiput";
        codeNelayan = "codeNelayan";
        codeUlar = "codeUlar";

        answerKepiting = "check_kepiting";
        answerIkanK = "check_ikank";
        answerIkanB = "check_ikanb";
        answerElang = "check_elang";
        answerBurung = "check_burung";
        answerBiyawak = "check_biyawak";
        answerSiput = "check_siput";
        answerNelayan = "check_nelayan";
        answerUlar = "check_ular";
        statAnswer = 0;

        kepitingInitialPos = kepiting.transform.position;
        ikanKecilInitialPos = ikanKecil.transform.position;
        ikanBesarInitialPos = ikanBesar.transform.position;
        biyawakInitialPos = biyawak.transform.position;
        elangInitialPos = elang.transform.position;
        burungInitialPos = burung.transform.position;
        siputInitialPos = siput.transform.position;
        nelayanInitialPos = nelayan.transform.position;
        ularInitialPos = ular.transform.position;

        id_murid = PlayerPrefs.GetString("id_murid");

        btn = Instantiate(btnSelesai) as GameObject;
        btnSelesai.SetActive(true);
        btn.transform.SetParent(btnSelesai.transform.parent, false);

        btnS = Instantiate(btnDone) as GameObject;
        btnDone.SetActive(false);
        btnS.transform.SetParent(btnDone.transform.parent, false);

        Finish();
    }

    // Update is called once per frame
    void Update()
    {
        hasilScore = scorekepiting + scoreIkanKecil + scoreIkanBesar + scoreBiyawak + scoreElang + scoreBurung + scoreSiput + scoreNelayan + scoreUlar;

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

            string answer_1 = "check_kepiting";
            string answer_2 = "check_ikank";
            string answer_3 = "check_ikanb";
            string answer_4 = "check_elang";
            string answer_5 = "check_burung";
            string answer_6 = "check_biyawak";
            string answer_7 = "check_siput";
            string answer_8 = "check_nelayan";
            string answer_9 = "check_ular";

            targetTime1 -= Time.deltaTime;
            targetTime2 -= Time.deltaTime;
            targetTime3 -= Time.deltaTime;
            targetTime4 -= Time.deltaTime;
            targetTime5 -= Time.deltaTime;
            targetTime6 -= Time.deltaTime;
            targetTime7 -= Time.deltaTime;
            targetTime8 -= Time.deltaTime;
            targetTime9 -= Time.deltaTime;


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
                InitialCheckAnswer(answer_2, checkAnswerIkanK, CHECK_TRUE, CHECK_FALSE, ikankAnim);
            }
            else if (targetTime4 <= 0.0f)
            {
                targetTime4 = 9999999999f;
                InitialCheckAnswer(answer_7, checkAnswerSiput, CHECK_TRUE, CHECK_FALSE, siputAnim);
            }
            else if (targetTime5 <= 0.0f)
            {
                targetTime5 = 9999999999f;
                InitialCheckAnswer(answer_9, checkAnswerUlar, CHECK_TRUE, CHECK_FALSE, ularAnim);
            }
            else if (targetTime6 <= 0.0f)
            {
                targetTime6 = 9999999999f;
                InitialCheckAnswer(answer_3, checkAnswerIkanB, CHECK_TRUE, CHECK_FALSE, ikanbAnim);
            }
            else if (targetTime7 <= 0.0f)
            {
                targetTime7 = 9999999999f;
                InitialCheckAnswer(answer_5, checkAnswerBurung, CHECK_TRUE, CHECK_FALSE, burungAnim);
            }
            else if (targetTime8 <= 0.0f)
            {
                targetTime8 = 9999999999f;
                InitialCheckAnswer(answer_8, checkAnswerNelayan, CHECK_TRUE, CHECK_FALSE, nelayanAnim);
            }
            else if (targetTime9 <= 0.0f)
            {
                targetTime9 = 9999999999f;
                InitialCheckAnswer(answer_4, checkAnswerElang, CHECK_TRUE, CHECK_FALSE, elangAnim);
                allFinished = 1;
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

    public void DragElang()
    {
        elang.transform.position = Input.mousePosition;
    }

    public void DragBurung()
    {
        burung.transform.position = Input.mousePosition;
    }

    public void DragSiput()
    {
        siput.transform.position = Input.mousePosition;
    }

    public void DragNelayan()
    {
        nelayan.transform.position = Input.mousePosition;
    }

    public void DragUlar()
    {
        ular.transform.position = Input.mousePosition;
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
        else if (initial == codeElang)
        {
            scoreElang = value;
            checkAnswerElang = checkAnswer;
        }
        else if (initial == codeBurung)
        {
            scoreBurung = value;
            checkAnswerBurung = checkAnswer;
        }
        else if (initial == codeSiput)
        {
            scoreSiput = value;
            checkAnswerSiput = checkAnswer;
        }
        else if (initial == codeNelayan)
        {
            scoreNelayan = value;
            checkAnswerNelayan = checkAnswer;
        }
        else if (initial == codeUlar)
        {
            scoreUlar = value;
            checkAnswerUlar = checkAnswer;
        }
    }

    void RawDropObject(Vector2 initialVector, GameObject initial, string codeName, int scoreKepiting, int scoreIkanK, int scoreIkanB, int scoreBiyawak, int scoreElang, int scoreBurung, int scoreSiput, int scoreNelayan, int scoreUlar,
        string checkKepiting, string checkIkanK, string checkIkanB, string checkBiyawak, string checkElang, string checkBurung, string checkSiput, string checkNelayan, string checkUlar)
    {
        float Distance1 = Vector3.Distance(initial.transform.position, dropKepiting.transform.position);
        float Distance2 = Vector3.Distance(initial.transform.position, dropIkanKecil.transform.position);
        float Distance3 = Vector3.Distance(initial.transform.position, dropIkanBesar.transform.position);
        float Distance4 = Vector3.Distance(initial.transform.position, dropBiyawak.transform.position);
        float Distance5 = Vector3.Distance(initial.transform.position, dropElang.transform.position);
        float Distance6 = Vector3.Distance(initial.transform.position, dropBurung.transform.position);
        float Distance7 = Vector3.Distance(initial.transform.position, dropSiput.transform.position);
        float Distance8 = Vector3.Distance(initial.transform.position, dropNelayan.transform.position);
        float Distance9 = Vector3.Distance(initial.transform.position, dropUlar.transform.position);

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
            initial.transform.position = dropElang.transform.position;
            RawScore(codeName, scoreElang, checkElang);
        }
        else if (Distance6 < 50)
        {
            initial.transform.position = dropBurung.transform.position;
            RawScore(codeName, scoreBurung, checkBurung);
        }
        else if (Distance7 < 50)
        {
            initial.transform.position = dropSiput.transform.position;
            RawScore(codeName, scoreSiput, checkSiput);
        }
        else if (Distance8 < 50)
        {
            initial.transform.position = dropNelayan.transform.position;
            RawScore(codeName, scoreNelayan, checkNelayan);
        }
        else if (Distance9 < 50)
        {
            initial.transform.position = dropUlar.transform.position;
            RawScore(codeName, scoreUlar, checkUlar);
        }
        else
        {
            initial.transform.position = initialVector;
        }
    }

    public void DropKepiting()
    {
        RawDropObject(kepitingInitialPos, kepiting, codeKepiting, scoreSoal, 0, 0, 0, 0, 0, 0, 0, 0, answerKepiting, "", "", "", "", "", "", "", "");
    }

    public void DropIkanKecil()
    {
        RawDropObject(ikanKecilInitialPos, ikanKecil, codeIkanK, 0, 30, 0, 0, 0, 0, 0, 0, 0, "", answerIkanK, "", "", "", "", "", "", "");
    }

    public void DropIkanBesar()
    {
        RawDropObject(ikanBesarInitialPos, ikanBesar, codeIkanB, 0, 0, scoreSoal, 0, 0, 0, 0,0, 0, "", "", answerIkanB, "", "", "", "", "", "");
    }

    public void DropBiyawak()
    {
        RawDropObject(biyawakInitialPos, biyawak, codeBiyawak, 0, 0, 0, scoreSoal, 0, 0, 0, 0, 0, "", "", "", answerBiyawak, "", "", "", "", "");
    }

    public void DropElang()
    {
        RawDropObject(elangInitialPos, elang, codeElang, 0, 0, 0, 0, scoreSoal, 0, 0, 0, 0, "", "", "", "", answerElang, "", "", "", "");
    }

    public void DropBurung()
    {
        RawDropObject(burungInitialPos, burung, codeBurung, 0, 0, 0, 0, 0, scoreSoal, 0, 0, 0, "", "", "", "", "", answerBurung, "", "", "");
    }

    public void DropSiput()
    {
        RawDropObject(siputInitialPos, siput, codeSiput, 0, 0, 0, 0, 0, 0, scoreSoal, 0, 0, "", "", "", "", "", "", answerSiput, "", "");
    }

    public void DropNelayan()
    {
        RawDropObject(nelayanInitialPos, nelayan, codeNelayan, 0, 0, 0, 0, 0, 0, 0, scoreSoal, 0, "", "", "", "", "", "", "", answerNelayan, "");
    }

    public void DropUlar()
    {
        RawDropObject(ularInitialPos, ular, codeUlar, 0, 0, 0, 0, 0, 0, 0, 0, scoreSoal, "", "", "", "", "", "", "", "", answerUlar);
    }

    public void Finish()
    {
        btn.gameObject.GetComponent<Button>().onClick.AddListener(() => ClickButtonFinish(hasilScore));
        btnS.gameObject.GetComponent<Button>().onClick.AddListener(() => ClickButtonDone(hasilScore));
    }

    void ClickButtonFinish(int score)
    {
        statAnswer = 1;
        timeLeft = 0;
        timerIsActive = false;
        disableAllButton.SetActive(true);
    }

    void ClickButtonDone(int score)
    {
        if (allFinished == 1)
        {
            if (statusLevel == "null")
            {
                PostData(id_murid, "Level Simulasi 3", score);
                StateResult(score);
            }
            else if (statusLevel == "not_null")
            {
                if (score < scorelevel3)
                {
                    StateResult(score);
                }
                else if (score >= scorelevel3)
                {
                    StartCoroutine(Put(mId_simulasi, score));
                    StateResult(score);
                }
            }
        }
    }

    void StateResult(int score)
    {
        if (score >= 60)
        {
            PlayerPrefs.SetInt("nilai_simulasi", score);
            Application.LoadLevel("VictoryScene");
        }
        else if (score <= 59)
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
        PUTNilaiSimulasi put = new PUTNilaiSimulasi(id, "Simulasi Level 3", score);

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
            Debug.Log("arrays : " + array);
            if (array > 2)
            {
                mId_simulasi = mGetNilaiSimulasi.nilaiSimulasi[2].id;
            }
            else if (array <= 2)
            {

            }

            Debug.Log("id simulasi :" + mId_simulasi);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
}
