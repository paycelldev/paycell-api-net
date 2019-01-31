using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.GetCard;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class GetCardsTest
    {
        [TestMethod()]
        public void RunTest()
        {
            getCardsResponse response = GetCards();
            Assert.IsNotNull(response);
        }

        public getCardsResponse GetCards()
        {
            GetCardsClientService client = new GetCardsClientService();
            getCardsRequest request = TestData();
            getCardsResponse response = new getCardsResponse();

            // for SOAP
            //response = client.SoapClient(request);
            //Assert.IsNotNull(response);

            // for REST
            response = client.RestClient(Constants.GET_CARDS_URL, TestData());

            return response;
        }

        public getCardsRequest TestData()
        {
            getCardsRequest getCardsRequest = new getCardsRequest()
            {
                requestHeader = new requestHeader()
                {
                    applicationName = "PORTALTEST",
                    applicationPwd = "ZDyXmMLWE2z7OzJU",
                    clientIPAddress = "10.252.187.81",
                    transactionDateTime = "20160309084056197",
                    transactionId = "12345678901234567893"
                },

                msisdn = "905304018286"
            };

            return getCardsRequest;
        }
    }
}