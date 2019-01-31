using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.GetProvisionHistory;
using paycell_web_api_client.Services.Provision;
using paycell_web_api_client.Services.ProvisionForMarketplace;
using paycell_web_api_client.Services.ProvisionForMarketPlace;
using paycell_web_api_client.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class GetProvisionHistoryTest
    {
        [TestMethod()]
        public void Test()
        {


            Assert.IsNotNull(GetProvisionHistoryTestMethod());
        }

        public string GetProvisionHistoryTestMethod()
        {

            GetProvisionHistoryRequestFactory factory = new GetProvisionHistoryRequestFactory();
            factory.request.requestHeader.clientIPAddress = ("4.4.4.4");
            factory.request.reconciliationDate = "20181121";

            getProvisionHistoryRequest request = factory.Build();

            getProvisionHistoryResponse response = 
                new GetProvisionHistoryClientService().SoapClient(request);
            
            Assert.IsNotNull(response);
            Assert.AreEqual("Success", response.responseHeader.responseDescription);
            return response.responseHeader.responseCode;
        }

    }
}