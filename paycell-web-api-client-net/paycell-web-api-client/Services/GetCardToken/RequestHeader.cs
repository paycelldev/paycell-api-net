using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.GetCardToken
{
    public class RequestHeader
    {
        public string applicationName { get; set; }

        public string transactionId { get; set; }

        public string transactionDateTime { get; set; }
    }
}