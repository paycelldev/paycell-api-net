using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.ThreeDSession;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class GetThreeDSessionResultTest
    {
        [TestMethod()]
        public void RunTest()
        {

            string threeDResultDescription = TestGetThreeDSession();
            Assert.IsNotNull(threeDResultDescription);


        }

        public string TestGetThreeDSession()
        {
            

            getThreeDSessionResultRequest request = new GetThreeDSessionResultRequestFactory().Build();
            request.msisdn = "905465553333";
            request.merchantCode = Constants.MERCHANT_CODE;
            request.threeDSessionId = "86b7d47b-ea3a-4f54-bb32-6fa571302ed1";



            //getThreeDSessionResultResponse response = new GetThreeDSessionResultClientService().RestClient(Constants.GET_THREE_D_SESSION_RESULT_URL,request);

            getThreeDSessionResultResponse response = new GetThreeDSessionResultClientService().GetThreeDSessionResultResponseHandler("SOAP", request);

            Assert.IsNotNull(response);
            return response.threeDOperationResult.threeDResultDescription;
        }

        public void TestGetThreeDSessionResult()
        {

        }

    }
}