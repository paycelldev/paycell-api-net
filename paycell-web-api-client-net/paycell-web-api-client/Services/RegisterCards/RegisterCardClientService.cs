using System;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Services.RegisterCards
{
    public class RegisterCardClientService : BaseApiClientServiceImpl<registerCardRequest, registerCardResponse>
    {

        public override registerCardResponse SoapClient(registerCardRequest requestObject)
        {

            registerCardResponse getCardsResponse = ProvisionServiceTool.registerCard(requestObject);

            return getCardsResponse;
        }

        public override registerCardResponse OptionalRequest(string requestType, registerCardRequest requestObject)
        {
            registerCardResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.REGISTER_CARD_URL, requestObject);
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