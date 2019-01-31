using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.SummaryReconciliation;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class SummaryReconciliationTest
    {
        [TestMethod()]
        public void Test()
        {
            SummaryReconciliationRequestFactory factory = new SummaryReconciliationRequestFactory();
            summaryReconciliationRequest request = new summaryReconciliationRequest();
            summaryReconciliationResponse response = new summaryReconciliationResponse();
            SummaryReconciliationClienService service = new SummaryReconciliationClienService();

            factory.request.requestHeader.clientIPAddress = ("4.4.4.4");
            factory.request.reconciliationDate = ("20160404");
            factory.request.totalSaleAmount = ("0");
            factory.request.totalReverseAmount = ("0");
            factory.request.totalRefundAmount = ("0");
            factory.request.totalSaleCountSpecified = true;
            factory.request.totalRefundCountSpecified = true;
            factory.request.totalReverseCountSpecified = false;
            factory.request.totalSaleCount = 0;
            factory.request.totalReverseCount = 0;
            factory.request.totalRefundCount = 0;

            request = factory.Build();

            response = service.SoapClient(request);

            Assert.IsNotNull(response);
        }

    }
}