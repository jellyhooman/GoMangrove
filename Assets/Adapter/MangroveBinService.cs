using Retrofit;
using Retrofit.HttpImpl;
using UniRx;
using UnityEngine;
using System;

namespace GoMangrove.Scripts
{
    public class MangroveBinService:RestAdapter,MangroveBinInterface
    {
        private static MangroveBinService _instance;

        public static MangroveBinService Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("MangroveBinService");
                    _instance = go.AddComponent<MangroveBinService>();
                }
                return _instance;
            }
        }

        protected override RequestInterceptor SetIntercepter()
        {
            return null;
        }

        protected override HttpImplement SetHttpImpl()
        {
            var httpImpl = new HttpClientImpl();
            httpImpl.EnableDebug = true;
            return httpImpl;
        }

        protected override void SetRestAPI()
        {
            baseUrl = "http://basaraga.com/api/v1/twitter";
            iRestInterface = typeof(MangroveBinInterface);
        }

        //public IObservable<MangroveBinResponse> GetMateri(string created_at, string id, string post, string total_like, string total_retweet, string username)
        //{
        //    return SendRequest<MangroveBinResponse>(created_at, id, post, total_like, total_retweet, username) as IObservable<MangroveBinResponse>;
        //}

        public IObservable<MangroveBinResponse> GetMateri()
        {
            return SendRequest<MangroveBinResponse>() as IObservable<MangroveBinResponse>;
        }
    }
}
