using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.Reverse
{
    public class ReverseClientService : BaseApiClientServiceImpl<reverseRequest, reverseResponse>
    {

        public override reverseResponse SoapClient(reverseRequest requestObject)
        {

            reverseResponse response = ProvisionServiceTool.reverse(requestObject);

            return response;
        }

        public override reverseResponse OptionalRequest(string requestType, reverseRequest requestObject)
        {
            reverseResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.REVERSE_URL, requestObject);
            }

            if (response != null && response.responseHeader.responseCode == "0")
            {
                return response;
            }
            else if (response != null)
            {
                string message = response.responseHeader.responseCode + " " + response.responseHeader.responseDescription;
                throw new Exception(message);
            }
            else
            {
                string message = "Genel Hata!";
                throw new Exception(message);
            }
        }
    }
}