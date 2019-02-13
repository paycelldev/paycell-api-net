using paycell_web_api_client.Util;
using System;
using System.Text.RegularExpressions;

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

            try
            {
                Validation();
                return request;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        public void Validation()
        {

            Regex regex = new Regex("^[0-9]+$");

            if (!regex.IsMatch(request.expireDateMonth) || request.expireDateMonth.Length != 2)
            {
                throw new Exception("Hatalı expireDateMonth formatı! Sadece rakam girilmeli ve iki hane olmalı.");
            }

            if (!regex.IsMatch(request.creditCardNo) || request.creditCardNo.Length != 16)
            {
                throw new Exception("Hatalı creditCardNo formatı! Sadece rakam girilmeli ve onaltı hane olmalı.");
            }

            if (!regex.IsMatch(request.expireDateYear) || request.expireDateYear.Length != 2)
            {
                throw new Exception("Hatalı expireDateYear formatı! Sadece rakam girilmeli ve iki hane olmalı.");
            }

            if (request.cvcNo != "" && (!regex.IsMatch(request.cvcNo) || request.cvcNo.Length != 3))
            {
                throw new Exception("Hatalı cvcNo formatı! Sadece rakam girilmeli ve üç hane olmalı.");
            }
        }

    }
}