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

    public void Update()
    {
        slider.value = CalculateTimer();
        timeRemaining += Time.deltaTime;

        if (timeRemaining > 3)
        {
            SceneManager.LoadScene("Main Scene");
        }
    }

    float CalculateTimer()
    {
        return (timeRemaining / timeMax);
    }
}

