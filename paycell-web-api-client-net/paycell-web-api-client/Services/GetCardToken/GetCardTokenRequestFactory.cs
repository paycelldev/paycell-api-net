using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.GetCardToken
{
    public class GetCardTokenRequestFactory
    {
        public GetCardTokenRequest request = new GetCardTokenRequest();

        public GetCardTokenRequestFactory()
        {
            
            request.header = CreateRequestHeader();
        }

        public GetCardTokenRequestFactory AddCreditCardNo(String creditCardNo)
        {
            request.creditCardNo = creditCardNo;
            return this;
        }

        public GetCardTokenRequestFactory AddExpireDate(string expireDateMonth, string expireDateYear)
        {
            request.expireDateMonth = expireDateMonth;
            request.expireDateYear = expireDateYear;
            return this;
        }

        public GetCardTokenRequestFactory AddCvcNo(string cvcNo)
        {
            request.cvcNo = cvcNo;
            return this;
        }

        public GetCardTokenRequest Build(string creditCardNo, string expireDateMonth, string expireDateYear, string cvcNo)
        {
            PreBuild();
            return request;
        }

        public GetCardTokenRequest Build()
        {
            PreBuild();
            return request;
        }

        private void PreBuild()
        {
            string transactionId = request.header.transactionId;
            string transactionDateTime = request.header.transactionDateTime;
            string hashData = HashDataGenerator.GenerateForRequest(transactionId, transactionDateTime);
            request.hashData = hashData;
        }

         public RequestHeader CreateRequestHeader()
         {
                RequestHeader RequestHeader = new RequestHeader()
                {

                    applicationName = Constants.APPLICATION_NAME,
                    transactionId = UniqueIdGenerator.GenerateTransactionId(),
                    transactionDateTime = DateTime.Now.ToString("yyyyMMddHHmmss") + "000"
                };

                return RequestHeader;
         }

    }
}