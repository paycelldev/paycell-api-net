using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.DeleteCard;
using paycell_web_api_client.Services.RegisterCards;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class DeleteCardTest
    {

        [TestMethod()]
        public void RunTest()
        {
            //RegisterCardTest registerCardTest = new RegisterCardTest();
            string msisdn = "905465553333";
            string cardId = "427748e7-03a8-4911-b919-d5396ec3e78a";
            deleteCardResponse response = DeleteCard(msisdn, cardId); 
            Assert.IsNotNull(response);

        }

        public deleteCardResponse DeleteCard(string msisdn, string cardId)
        {
            DeleteCardRequestFactory factory = new DeleteCardRequestFactory();
            factory.request.requestHeader.clientIPAddress = "4.4.4.4";
            factory.request.msisdn = msisdn;
            factory.request.cardId = cardId;
            deleteCardRequest request = factory.Build();

            deleteCardResponse response = new DeleteCardClientService().RestClient(Constants.DELETE_CARD_URL, request);
            Assert.IsNotNull(response);
            Assert.AreEqual("Success", response.responseHeader.responseDescription);
            return response;
        }

    }
}