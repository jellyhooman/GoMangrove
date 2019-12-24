using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard_HelperText : MonoBehaviour
{
    [SerializeField]
    private Text nama_latihan;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Leaderboard_Manager leaderboard_Manager;

    private string mNama_latihan;
    private string mScore;

    public void setTextNamaLatihan(string textString)
    {
        mNama_latihan = textString;
        nama_latihan.text = textString;
    }

    public void setTextScore(string textString)
    {
        mScore = textString;
        score.text = textString;
    }
}
