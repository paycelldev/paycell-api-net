
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace paycell_web_api_client.Services.ProvisionForMarketplace
{
    public class ProvisionForMarketPlaceRequestFactory : BaseFactory
    {
        public provisionForMarketPlaceRequest request;

        /**
         * Requet başlatılır.
         *
         * ReferenceNumber: Üye işyeritarfından üretilen tekil değerdir. Provisiona özgüdür. ilk 3 hanesi
         * Paycell tarafından üye işyeri için tanımlanır. 20 haneli numerik bir değerdir.
         *
         * MerchantCode: Paycell taraffından üye iş yeri için tanımlanır.
         */
        public ProvisionForMarketPlaceRequestFactory()
        {
            request = new provisionForMarketPlaceRequest()
            {
                requestHeader = CreateRequestHeader(),
                referenceNumber = UniqueIdGenerator.GenerateReferanceNumber(),
                merchantCode = Constants.MERCHANT_CODE
            };
        }

        /**
         *
         *clientIPAddress : Müşteri IP bilgisi
         *
         * msisdn : Müşteri telefon no ülke kodu olmadan işlenecektir. "\d{10}" formatında olmalıdır.
         * 
         * amount : İade edilmesi istenen işlem tutarıdır. Son 2 hane KURUŞ'u ifade eder. Virgül kullanılmaz.
         * Örnekler: 1TL = 100 15,25TL = 1525
         *
         * currency : İşlem döviz cinsini belirler. TRY, EUR, USD, vb.
         *
         * installmentCount: Taksit sayısı bilgisidir. Taksitsiz işlemlerde boş olarak veya 0 olarak gönderilebilir.
         *
         * pointAmount : İleride kullanılmak üzere ayrılmıştır. İade edilmesi istenen kart puan bilgisidir.
         *
         * paymentType : Ödeme işlem tipini belirtir, ön otorizasyon uygulaması söz konusu değilse SALE değeri gönderilir.
         * [SALE, PREAUTH, POSTAUTH]
         *
         * İleride kullanılmak üzere ayrılmıştır. Sanal Pos bankası kodu iletilir.
         *
         * threeDSessionId : Ödeme işleminin 3D doğrulama yöntemi ile yapılması durumunda getThreeDSession servisi cevabında
         * alınan session ID bilgisidir.
         *
         * cardToken : Kart numarası girilerek yapılmak istenen ödeme işlemlerinde getCardToken servisi alınan değer
         * veya kayıtlı kart kullanımında cvc ile ödeme yapılmasına ilişkin getCardToken servisi ile cvc
         * karşılığında alınan token değeri.
         *
         * extraParameters : Ödeme işlemine ilişkin ek bir parametre değeri opsiyonel olarak iletilebilir.
         * 
         * subMerchants : Ödeme işlemine ilişkin alt üye işyeri bilgileri iletilebilir.
         * 
         * customerEMail : 	Müşteri email bilgisi iletilir.
         * 
         */

        public ProvisionForMarketPlaceRequestFactory AddExtraParameter(String key, String value)
        {
            extraParameter parameter = new extraParameter()
            {
                key = key,
                value = value
            };
            request.extraParameters.Concat(new extraParameter[] {parameter});
            return this;
        }

        public ProvisionForMarketPlaceRequestFactory AddSubMerchant(String subMerchantKey, String subMerchantPrice)
        {
            subMerchant subMerchant = new subMerchant()
            {
                subMerchantKey = subMerchantKey,
                subMerchantPrice = subMerchantPrice
            };
            request.subMerchants.Concat(new subMerchant[] {subMerchant});
            return this;
        }

        /**
         * Üretilen request döndürülür.
         *
         * @return
         * @throws Exception msisdn/amount/currency/paymentType/clientIAddress boş ise fırlatılır.
         */
        public provisionForMarketPlaceRequest Build()
        {
            Validate();
            return request;
        }

        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null) {
                throw new Exception("ClientIpAdress must be set first.");
            }
            if (request.msisdn == null) {
                throw new Exception("Msisdn must be set first.");
            }
            if (request.amount == null) {
                throw new Exception("Amount must be set first.");
            }
            if (request.currency == null) {
                throw new Exception("Currency must be set first.");
            }
            if (request.paymentType == null) {
                throw new Exception("PaymentType must be set first.");
            }
        }
    }
}