using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.ThreeDSession;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class GetThreeDSessionTest
    {
        [TestMethod()]
        public void RunTest()
        {

            string threeDSessionId = TestGetThreeDSessionPaycell();
            Assert.IsNotNull(threeDSessionId);


        }

        public string TestGetThreeDSessionPaycell()
        {

            string msisdn = "905465553333";
            string cardId = "4aa05cfe-af9c-43d5-971f-a69234ffaf4d";
            string amount = "112";
            target target = target.MERCHANT;
            transactionType transactionType = transactionType.AUTH;

            string threeDSessionId = GetThreeDSessionId(target, msisdn, cardId, transactionType, amount, false);
            Assert.IsNotNull(threeDSessionId);
            return threeDSessionId;
        }

        public string GetThreeDSessionId(target target, string msisdn, string cardId, transactionType transactionType, string amount, bool isOilService)
        {

            GetThreeDSessionRequestFactory factory = new GetThreeDSessionRequestFactory();
            factory.request.target = target;
            factory.request.amount = amount;
            factory.request.msisdn = msisdn;
            factory.request.cardId = cardId;
            factory.request.transactionType = transactionType;

            getThreeDSessionRequest request = factory.Build();
                getThreeDSessionResponse response = new GetThreeDSessionClientService().SoapClient(request);
                Assert.IsNotNull(response);
                Assert.AreEqual("Success", response.responseHeader.responseDescription);
            return response.threeDSessionId;
        }
    }
}