using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paystack.APIWrapper.Models.Responses
{
    public class TransactionResponse
    {
    }

    public class InitializeResponse
    {
        public Boolean Status { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }

        public InitializeResponse()
        {
            Data = new Data();
        }
    }

    public class Data
    {
        public string AuthorizationUrl { get; set; }
        public string AccessCode { get; set; }
        public string Reference { get; set; }
    }

    public class VerifyResponse
    {

    }

    public class VerifyInvalidResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class ListResponse
    {

    }
}
