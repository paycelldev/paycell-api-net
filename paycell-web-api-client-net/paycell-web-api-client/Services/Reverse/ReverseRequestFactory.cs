using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.Reverse
{
    public class ReverseRequestFactory : BaseFactory
    {

        public reverseRequest request;

        /**
         * Requet başlatılır.
         *
         * ReferenceNumber: Üye işyeritarfından üretilen tekil değerdir. Provisiona özgüdür. ilk 3 hanesi
         * Paycell tarafından üye işyeri için tanımlanır. 20 haneli numerik bir değerdir.
         *
         * MerchantCode: Paycell taraffından üye iş yeri için tanımlanır.
         */
        public ReverseRequestFactory()
        {
            request = new reverseRequest()
            {
                merchantCode = Constants.MERCHANT_CODE,
                referenceNumber = UniqueIdGenerator.GenerateReferanceNumber(),
                requestHeader = CreateRequestHeader()
            };
        }

        /**
        * msisdn : Müşterinin uygulamaya login olduğu telefon numarası. Ülke kodu iletilmez.
        *
        * originalReferanceNumber :İptal edilecek işlemin "referenceNumber" değeridir.
        * 
        * referanceNumber : Üye işyeri uygulaması tarafından üretilecek unique numerik 
        * işlem referans numarası değeridir. İlk 3 hanesi uygulama bazında unique’dir, 
        * bu değer entegrasyon aşamasında Paycell tarafından bildirilecektir.
        * 
        * merchantCode : Ödeme işleminin başlatıldığı Paycell’de tanımlı üye işyeri 
        * kodu bilgisi gönderilir. Entegrasyon sonrasında her tanımlanan yeni üye işyeri
        * için Paycell tarafından merchantCode değeri paylaşılır.
        * 
        */


        public reverseRequest Build()
       {
           return request;
       }

        /**
         *
         * @throws Exception clientIpAddress/msisdn/OriginalReferenceNumber boş ise fırlatılır.
         */
        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null) {
              throw new Exception("ClientIpAddress must be set first.");
            }
            if (request.msisdn == null) {
              throw new Exception("Msisdn must be set first.");
        }
            if (request.originalReferenceNumber == null) {
              throw new Exception("OriginalReferenceNumber must be set first.");
            }
        }
    }
}