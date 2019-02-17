using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Business.Utilities
{
    public class RestActions
    {
        private readonly string _contentRootPath;

        public RestActions(string contentRootPath)
        {
            _contentRootPath = contentRootPath;
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
                Logger.ProcessError(ex, _contentRootPath);
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
                Logger.ProcessError(ex, _contentRootPath);
            }

            return response;
        }
    }
}
