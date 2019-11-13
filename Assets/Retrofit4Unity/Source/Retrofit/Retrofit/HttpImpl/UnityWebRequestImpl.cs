#region License
// Author: Weichao Wang     
// Start Date: 2017-05-22
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Retrofit.Converter;
using Retrofit.Methods;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
namespace Retrofit.HttpImpl
{
    public class UnityWebRequestImpl : RxHttpImplement
    {
        public void RxSendRequest<T>(IObserver<T> o, Converter.Converter convert, object request)
        {
            UnityWebRequest www = request as UnityWebRequest;
            if (www != null)
            {
                MainThreadDispatcher.SendStartCoroutine(SendRxWebRequest(o,convert,www));
            }
        }

        private IEnumerator SendRxWebRequest<T>(IObserver<T> o, Converter.Converter convert, UnityWebRequest www)
        {
            yield return www.Send();
            string errorMessage = "";
            if (IsRequestError(www, out errorMessage))
            {
                o.OnError(new Exception(errorMessage));
                yield break;
            }
            string result = GetSuccessResponse(www);
            //                        result = "[]";
            //                        result = "[asd..s]";
            //Parse Json By Type
            if (typeof(T) == typeof(string))
            {
                var resultData = (T)(object)result;
                o.OnNext(resultData);
                o.OnCompleted();
                yield break;
            }
            T data = default(T);
            bool formatError = false;
            try
            {
                data = convert.FromBody<T>(result);
            }
            catch (ConversionException e)
            {
                formatError = true;
                o.OnError(new Exception(e.Message));
            }
            if (!formatError)
            {
                o.OnNext(data);
                o.OnCompleted();
            }
        }

        public object RxBuildRequest<T>(IObserver<T> o, Converter.Converter convert, RestMethodInfo methodInfo, string url)
        {
            return BuildRequest(methodInfo, url);
        }

        public void Cancel(object request)
        {
        }

        public object BuildRequest(RestMethodInfo methodInfo, string url)
        {
            var www = ConfigureRESTfulApi(methodInfo, url);
            return www;
        }

        private static UnityWebRequest ConfigureRESTfulApi(RestMethodInfo methodInfo, string url)
        {
            UnityWebRequest www = null;
            UploadHandler uploadHandler = null;
            //handle body
            if (!string.IsNullOrEmpty(methodInfo.bodyString))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(methodInfo.bodyString);
                uploadHandler = new UploadHandlerRaw(bytes);
            }
            switch (methodInfo.Method)
            {
                case Method.Get:
                    www = UnityWebRequest.Get(url);
                    break;
                case Method.Post:
                    if (methodInfo.FieldParameterMap.Count > 0)
                    {
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        foreach (var keyValuePair in methodInfo.FieldParameterMap)
                        {
                            dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                        }
                        www = UnityWebRequest.Post(url, dict);
                        Debug.LogWarning("unityWebRequest does not support field with body");
                    }
                    else
                    {
                        www = new UnityWebRequest(url, "POST");
                        www.uploadHandler = uploadHandler;
                        www.downloadHandler = new DownloadHandlerBuffer();
                    }
                    break;
                case Method.Put:
                    www = UnityWebRequest.Put(url, methodInfo.bodyString);
                    break;
                case Method.Delete:
                    www = UnityWebRequest.Delete(url);
                    www.uploadHandler = uploadHandler;
                    www.downloadHandler = new DownloadHandlerBuffer();
                    break;
                case Method.Head:
                    www = UnityWebRequest.Head(url);
                    www.downloadHandler = new DownloadHandlerBuffer();
                    break;
                case Method.Patch:
                    throw new Exception("UnityWebRequest does not support REST Patch");
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //add headers
            if (methodInfo.Headers.Count > 0)
            {
                foreach (var keyValuePair in methodInfo.Headers)
                {
                    www.SetRequestHeader(keyValuePair.Key, keyValuePair.Value);
                }
            }
            if (methodInfo.HeaderParameterMap.Count > 0)
            {
                foreach (var keyValuePair in methodInfo.HeaderParameterMap)
                {
                    www.SetRequestHeader(keyValuePair.Key, keyValuePair.Value);
                }
            }
            return www;
        }

        public IEnumerator SendRequest(MonoBehaviour owner, object request)
        {
            UnityWebRequest www = request as UnityWebRequest;
            if (www != null)
            {
                yield return owner.StartCoroutine(SendWebRequest(www));
                yield return www;
            }
        }

        private IEnumerator SendWebRequest(UnityWebRequest www)
        {
            yield return www.Send();
        }


        public bool IsRequestError(object result, out string errorMessage)
        {
            bool isError = true;
            errorMessage = string.Empty;
            UnityWebRequest www = result as UnityWebRequest;
            if (!www.isError)
            {
                isError = false;
            }
            else
            {
                errorMessage = www.error;
            }
            return isError;
        }

        public string GetSuccessResponse(object result)
        {
            UnityWebRequest www = result as UnityWebRequest;
            return www.downloadHandler.text;
        }
    }
}