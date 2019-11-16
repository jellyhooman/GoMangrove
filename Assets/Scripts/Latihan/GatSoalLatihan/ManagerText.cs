using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerText : MonoBehaviour
{
    private string jwb1, jwb2, jwb3, jwb4;
    public Text getJwb1, getJwb2, getJwb3, getJwb4;
   
    public ManagerLatihan isiLatihan;

    public void setJawban1(string textString)
    {
        jwb1 = textString;
        getJwb1.text = textString;
    }

    public void setJawban2(string textString)
    {
        jwb2 = textString;
        getJwb2.text = textString;
    }

    public void setJawban3(string textString)
    {
        jwb2 = textString;
        getJwb3.text = textString;
    }

    public void setJawban4(string textString)
    {
        jwb4 = textString;
        getJwb4.text = textString;
    }
}
