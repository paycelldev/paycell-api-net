using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.ThreeDSession
{
    public class GetThreeDSessionRequestFactory : BaseFactory
    {
        public getThreeDSessionRequest request;

        public static target MERCHANT_TARGET = target.MERCHANT;
        public static target PAYCELL_TARGET = target.PAYCELL;

        /**
         * Request başlatılır.
         */
        public GetThreeDSessionRequestFactory()
        {
            request = new getThreeDSessionRequest()
            {
                requestHeader = CreateRequestHeader(),
                targetSpecified = true,
                transactionTypeSpecified = true
            };
            
        }

        /**
         *
         * clientIPAddress Müşteri IP bilgisi
         * 
         * msisdn : Müşterinin uygulamaya login olduğu telefon numarası. Ülke kodu bilgisi iletilmez.
         * 
         * target : PAYCELL ve MERCHANT değerlerini alabilir. Provizyon işlemi amacıyla kullanılıyorsa MERCHANT, kart
         * ekleme veya kart güncelleme işlemi amacıyla kullanılıyorsa PAYCELL gönderilir.
         *
         *
         * amount : İşlem tutarıdır.Son 2 hane KURUŞ'u ifade eder. Virgül kullanılmaz. Örnekler: 1TL = 100 15,25TL =
         * 1525 Kart ekleme veye kart güncelleme akışlarında kullanılması durumunda 3D doğrulamada amount
         * olarak 1 kuruş iletilebilir.
         *
         * installmentCount : Taksit sayısı bilgisidir. Taksitsiz işlemlerde boş olarak veya 0 olarak gönderilebilir.
         *
         *
         * cardId : Paycell’de tanımlı kart ile işlem yapılırsa gönderilir.
         *
         *
         * cardToken : Kart numarası girilerek işlem yapılırsa gönderilir.
         *
         */

        /**
         * Üretilen request döndürülür.
         *
         * @return
         * @throws Exception clientIpAddress/msisdn/target/transactionType boş ise fırlatılır.
         */
        public getThreeDSessionRequest Build()
        {
            PreBuild();
            Validate();
            return request;
        }

        /**
         *
         * @throws Exception clientIpAddress/msisdn/target/transactionType boş ise fırlatılır.
         */
        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null)
            {
                throw new Exception("ClientIpAddress must be set first.");
            }
            if (request.msisdn == null)
            {
                throw new Exception("Msisdn must be set first.");
            }
            if (request.target == null)
            {
                throw new Exception("Target must be set first.");
            }
            if (request.transactionType == null)
            {
                throw new Exception("TransactionType must be set first.");
            }
        }

        /**
         * Provisin işlemleri için merchant code iletilir.
         */
        private void PreBuild()
        {

            if (request.target.Equals(MERCHANT_TARGET))
            {
                request.merchantCode = Constants.MERCHANT_CODE;
            }
        }

    }
}