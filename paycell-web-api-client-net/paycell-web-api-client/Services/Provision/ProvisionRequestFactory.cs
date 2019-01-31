using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.Provision
{
    public class ProvisionRequestFactory : BaseFactory
    {

        public provisionRequest request;


        /**
         * Request başlatılır.
         *
         * ReferenasNumber: Üye iş yeri tarafından işlem için oluşturulan tekil nodur. ilk 3 hanesi üye iş
         * yerine özeldir paycell tarafından belirlenir. 20 haneli numeric numaradır.
         *
         * MerchantCode: Üye İş Yerine özeldir. Paycell tarafından belirlenir.
         */
        public ProvisionRequestFactory()
        {
            request = new provisionRequest()
            {
                merchantCode = Constants.MERCHANT_CODE,
                referenceNumber = UniqueIdGenerator.GenerateReferanceNumber(),
                requestHeader = CreateRequestHeader()
            };
        }

        public provisionRequest Build()
        {
            Validate();
            return request;
        }

        /**
         * clientIpAddress : clientIPAddress Müşteri IP'si
         * 
         * msisdn : Müşteri telefon numarası "\d{10}" formatında gönderilir. Ülke kodu içermez.
         * 
         * cardId : işlem yapılmak istenen kartın tekil numarasıdır. Kayıtlı olmayan kart ile işlem yapılıyorsa null gönderilir.
         *
         * amount : Provision miktarı
         * 
         * currency : İşlem döviz cinsini belirler.TRY, EUR, USD gibi
         * 
         * installmentCount : Taksit sayısı tek çekim işlemler için 0 yada null gönderilir.
         * Taksit sayısı bilgisidir. Taksitsiz işlemlerde boş olarak veya 0 olarak gönderilebilir.
         * 
         * pointAmount : İleride kullanılmak üzere ayrılmıştır. Kart puan bilgisidir.
         * 
         * paymentType : Ödeme işlem tipini belirtir, ön otorizasyon uygulaması söz konusu değilse SALE değeri gönderilir[SALE, PREAUTH, POSTAUTH].
         * 
         *
         */

        public ProvisionRequestFactory AddExtraParameter(String addkey, String addvalue)
        {
            extraParameter extraParameter = new extraParameter()
            {
                key = addkey,
                value = addvalue

            };
            request.extraParameters.Concat(new extraParameter[] { extraParameter });
            return this;
        }

        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null) {
              throw new Exception("ClientIpAddress must be set first.");
            }
            if (request.msisdn == null) {
              throw new Exception("Msisdn must be set first");
            }
            if (request.amount == null) {
              throw new Exception("Amount must be set first");
            }
            if (request.currency == null) {
              throw new Exception("Currency must be set first");
            }
        }
    }
}
 