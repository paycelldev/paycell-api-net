using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Inquire;
using paycell_web_api_client.Services.Provision;

namespace paycell_web_api_client.Tests
{
    [TestClass()]
    public class InquireTest
    {
        [TestMethod()]
        public void Test()
        {
            inquireRequest request = new InquireRequestFactory().Build();
            request.msisdn = "5465553333";
            request.originalReferenceNumber = "00120190102131139039";
            request.requestHeader.clientIPAddress = "4.4.4.4";
            inquireResponse response =  new InquireClientService().SoapClient(request);

            Assert.IsNotNull(response);
        }

    }
}