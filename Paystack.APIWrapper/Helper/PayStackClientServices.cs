using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Paystack.APIWrapper.Models.Responses;
using Paystack.APIWrapper.Models.Requests;
using Paystack.APIWrapper.Models;


namespace Paystack.APIWrapper.Helper
{
    public class PayStackClientServices
    {
        private readonly AppSettings _appSettings;
        private readonly string _contentRootPath;
        private IConfiguration configuration;

        public PayStackClientServices(AppSettings appSettings, string contentRootPath, IConfiguration _configuration)
        {
            _appSettings = appSettings;
            _contentRootPath = contentRootPath;
            configuration = _configuration;
        }

        public R CallRestAction<R, T>(T model, string url, string seckey)
        {
            if (model == null) return default(R);
            var response = default(R);
            try
            {
                var restResponse = JsonHelper.PostRequest(_contentRootPath, url, model, seckey);

                if (restResponse.Content != null && restResponse.Content.Length > 0)
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse.Content);
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R CallGetAction<R>(string url, string seckey)
        {
            var response = default(R);
            try
            {
                var restResponse = JsonHelper.GetRequest(_contentRootPath, url, seckey);

                if (restResponse.Content != null && restResponse.Content.Length > 0)
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse.Content);
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public TransactionResponse InitializeTransaction(InitializeRequest payload)
        {
            string url = _appSettings.BaseUrl + "transaction/initialize";
            string seckey = _appSettings.SecKey;
            return CallRestAction<TransactionResponse, InitializeRequest>(payload, url, seckey);
        }

        public VerifyResponse VerifyTransaction(string reference)
        {
            string url = _appSettings.BaseUrl + "transaction/verify/" + reference;
            string seckey = _appSettings.SecKey;
            return CallGetAction<VerifyResponse>(url, seckey);
        }
    }
}
