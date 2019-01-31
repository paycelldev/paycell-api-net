using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
namespace paycell_web_api_client.Services.ProvisionForMarketPlace
{
    public class ProvisionForMarketPlaceClientService : BaseApiClientServiceImpl<provisionForMarketPlaceRequest, provisionForMarketPlaceResponse>
    {

        public override provisionForMarketPlaceResponse SoapClient(provisionForMarketPlaceRequest requestObject)
        {

            return ProvisionServiceTool.provisionForMarketPlace(requestObject);

        }

        public override provisionForMarketPlaceResponse OptionalRequest(string requestType, provisionForMarketPlaceRequest requestObject)
        {
            provisionForMarketPlaceResponse response = new provisionForMarketPlaceResponse();

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.PROVISION_URL, requestObject);
            }

            if (response != null && response.responseHeader.responseCode == "0")
            {
                return response;

            } else if (response != null)
            {
                string message = response.responseHeader.responseCode + " " + response.responseHeader.responseDescription;
                throw new Exception(message);

            } else
            {
                throw new Exception("Genel Hata!");
            }
        }
    }
}