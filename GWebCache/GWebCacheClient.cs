﻿using GWebCache.Client;
using GWebCache.Extensions;
using GWebCache.ReponseProcessing;
using GWebCache.Reponses;

namespace GWebCache
{
    public class GWebCacheClient : IGWebCacheClient
    {
        private GWebCacheHttpClient gWebCacheHttpClient;
        private Uri _host;

        public GWebCacheClient(string host, GWebCacheClientConfig? config = null) {
            if (!string.IsNullOrWhiteSpace(host) && Uri.TryCreate(host, new UriCreationOptions(), out var uri)){
                gWebCacheHttpClient = new(config: config ?? GWebCacheClientConfig.Default);
                _host = uri;
            }else{
                throw new ArgumentException("Invalid host");
            }
        }

        public bool CheckIfAlive()
        {
            var pingResponse = Ping();
            return pingResponse.WasSuccessful;
        }

        public Result<PongResponse> Ping()
        {
            return GetWithParam<PongResponse>("ping", "1");
        }

        public Result<StatFileResponse> GetStats()
        {
            return GetWithParam<StatFileResponse>("stats", "1");
        }

        public Result<HostfileResponse> GetHostfile()
        {
            return GetWithParam<HostfileResponse>("hostfile", "1");
        }

        private Result<T> GetWithParam<T>(string param, string value) where T : GWebCacheResponse, new()
        {
            var queryDict = new Dictionary<string, string>();
            queryDict[param] = value;
            string url = _host.GetUrlWithQuery(queryDict);
            var response = gWebCacheHttpClient.GetAsync(url).Result;
            return new Result<T>().Execute(response);
        }
    }
}
