using Retrofit;
using Retrofit.Methods;
using Retrofit.Parameters;
using UniRx;
using System;

namespace GoMangrove.Scripts
{
    public interface MangroveBinInterface
    {
        //[Get("/main-get-all-tweet")]
        //IObservable<MangroveBinResponse> GetMateri(
        //    [Query("created_at")]string created_at,
        //    [Query("id")]string id,
        //    [Query("post")]string post,
        //    [Query("total_like")]string total_like,
        //    [Query("total_retweet")]string total_retweet,
        //    [Query("username")]string username);

        [Get("/main-get-all-tweet")]
        IObservable<MangroveBinResponse> GetMateri();
    }
}