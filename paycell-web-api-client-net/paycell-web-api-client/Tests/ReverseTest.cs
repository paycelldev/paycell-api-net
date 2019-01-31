using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Inquire;
using paycell_web_api_client.Services.Provision;
using paycell_web_api_client.Services.Reverse;
using paycell_web_api_client.Util;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class ReverseTest
    {
        [TestMethod()]
        public void Test()
        {
            reverseRequest request = new ReverseRequestFactory().Build();
            request.msisdn = "5465553333";
            request.originalReferenceNumber = new ProvisionTest().ProvisionTestMethod();
            request.requestHeader.clientIPAddress = "4.4.4.4";
            request.merchantCode = Constants.MERCHANT_CODE;
            reverseResponse response =  new ReverseClientService().SoapClient(request);

            Assert.IsNotNull(response);
        }

    }
}