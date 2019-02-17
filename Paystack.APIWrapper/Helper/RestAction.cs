using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Paystack.APIWrapper.Models;
using Microsoft.Extensions.Configuration;

namespace Paystack.APIWrapper.Helper
{
    public class RestAction
    {
        private readonly AppSettings _appSettings;
        private readonly string _contentRootPath;
        private IConfiguration configuration;

        public RestAction(AppSettings appSettings, string contentRootPath, IConfiguration _configuration)
        {
            _appSettings = appSettings;
            _contentRootPath = contentRootPath;
            configuration = _configuration;
        }

        public R CallPostAction<R, T>(T model, string url, string seckey)
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
    }
}
