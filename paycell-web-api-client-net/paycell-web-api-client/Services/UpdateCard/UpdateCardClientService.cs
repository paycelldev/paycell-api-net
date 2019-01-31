using System;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Services.DeleteCard
{
    public class UpdateCardClientService : BaseApiClientServiceImpl<updateCardRequest, updateCardResponse>
    {

        public override updateCardResponse SoapClient(updateCardRequest requestObject)
        {

            updateCardResponse response = ProvisionServiceTool.updateCard(requestObject);

            return response;
        }

        public override updateCardResponse OptionalRequest(string requestType, updateCardRequest requestObject)
        {

            updateCardResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.UPDATE_CARD_URL, requestObject);
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