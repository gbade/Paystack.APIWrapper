using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Entities.Requests
{
    class TransactionRequest
    {}

    public class InitializeRequest
    {
        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("plan")]
        public string Plan { get; set; }
        [JsonProperty("invoice_limit")]
        public Int32 InvoiceLimit { get; set; }
        [JsonProperty("metadata")]
        public string MetaData { get; set; }
        [JsonProperty("subaccount")]
        public string SubAccount { get; set; }
        [JsonProperty("transaction_charge")]
        public Int32 TransactionCharge { get; set; }
        [JsonProperty("bearer")]
        public string Bearer { get; set; }
        [JsonProperty("channels")]
        public List<string> Channels { get; set; }
    }

    public class VerfiyRequest
    {

    }

    public class ListRequest
    {

    }

    public class ChargeAuthorizationRequest
    {

    }
}
