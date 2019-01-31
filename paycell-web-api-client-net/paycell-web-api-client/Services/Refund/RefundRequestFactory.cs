using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.Refund
{
    public class RefundRequestFactory : BaseFactory
    {

        public refundRequest request;


        /**
         * Requet başlatılır.
         *
         * ReferenceNumber: Üye işyeritarfından üretilen tekil değerdir. Provisiona özgüdür. ilk 3 hanesi
         * Paycell tarafından üye işyeri için tanımlanır. 20 haneli numerik bir değerdir.
         *
         * MerchantCode: Paycell taraffından üye iş yeri için tanımlanır.
         */
        public RefundRequestFactory()
        {
            request = new refundRequest()
            {
                merchantCode = Constants.MERCHANT_CODE,
                referenceNumber = UniqueIdGenerator.GenerateReferanceNumber(),
                requestHeader = CreateRequestHeader()
            };
        }

        /**
         * 
         * msisdn : Müşterinin uygulamaya login olduğu telefon numarası. Ülke kodu iletilmez.
         * 
         * amount : İade edilmesi istenen işlem tutarıdır. Son 2 hane KURUŞ'u ifade eder. Virgül kullanılmaz.
         * Örnekler: 1TL = 100 15,25TL = 1525
         *
         * pointAmount : İleride kullanılmak üzere ayrılmıştır. İade edilmesi istenen kart puan bilgisidir.
         * 
         * originalReferenceNumber : İade edilecek işlemin "referenceNumber" değeridir.
         * 
         */


        public refundRequest Build()
        {
          Validate();
          return request;
        }

        /**
        *
        * @throws Exception clientIpAdress/msisdn/originalReferenceNumber/amount boş ise fırlatılır
        */
        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null) {
              throw new Exception("ClientIpAdress must be set first");
            }
            if (request.msisdn == null) {
              throw new Exception("Msisdn must be set first.");
            }
            if (request.originalReferenceNumber == null) {
              throw new Exception("OriginalReferenceNumber must be set first.");
            }
            if (request.amount == null) {
              throw new Exception("Amount must be set first.");
            }
        }

    }
}