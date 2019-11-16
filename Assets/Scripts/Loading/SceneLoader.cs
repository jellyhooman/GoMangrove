using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    public Slider slider;
    private float timeRemaining = 0;
    private float timeMax = 3f;

    string id_siswa;

    public void Start()
    {
        id_siswa = PlayerPrefs.GetString("id_siswa");
    }

    public void Update()
    {
        slider.value = CalculateTimer();
        timeRemaining += Time.deltaTime;

        if (timeRemaining > 3)
        {
            PlayerPrefs.SetString("id_siswa", id_siswa);
            SceneManager.LoadScene("Main Menu");
        }
    }

    float CalculateTimer()
    {
        return (timeRemaining / timeMax);
    }
}

