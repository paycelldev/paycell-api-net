using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.Provision
{
    public class RefundClientService : BaseApiClientServiceImpl<refundRequest, refundResponse>
    {

        public override refundResponse SoapClient(refundRequest requestObject)
        {

            refundResponse response = ProvisionServiceTool.refund(requestObject);

            return response;
        }

        public override refundResponse OptionalRequest(string requestType, refundRequest requestObject)
        {
            refundResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.REFUND_URL, requestObject);
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