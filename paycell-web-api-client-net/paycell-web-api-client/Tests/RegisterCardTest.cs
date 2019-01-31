using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.RegisterCards;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class RegisterCardTest
    {

        [TestMethod()]
        public void TestRegisterCard()
        {

            string cardId = TestMethod();
            Assert.IsNotNull(cardId);
            //deleteCardTestUtil.deleteCard(cardId, msisdn, connectionMethod);
        }

        public string TestMethod()
        {
            string msisdn = "905465553333";
            string creditCardNo = "5254135922971748";
            string expireDateMonth = "12";
            string expireDateYear = "20";
            string cvcNo = "000";
            string cardId = RegisterCard(msisdn, creditCardNo, expireDateMonth, expireDateYear, cvcNo);
            return cardId;
        }

        public string RegisterCard(string msisdn, string creditCardNo, string expireDateMonth, string expireDateYear, string cvcNo)
        {
            string cardToken = new GetCardTokenTest().GetCardToken(creditCardNo, expireDateMonth, expireDateYear, cvcNo);

            registerCardRequest request = null;
            RegisterCardRequestFactory factory = new RegisterCardRequestFactory();
            factory.request.cardToken = cardToken;
            factory.request.isDefault = false;
            factory.request.msisdn = msisdn;
            factory.request.requestHeader.clientIPAddress = "10.250.171.15";

            request = factory.Build();

            registerCardResponse response = new RegisterCardClientService().RestClient(Constants.REGISTER_CARD_URL, request);
            Assert.IsNotNull(response);
            Assert.AreEqual("Success", response.responseHeader.responseDescription);
            Assert.IsNotNull(response.cardId);
            return response.cardId;
        }

    }
}