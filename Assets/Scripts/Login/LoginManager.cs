using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class LoginManager : MonoBehaviour
{
    JsonData stateData;
    GetLogin login;
    Login loginO;
    
    public InputField usernameInputField;
    public InputField passwordInputFiled;

    static string username;
    static string password;

    private IEnumerator RetriveData()
    {
        username = usernameInputField.text;
        password = passwordInputFiled.text;
        string BASE_URL = "http://gomangrove.com/backend/api/v1/login?username="+username+"&password="+password;
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        WWW www = new WWW(BASE_URL);
        yield return www;

        loginO = new Login();
        if (www.error == null)
        {
            login = JsonUtility.FromJson<GetLogin>("{\"getLogin\":" + www.text + "}");
            loginO = JsonUtility.FromJson<Login>(www.text);
            
            bool statusLogin = loginO.login;
            string id_siswa = loginO.id;
            
            if (statusLogin == true)
            {
                PlayerPrefs.SetString("id_siswa", id_siswa);
                Application.LoadLevel("Main Menu");
            }
            else
            {
                Debug.Log("Gagal Masuk");
            }

        }
        else
        {
            Debug.Log("ERROR : " + www.error);
        }
        

    }

    public void LoginButton()
    {
        if (usernameInputField.text != "" && passwordInputFiled.text != "")
        {
            StartCoroutine(RetriveData());
        }
        else
        {
            Debug.Log("Masukin Data WOI!!!!!");
        }
    }
}
