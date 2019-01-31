using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.Provision
{
    public class InquireClientService : BaseApiClientServiceImpl<inquireRequest, inquireResponse>
    {

        public override inquireResponse OptionalRequest(string requestType, inquireRequest requestObject)
        {
            inquireResponse response = new inquireResponse();

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.INQUIRE_URL, requestObject);
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

        public override inquireResponse SoapClient(inquireRequest requestObject)
        {

            inquireResponse response = ProvisionServiceTool.inquire(requestObject);

            return response;
        }
    }
}