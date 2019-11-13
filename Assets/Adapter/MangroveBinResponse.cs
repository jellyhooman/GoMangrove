using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GoMangrove.Scripts
{
    public class MangroveBinResponse
    {
        [JsonProperty("result")]
        public GetMateri queryArgs;

        public GetMateri getMateri()
        {
            return queryArgs;
        }

        public void setMateri(GetMateri GetMateri)
        {
            queryArgs = GetMateri;
        }
        //public  QueryArgs
        //{
        //    [JsonProperty("created_at")]
        //    public string created_at;
        //    [JsonProperty("id")]
        //    public string id;
        //    [JsonProperty("post")]
        //    public string post;
        //    [JsonProperty("total_like")]
        //    public int total_like;
        //    [JsonProperty("total_retweet")]
        //    public int total_retweet;
        //    [JsonProperty("username")]
        //    public string username;
        //}
    
    }
}

