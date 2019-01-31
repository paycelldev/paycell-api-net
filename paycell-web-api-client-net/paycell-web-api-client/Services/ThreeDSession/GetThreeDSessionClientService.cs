using System;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Services.ThreeDSession
{
    public class GetThreeDSessionClientService : BaseApiClientServiceImpl<getThreeDSessionRequest, getThreeDSessionResponse>
    {

        public override getThreeDSessionResponse SoapClient(getThreeDSessionRequest requestObject)
        {

            getThreeDSessionResponse getCardsResponse = ProvisionServiceTool.getThreeDSession(requestObject);

            return getCardsResponse;
        }

        public override getThreeDSessionResponse OptionalRequest(string requestType, getThreeDSessionRequest requestObject)
        {
            getThreeDSessionResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.GET_THREE_D_SESSION_URL, requestObject);
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