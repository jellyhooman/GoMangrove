using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GoMangrove.Scripts
{
    public class GetMateri
    {
        [JsonProperty("result")]
        public List<Tweet> listMateri;

        public List<Tweet> getListMateri()
        {
            return listMateri;
        }

        public void setListMateri(List<Tweet> listMateri)
        {
            this.listMateri = listMateri;
        }
    }
}
