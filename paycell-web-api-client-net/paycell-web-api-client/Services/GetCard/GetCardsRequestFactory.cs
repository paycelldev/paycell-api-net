using System;
using System.Text.RegularExpressions;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;

namespace paycell_web_api_client.Services.GetCard
{
    public class GetCardsRequestFactory : BaseFactory
    {

        public getCardsRequest request;


        public GetCardsRequestFactory()
        {
            request = new getCardsRequest()
            {
                requestHeader = CreateRequestHeader()
            };
        }


        /**
         * msisdn : Ülke kodu + Telefon No formatında iletilir.
         * 
         */

        public getCardsRequest Build()
        {
            try
            {
                Validation();
                return request;
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Validation()
        {
            if (request.msisdn == null)
            {
                throw new Exception("msisdn bos olamaz!");
            }
            if (request.requestHeader.clientIPAddress == null)
            {
                throw new Exception("clientIPAddress bos olamaz!");
            }
            MsisdnValidator(request.msisdn);
        }

        public void MsisdnValidator(string msisdn)
        {
            string firstTwoChar = msisdn.Substring(0, 2);

            Regex regex = new Regex("^[0-9]+$");

            if (!regex.IsMatch(msisdn))
            {
                throw new Exception("Hatalı Msisdn formatı! Sadece rakam girilmeli.");
            }

            if (firstTwoChar != "90")
            {
                throw new Exception("Hatalı Msisdn formatı! İlk iki karakter ülke kodu olmalı.");
            }

            if (msisdn.Length != 12)
            {
                throw new Exception("Hatalı Msisdn formatı! Ülke kodu ile birlikte 12 karakter olmalı!");
            }

        }

    }
}