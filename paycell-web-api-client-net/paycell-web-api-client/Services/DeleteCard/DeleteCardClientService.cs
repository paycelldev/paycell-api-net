using System;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Services.DeleteCard
{
    public class DeleteCardClientService : BaseApiClientServiceImpl<deleteCardRequest, deleteCardResponse>
    {

        public override deleteCardResponse SoapClient(deleteCardRequest requestObject)
        {

            deleteCardResponse getCardsResponse = ProvisionServiceTool.deleteCard(requestObject);

            return getCardsResponse;
        }

        public override deleteCardResponse OptionalRequest(string requestType, deleteCardRequest requestObject)
        {
            deleteCardResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.DELETE_CARD_URL, requestObject);
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