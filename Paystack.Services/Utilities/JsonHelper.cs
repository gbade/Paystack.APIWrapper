using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Business.Utilities
{
    public class JsonHelper
    {
        public static IRestResponse PostRequest(string contentRootPath, 
                                                string requestUrl, object data, string seckey)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                IRestResponse response = new RestResponse();
                var client = new RestClient(requestUrl);

                var webRequest = new RestRequest(Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                webRequest.AddHeader("Authorization", seckey);
                webRequest.AddHeader("content-type", "application/json");
                webRequest.AddParameter("application/json", json, ParameterType.RequestBody);

                Task.Run(async () =>
                {
                    response = await PostResponseContentAsync(client, webRequest) as RestResponse;
                }).Wait();
                return response;
            }
            catch (Exception ex)
            {
                Logger.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static IRestResponse GetRequest(string contentRootPath, string requestUrl, string seckey)
        {
            try
            {
                IRestResponse response = new RestResponse();
                var client = new RestClient(requestUrl);
                
                var webRequest = new RestRequest(Method.GET);
                webRequest.AddHeader("Authorization", seckey);

                Task.Run(async () =>
                {
                    response = await GetResponseContentAsync(client, webRequest) as RestResponse;
                }).Wait();

                return response;
            }
            catch (Exception ex)
            {
                Logger.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static Task<IRestResponse> PostResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>(); 
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
