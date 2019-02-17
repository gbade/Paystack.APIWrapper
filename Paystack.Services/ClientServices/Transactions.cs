using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paystack.Business.StoreManagers;
using Paystack.Entities.Requests;
using Paystack.Entities.Responses;
using Paystack.Business.Utilities;

namespace Paystack.Business.ClientServices
{
    public class Transactions
    {
        private string _contentRootPath;
        private readonly IConfigSettingManager _configManager;

        public Transactions(IConfigSettingManager configManager, string contentRootPath)
        {
            _contentRootPath = contentRootPath;
            _configManager = configManager;
        }

        public InitializeResponse InitializeTransaction(InitializeRequest payload)
        {
            string url = _configManager.BaseUrl + "transaction/initialize";
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallPostAction<InitializeResponse, InitializeRequest>(payload, url, seckey);
        }

        public VerifyResponse VerifyTransaction(string reference)
        {
            string url = _configManager.BaseUrl + "transaction/verify/" + reference;
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallGetAction<VerifyResponse>(url, seckey);
        }

        public ListResponse ListTransactions()
        {
            string url = _configManager.BaseUrl + "transaction";
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallGetAction<ListResponse>(url, seckey);
        }

        public FetchResponse FetchTransaction(int id)
        {
            string url = _configManager.BaseUrl + "transaction/" + id;
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallGetAction<FetchResponse>(url, seckey);
        }

        public R ChargeAuthorization<R>(ChargeAuthorizationRequest payload)
        {
            string url = _configManager.BaseUrl + "transaction/charge_authorization";
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallPostAction<R, ChargeAuthorizationRequest>(payload, url, seckey);
        }

        public TransactionTimelineResponse TransactionTimeline(int id)
        {
            string url = _configManager.BaseUrl + "transaction/timeline/" + id;
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallGetAction<TransactionTimelineResponse>(url, seckey);
        }

        public TransactionTotalsResponse TransactionTotals()
        {
            string url = _configManager.BaseUrl + "transaction/totals";
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallGetAction<TransactionTotalsResponse>(url, seckey);
        }

        public ExportResponse ExportTransactions()
        {
            string url = _configManager.BaseUrl + "transaction/export";
            string seckey = _configManager.SecKey;
            var _client = new RestActions(_contentRootPath);
            return _client.CallGetAction<ExportResponse>(url, seckey);
        }
    }
}
