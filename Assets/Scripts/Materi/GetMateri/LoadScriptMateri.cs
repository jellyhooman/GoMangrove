using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScriptMateri : MonoBehaviour
{
    public Text username;
    public Text post;

    public GameObject isiMateriObject;
    public ListMateriControl isiMateriScript;

    public void Start()
    {
        username.text = PlayerPrefs.GetString("username");
        post.text = PlayerPrefs.GetString("post");
    }
}
