using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class ListMateriControl : MonoBehaviour
{
    [SerializeField]
    public GameObject buttonTemplate;

    string BASE_URL = "http://basaraga.com/api/v1/twitter/main-get-all-tweet";
    JsonData stateData;
    UserServices userServices;

    // Sample JSON for the following script has attached.
    IEnumerator Start()
    {
        string url = "http://basaraga.com/api/v1/twitter/main-get-all-tweet";
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            Examplessss examplessss = JsonUtility.FromJson<Examplessss>("{\"usersMurid\":" + www.text + "}");
            Examplessss examp2 = JsonUtility.FromJson<Examplessss>("{\"user\":" + www.text + "}");
            int arrSize = examp2.user.Length;
            for (int i = 1; i < arrSize; i++)
            {
                Debug.Log("id :"+ examplessss.usersMurid[i].id+", Username : "+ examplessss.usersMurid[i].username);
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ListMateri>().setText(examplessss.usersMurid[i].username);
                button.transform.SetParent(buttonTemplate.transform.parent, false);

                string mId = examplessss.usersMurid[i].id;
                string mPost = examplessss.usersMurid[i].post;
                string mUsername = examplessss.usersMurid[i].username;

                button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(mId, mPost, mUsername));
            }

        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
    private void Processjson(string jsonString)
    {
        
        //Debug.Log(services);


        //JsonData jsonvale = JsonMapper.ToObject(jsonString);
        //parseJSON parsejson;
        //parsejson = new parseJSON();
        //parsejson.title = jsonvale["title"].ToString();
        //parsejson.id = jsonvale["ID"].ToString();

        //parsejson.but_title = new ArrayList();
        //parsejson.but_image = new ArrayList();

        //for (int i = 0; i < jsonvale["buttons"].Count; i++)
        //{
        //    parsejson.but_title.Add(jsonvale["buttons"][i]["title"].ToString());
        //    parsejson.but_image.Add(jsonvale["buttons"][i]["image"].ToString());
        //}
    }



    //public void Start()
    //{
    //    StartCoroutine(GetCountries());
    //    //for (int i = 1; i <= 20; i++)
    //    //{
    //    //    GameObject button = Instantiate(buttonTemplate) as GameObject;
    //    //    button.SetActive(true);

    //    //    button.GetComponent<ListMateri>().setText("Button #" + i);
    //    //    button.transform.SetParent(buttonTemplate.transform.parent, false);

    //    //    string tdata = "Button#" + i;
    //    //    button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(tdata));
    //    //}    
    //}

    //IEnumerator GetCountries()
    //{
    //    string getCountriesUrl = "http://basaraga.com/api/v1/twitter/main-get-all-tweet";
    //    using (UnityWebRequest www = UnityWebRequest.Get(getCountriesUrl))
    //    {
    //        //www.chunkedTransfer = false;
    //        yield return www.Send();
    //        if (www.isNetworkError || www.isHttpError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            if (www.isDone)
    //            {
    //                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
    //                Debug.Log(jsonResult);
    //                RootObject[] entities = JsonHelper.getJsonArray<RootObject>(jsonResult);
    //                RootObject jsonTest = JsonHelper.getJsonArray

    //                int arrSize = entities.Length;
    //                for (int i = 1; i <= arrSize; i++)
    //                {
    //                    GameObject button = Instantiate(buttonTemplate) as GameObject;
    //                    button.SetActive(true);

    //                    button.GetComponent<ListMateri>().setText("");
    //                    button.transform.SetParent(buttonTemplate.transform.parent, false);

    //                    string tdata = "Button#" + i;
    //                    button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(tdata));
    //                }
    //            }
    //            //ddlCountries.options.AddRange(entities.
    //        }
    //    }
    //}

    public void OnButtonClick(string mId, string mPost, string mUsername)
    {
        PlayerPrefs.SetString("id", mId);
        PlayerPrefs.SetString("post", mPost);
        PlayerPrefs.SetString("username", mUsername);
        Application.LoadLevel("ListGetMateriScene");
    }

}
