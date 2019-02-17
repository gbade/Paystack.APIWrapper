using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Entities.Responses
{
    class TransactionResponse
    {}

    public class InitializeResponse
    {
        [JsonProperty("status")]
        public Boolean Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }

        public InitializeResponse() =>
            Data = new Data();        
    }

    public class Data
    {
        [JsonProperty("authorization_url")]
        public string AuthorizationUrl { get; set; }
        [JsonProperty("access_code")]
        public string AccessCode { get; set; }
        [JsonProperty("reference")]
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

    public class FetchResponse
    {

    }

    public class TransactionTimelineResponse
    {

    }

    public class ChargeAuthorizationResponse
    {

    }

    public class CHargeAuthorization400Response
    {
        [JsonProperty("status")]
        public Boolean Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class TransactionTotalsResponse
    {

    }

    public class ExportResponse
    {
        [JsonProperty("status")]
        public Boolean Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public DataExport Path { get; set; }

        public ExportResponse() =>
            Path = new DataExport();
    }

    public class DataExport
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
