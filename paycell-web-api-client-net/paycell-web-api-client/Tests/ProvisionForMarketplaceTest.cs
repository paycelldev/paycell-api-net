using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
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
    public class ProvisionForMarketplaceTest
    {
        [TestMethod()]
        public void Test()
        {


            Assert.IsNotNull(ProvisionMarketTestMethod());
        }

        public string ProvisionMarketTestMethod()
        {
            String msisdn = "905465553333";
            String cardId = "4aa05cfe-af9c-43d5-971f-a69234ffaf4d";

            ProvisionForMarketPlaceRequestFactory factory = new ProvisionForMarketPlaceRequestFactory();
            factory.request.requestHeader.clientIPAddress = ("4.4.4.4");
            factory.request.msisdn = (msisdn);
            factory.request.acquirerBankCode = ("111");
            factory.request.amount = ("2351");
            factory.request.currency = ("TRY");
            factory.request.cardId =(cardId);
            factory.request.paymentTypeSpecified = true;
            factory.request.paymentType =(paymentType.SALE);

            provisionForMarketPlaceRequest request = factory.Build();

            provisionForMarketPlaceResponse response = 
                new ProvisionForMarketPlaceClientService().SoapClient(request);
            
            Assert.IsNotNull(response);
            Assert.AreEqual("Success", response.responseHeader.responseDescription);
            return request.referenceNumber;
        }

    }
}