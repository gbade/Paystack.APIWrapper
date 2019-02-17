using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Paystack.APIWrapper.Helper;
using Paystack.APIWrapper.Models;
using Paystack.APIWrapper.Models.Requests;


namespace Paystack.APIWrapper.Controllers
{
    public class TransactionController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public readonly IConfiguration _configuration;
        public PayStackClientServices _clientService;
        public readonly AppSettings _appSettings;

        public TransactionController(IOptions<AppSettings> appSettings, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRootPath = _hostingEnvironment.WebRootPath;
            _contentRootPath = _hostingEnvironment.ContentRootPath;

            _appSettings = appSettings.Value;
            _configuration = configuration;

            _clientService = new PayStackClientServices(_appSettings, _contentRootPath, _configuration);
        }

        public IActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        [Route("transaction/initialize")]
        public IActionResult Initialize([FromBody]InitializeRequest request)
        {
            var response = _clientService.InitializeTransaction(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Route("transaction/verify")]
        public IActionResult Verify(string reference)
        {
            //return "value";
            return Ok(reference);
        }


    }
}