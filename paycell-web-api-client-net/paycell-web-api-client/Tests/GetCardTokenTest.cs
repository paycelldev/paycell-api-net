using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.Services.GetCardToken;
using System;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class GetCardTokenTest
    {
        [TestMethod()]
        public void RunTest()
        {
            string cardToken = GetCardToken("4355084355084358", "12", "18", "212");
            Assert.IsNotNull(cardToken);
        }

        public string GetCardToken(string creditCardNo, string expireDateMonth, string expireDateYear, string cvcNo)
        {
            GetCardTokenClientService clientService = new GetCardTokenClientService();

            GetCardTokenRequest request = new GetCardTokenRequestFactory().AddCreditCardNo(creditCardNo)
            .AddExpireDate(expireDateMonth, expireDateYear).AddCvcNo(cvcNo).Build();
            GetCardTokenResponse response = clientService.GetCardToken(request);
            Assert.IsNotNull(response);
            string expectedHashData = GenerateHashData(response);
            Assert.AreEqual(expectedHashData, response.hashData);
            return response.cardToken;
        }

        private string GenerateHashData(GetCardTokenResponse response)
        {
            string transactionId = response.header.transactionId;
            string responseDateTime = response.header.responseDateTime;
            string responseCode = response.header.responseCode;
            string cardToken = response.cardToken;
            return HashDataGenerator.GenerateForResponse(transactionId, responseDateTime,
                responseCode, cardToken);
        }
    }
}