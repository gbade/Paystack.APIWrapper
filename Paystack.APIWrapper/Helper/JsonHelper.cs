using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using RestSharp;

namespace Paystack.APIWrapper.Helper
{
    public class JsonHelper
    {
        private static IConfiguration configuration;
        public JsonHelper(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static IRestResponse GetRequest(string contentRootPath, string requestUrl, string seckey)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(data);
                IRestResponse response = new RestResponse();
                var client = new RestClient(requestUrl);

                var webRequest = new RestRequest(Method.GET)
                {
                    RequestFormat = DataFormat.Json
                };
                webRequest.AddHeader("Authorization", seckey);
                webRequest.AddHeader("content-type", "application/json");
                //webRequest.AddParameter("application/json", json, ParameterType.RequestBody);

                Task.Run(async () =>
                {
                    response = await PostResponseContentAsync(client, webRequest) as RestResponse;
                }).Wait();
                return response;
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, contentRootPath);
                return null;
            }
        }

        public static IRestResponse PostRequest(string contentRootPath, string requestUrl, object data, string seckey)
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
                Utilities.ProcessError(ex, contentRootPath);
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
    }
}
