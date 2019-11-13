using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevel : MonoBehaviour
{
    public Button btnLevel1, btnLevel2, btnLevel3;

    public int nilaiS_1, nilaiS_2, nilaiS_3;
    bool conLevel = false;
    bool conLeve2 = false;
    bool conLeve3 = false;

    int resultScore1;

    // Start is called before the first frame update
    void Start()
    {
        resultScore1 = PlayerPrefs.GetInt("scoreLvl1");
        Debug.Log(resultScore1);
        btnLevel2.interactable = false;
        
        LevelGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelGame()
    {

        if (resultScore1 == 0 || resultScore1 == null)
        {
            btnLevel2.interactable = false;
        }
        else
        {
            btnLevel2.interactable = true;
        }
    }

    public void BtnLevel2()
    {
        Debug.Log("asdasd");
    }
}
