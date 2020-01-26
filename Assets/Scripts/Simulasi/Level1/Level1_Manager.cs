using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using LitJson;
using System.Text;
using SimpleHTTP;

public class Level1_Manager : MonoBehaviour
{
    string CHECK_TRUE = "check_true";
    string CHECK_FALSE = "check_false";

    public Animator ularAnim, burungAnim, ikanbAnim, ikankAnim, serasahAnim;

    public GameObject ular, ikanKecil, ikanBesar, serasah, burung;
    public GameObject dropUlar, dropIkanKecil, dropIkanBesar, dropSerasah, dropBurung;
    public GameObject btnSelesai;
    public GameObject disableAllButton;
    GameObject btn;

    Vector2 ularInitialPos, ikanKecilInitialPos, ikanBesarInitialPos, serasahInitialPos, burungInitialPos;

    int scoreUlar, scoreIkanKecil, scoreIkanBesar, scoreSerasah, scoreBurung = 0;
    int hasilScore;
    int scoreSoal = 20;

    string codeUlar, codeIkanK, codeIkanB, codeSerasah, codeBurung;
    string checkAnswerUlar, checkAnswerIkanK, checkAnswerIkanB, checkAnswerSerasah, checkAnswerBurung, checkAnswer;
    string answerUlar, answerIkanK, answerIkanB, answerSerasah, answerBurung;
    int statAnswer;

    string Url = "http://gomangrove.com/backend/api/v1/postNilaiSimulasi";
    string Url_PUT = "http://gomangrove.com/backend/api/v1/putNilaiSimulasi";
    string id_murid;

    public Text textTimer;
    float timeLeft = 120.0f;
    float targetTime1 = 1f;
    float targetTime2 = 2.30f;
    float targetTime3 = 3.60f;
    float targetTime4 = 4.90f;
    float targetTime5 = 6.20f;
    bool timerIsActive = true;
    int allFinished = 0;

    public Image checkFinished;
    public Sprite iconFinished;

    string statusLevel;

    JsonData stateData;

    GetNilaiSimulasi mGetNilaiSimulasi;
    string mId_simulasi;

    public GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
        disableAllButton.SetActive(false);
        statusLevel = PlayerPrefs.GetString("status_lvl1");
        id_murid = PlayerPrefs.GetString("id_murid");

        ularAnim = dropUlar.GetComponent<Animator>();
        burungAnim = dropBurung.GetComponent<Animator>();
        ikanbAnim = dropIkanBesar.GetComponent<Animator>();
        ikankAnim = dropIkanKecil.GetComponent<Animator>();
        serasahAnim = dropSerasah.GetComponent<Animator>();

        Debug.Log("start " + mId_simulasi);
        Debug.Log("start " + statusLevel);
        Debug.Log("start " + id_murid);

        codeUlar = "codeUlar";
        codeIkanK = "codeIkanK";
        codeIkanB = "codeIkanB";
        codeSerasah = "codeSerasah";
        codeBurung = "codeBurung";

        answerUlar = "check_ular";
        answerIkanK = "check_ikank";
        answerIkanB = "check_ikanb";
        answerSerasah = "check_serasah";
        answerBurung = "check_burung";
        statAnswer = 0;

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
        StartCoroutine(RetriveData());
    }


     //Update is called once per frame
    void Update()
    {
        hasilScore = scoreUlar + scoreIkanKecil + scoreIkanBesar + scoreSerasah + scoreBurung;
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
            string answer_1 = "check_ular";
            string answer_2 = "check_ikank";
            string answer_3 = "check_ikanb";
            string answer_4 = "check_serasah";
            string answer_5 = "check_burung";
            
            targetTime1 -= Time.deltaTime;
            targetTime2 -= Time.deltaTime;
            targetTime3 -= Time.deltaTime;
            targetTime4 -= Time.deltaTime;
            targetTime5 -= Time.deltaTime;

            Debug.Log("waktu : " + targetTime1);

            if (targetTime1 <= 0.0f)
            {
                targetTime1 = 9999999999f;
                InitialCheckAnswer(answer_1, checkAnswerUlar, CHECK_TRUE, CHECK_FALSE, ularAnim);
            }
            else if (targetTime2 <= 0.0f)
            {
                targetTime2 = 9999999999f;
                InitialCheckAnswer(answer_5, checkAnswerBurung, CHECK_TRUE, CHECK_FALSE, burungAnim);
            }
            else if (targetTime3 <= 0.0f)
            {
                targetTime3 = 9999999999f;
                InitialCheckAnswer(answer_3, checkAnswerIkanB, CHECK_TRUE, CHECK_FALSE, ikanbAnim);
            }
            else if (targetTime4 <= 0.0f)
            {
                targetTime4 = 9999999999f;
                InitialCheckAnswer(answer_2, checkAnswerIkanK, CHECK_TRUE, CHECK_FALSE, ikankAnim);
            }
            else if (targetTime5 <= 0.0f)
            {
                targetTime5 = 9999999999f;
                InitialCheckAnswer(answer_4, checkAnswerSerasah, CHECK_TRUE, CHECK_FALSE, serasahAnim);
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

    void RawScore(string initial, int value, string checkAnswer)
    {
        if (initial == codeUlar)
        {
            scoreUlar = value;
            checkAnswerUlar = checkAnswer;
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
        else if (initial == codeSerasah)
        {
            scoreSerasah = value;
            checkAnswerSerasah = checkAnswer;
        }
        else if (initial == codeBurung)
        {
            scoreBurung = value;
            checkAnswerBurung = checkAnswer;
        }
    }

    void RawDropObject(Vector2 initialVector ,GameObject initial, string codeName, int scoreUlar, int scoreIkanK, int scoreIkanB, int scoreSerasah, int scoreBurung,
        string checkUlar, string checkIkanK, string checkIkanB, string checkSerasah, string checkBurung)
    {
        float Distance1 = Vector3.Distance(initial.transform.position, dropUlar.transform.position);
        float Distance2 = Vector3.Distance(initial.transform.position, dropIkanKecil.transform.position);
        float Distance3 = Vector3.Distance(initial.transform.position, dropIkanBesar.transform.position);
        float Distance4 = Vector3.Distance(initial.transform.position, dropSerasah.transform.position);
        float Distance5 = Vector3.Distance(initial.transform.position, dropBurung.transform.position);

        if (Distance1 < 50)
        {
            initial.transform.position = dropUlar.transform.position;
            RawScore(codeName, scoreUlar, checkUlar);
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
            initial.transform.position = dropSerasah.transform.position;
            RawScore(codeName, scoreSerasah, checkSerasah);
        }
        else if (Distance5 < 50)
        {
            initial.transform.position = dropBurung.transform.position;
            RawScore(codeName, scoreBurung, checkBurung);
        }
        else
        {
            initial.transform.position = initialVector;
        }
    }

    public void DropUlar()
    {
        RawDropObject(ularInitialPos, ular, codeUlar, scoreSoal, 0, 0, 0, 0, answerUlar, "","","","");
    }

    public void DropIkanKecil()
    {
        RawDropObject(ikanKecilInitialPos, ikanKecil, codeIkanK, 0, scoreSoal, 0, 0, 0, "", answerIkanK, "", "", "");
    }

    public void DropIkanBesar()
    {
        RawDropObject(ikanBesarInitialPos, ikanBesar, codeIkanB, 0, 0, scoreSoal, 0, 0, "", "", answerIkanB, "", "");
    }

    public void DropSerasah()
    {
        RawDropObject(serasahInitialPos, serasah, codeSerasah, 0, 0, 0, scoreSoal, 0, "", "", "", answerSerasah, "");
    }

    public void DropBurung()
    {
        RawDropObject(burungInitialPos, burung, codeBurung, 0, 0, 0, 0, scoreSoal, "", "", "", "", answerBurung);
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
                PostData(id_murid, "Level Simulasi 1", score);
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
        if (score > 50)
        {
            PlayerPrefs.SetInt("nilai_simulasi", score);
            Application.LoadLevel("VictoryScene");
        }
        else if (score <= 50)
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
        PUTNilaiSimulasi put = new PUTNilaiSimulasi(id, "Simulasi Level 1", score);

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
            mId_simulasi = mGetNilaiSimulasi.nilaiSimulasi[0].id;
            Debug.Log("id simulasi :"+mId_simulasi);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
}
