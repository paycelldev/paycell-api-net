using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.Provision
{
    public class GetProvisionHistoryClientService : BaseApiClientServiceImpl<getProvisionHistoryRequest, getProvisionHistoryResponse>
    {

        public override getProvisionHistoryResponse SoapClient(getProvisionHistoryRequest requestObject)
        {

            getProvisionHistoryResponse getCardsResponse = ProvisionServiceTool.getProvisionHistory(requestObject);

            return getCardsResponse;
        }

        public override getProvisionHistoryResponse OptionalRequest(string requestType, getProvisionHistoryRequest requestObject)
        {
            getProvisionHistoryResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.GET_PROVISION_HISTORY_URL, requestObject);
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
                string message = "Genel Hata!";
                throw new Exception(message);
            }
        }
    }
}