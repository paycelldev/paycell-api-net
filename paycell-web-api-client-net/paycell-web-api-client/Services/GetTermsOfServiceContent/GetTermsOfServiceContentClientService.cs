using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.GetTermsOfServiceContent
{
    public class GetTermsOfServiceContentClientService : BaseApiClientServiceImpl<getTermsOfServiceContentRequest, getTermsOfServiceContentResponse>
    {

        public override getTermsOfServiceContentResponse OptionalRequest(string requestType, getTermsOfServiceContentRequest requestObject)
        {
            getTermsOfServiceContentResponse response = new getTermsOfServiceContentResponse();

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.GET_TERMS_OF_SERVICE_CONTENT, requestObject);
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

        public override getTermsOfServiceContentResponse SoapClient(getTermsOfServiceContentRequest requestObject)
        {

            getTermsOfServiceContentResponse response = ProvisionServiceTool.getTermsOfServiceContent(requestObject);

            return response;
        }
    }
}