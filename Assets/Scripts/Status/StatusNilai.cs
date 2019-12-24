using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusNilai : MonoBehaviour
{
    public Text nilaiAkhir;
    int iNilaiAkhir;

    private void Start()
    {
        iNilaiAkhir = PlayerPrefs.GetInt("nilai_simulasi");
        nilaiAkhir.text = iNilaiAkhir.ToString("0");
    }
}
