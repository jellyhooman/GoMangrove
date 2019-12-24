using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListNilaiSimulasi_HelperText : MonoBehaviour
{
    [SerializeField]
    private Text nama_simulasi;
    [SerializeField]
    private Text score;
    [SerializeField]
    private ListNilaiSimulasi_Manager listNilaiSimulasi_Manager;

    private string mNama_simulasi;
    private string mScore;

    public void setTextNamaSimulasi(string textString)
    {
        mNama_simulasi = textString;
        nama_simulasi.text = textString;
    }

    public void setTextScore(string textString)
    {
        mScore = textString;
        score.text = textString;
    }
}
