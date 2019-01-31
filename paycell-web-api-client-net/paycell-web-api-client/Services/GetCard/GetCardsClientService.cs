using System;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Services.GetCard
{
    public class GetCardsClientService : BaseApiClientServiceImpl<getCardsRequest, getCardsResponse>
    {
        public override getCardsResponse OptionalRequest(string requestType, getCardsRequest requestObject)
        {
            getCardsResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.GET_CARDS_URL, requestObject);
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

        public override getCardsResponse SoapClient(getCardsRequest requestObject)
        {
            
            getCardsResponse getCardsResponse = ProvisionServiceTool.getCards(requestObject);

            return getCardsResponse;
        }
        
    }
}