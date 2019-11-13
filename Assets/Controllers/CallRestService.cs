using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;

public class CallRestService : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(getWWW());
    }

    IEnumerator getWWW()
    {
        // First define the url, this should be a valid url
        string url = "http://basaraga.com/api/v1/twitter/main-get-all-tweet";

        WWW www = new WWW(url);
        while (!www.isDone)
            yield return null;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.text);
        }
        else
            Debug.Log(www.error);

    }
}
