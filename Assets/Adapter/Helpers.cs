using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class JsonHelper
//{
//    public static T[] getJsonArray<T>(string json)
//    {
//        string newJson = "{ \"array\": " + json + "}";
//        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
//        return wrapper.array;
//    }

//    [System.Serializable]
//    private class Wrapper<T>
//    {
//        public T[] array;
//    }
//}

[System.Serializable]
public class RootObject
{
    public string created_at;
    public string id;
    public string post;
    public int total_like;
    public int total_retweet;
    public string username;
}

public class UserServices
{
    public List<RootObject> servicesss { get; set; }
}

public class Examplessss
{
    public List<RootObject> usersMurid;
    public RootObject[] user;
}


[System.Serializable]
public class CountriesList
{
    public List<RootObject> Countries;
}
