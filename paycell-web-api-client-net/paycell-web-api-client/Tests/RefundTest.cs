using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Provision;
using paycell_web_api_client.Services.Refund;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class RefundTest
    {
        [TestMethod()]
        public void Test()
        {
            refundRequest request = new RefundRequestFactory().Build();
            request.msisdn = "5465553333";
            request.amount = "2351";
            request.originalReferenceNumber = new ProvisionTest().ProvisionTestMethod();
            request.requestHeader.clientIPAddress = "4.4.4.4";
            request.merchantCode = Constants.MERCHANT_CODE;
            refundResponse response = new RefundClientService().SoapClient(request);

            Assert.IsNotNull(response);
        }

    }
}