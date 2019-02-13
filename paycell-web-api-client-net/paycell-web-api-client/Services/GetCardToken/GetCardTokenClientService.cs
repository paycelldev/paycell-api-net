using System;
using System.Net;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Services.GetCardToken
{
    public class GetCardTokenClientService : BaseApiClientServiceImpl<GetCardTokenRequest, GetCardTokenResponse>
    {

        public GetCardTokenResponse GetCardToken(GetCardTokenRequest requestObject)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            GetCardTokenResponse response = RestClient(Constants.GET_CARD_TOKEN_URL, requestObject);

            if (response.cardToken == null || response.hashData == null)
            {
                throw new Exception( response.header.responseDescription);
            }

            if (response.hashData != GenerateHashData(response))
            {
                throw new Exception("Token Dogrulanamadı!");
            }

            return response;
        }

        private string GenerateHashData(GetCardTokenResponse response)
        {
            string transactionId = response.header.transactionId;
            string responseDateTime = response.header.responseDateTime;
            string responseCode = response.header.responseCode;
            string cardToken = response.cardToken;
            return HashDataGenerator.GenerateForResponse(transactionId, responseDateTime,
                responseCode, cardToken);
        }

        public override GetCardTokenResponse OptionalRequest(string requestType, GetCardTokenRequest requestObject)
        {
            throw new NotImplementedException();
        }

        public override GetCardTokenResponse SoapClient(GetCardTokenRequest requestObject)
        {
            throw new NotImplementedException();
        }

    }
}