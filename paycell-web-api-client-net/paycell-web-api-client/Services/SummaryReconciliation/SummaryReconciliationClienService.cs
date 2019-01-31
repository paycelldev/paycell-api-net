using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.SummaryReconciliation
{
    public class SummaryReconciliationClienService : BaseApiClientServiceImpl<summaryReconciliationRequest, summaryReconciliationResponse>
    {

        public override summaryReconciliationResponse SoapClient(summaryReconciliationRequest requestObject)
        {
            return ProvisionServiceTool.summaryReconciliation(requestObject);
        }

        public override summaryReconciliationResponse OptionalRequest(string requestType, summaryReconciliationRequest requestObject)
        {
            summaryReconciliationResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.SUMMARY_RECONCILIATION_URL, requestObject);
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
                throw new Exception("Genel Hata!");
            }
        }
    }
}