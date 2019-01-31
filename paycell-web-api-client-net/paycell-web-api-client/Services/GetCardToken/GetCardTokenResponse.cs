using paycell_web_api_client.ProvisionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.GetCardToken
{
    public class GetCardTokenResponse
    {
        public responseHeader header { get; set; }

        public string cardToken { get; set; }

        public string hashData { get; set; }
        
    }
}