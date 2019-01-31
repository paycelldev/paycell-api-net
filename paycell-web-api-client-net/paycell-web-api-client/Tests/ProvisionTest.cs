using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Provision;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class ProvisionTest
    {
        [TestMethod()]
        public void Test()
        {


            Assert.IsNotNull(ProvisionTestMethod());
        }

        public string ProvisionTestMethod()
        {
            String msisdn = "905465553333";
            String cardId = "13cdfdfe-67ad-46ce-8cce-eff537b0bdf0";
            String amount = "155";
            String currency = "TRY";
            paymentType paymentType = paymentType.SALE;

            provisionRequest request = new ProvisionRequestFactory().Build();
            request.msisdn = msisdn;
            request.cardId = cardId;
            request.amount = amount;
            request.currency = currency;
            request.requestHeader.clientIPAddress = "4.4.4.4";
            request.paymentTypeSpecified = true;
            request.paymentType = paymentType.SALE;
            //provisionResponse response = new ProvisionClientService().RestClient(Constants.PROVISION_URL,request);
            provisionResponse response = new ProvisionClientService().SoapClient(request);
            Assert.IsNotNull(response);
            Assert.AreEqual("Success", response.responseHeader.responseDescription);
            return request.referenceNumber;
        }

    }
}