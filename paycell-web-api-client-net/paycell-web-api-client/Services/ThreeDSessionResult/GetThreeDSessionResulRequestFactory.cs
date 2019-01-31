using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.ThreeDSession
{
    public class GetThreeDSessionResultRequestFactory : BaseFactory
    {
        public getThreeDSessionResultRequest request;

        public static target MERCHANT_TARGET = target.MERCHANT;
        public static target PAYCELL_TARGET = target.PAYCELL;

        /**
         * Request başlatılır.
         */
        public GetThreeDSessionResultRequestFactory()
        {
            request = new getThreeDSessionResultRequest()
            {
                requestHeader = CreateRequestHeader()
            };
        }

        /**
         *
         * clientIPAddress : Müşteri IP bilgisi
         *
         * msisdn : Müşterinin uygulamaya login olduğu telefon numarası. Ülke kodu bilgisi iletilmez.
         *
         * threeDSessionId : getThreeDSession method’u ile alınan threeDSessionId değeridir.
         *
         * Target=MERCHANT olduğunda iletilir. Ödeme işleminin başlatıldığı Paycell’de tanımlı üye işyeri
         * kodu bilgisi gönderilir. Entegrasyon sonrasında her tanımlanan yeni üye işyeri için Paycell
         * tarafından merchantCode değeri paylaşılır.
         *
         */

        /**
         * Üretilen request döndürülür.
         *
         * @return
         * @throws Exception clientIpAddress/msisdn/target/transactionType boş ise fırlatılır.
         */
        public getThreeDSessionResultRequest Build()
        {
            Validate();
            return request;
        }

        /**
         *
         * @throws Exception clientIpAddress/msisdn/target/transactionType boş ise fırlatılır.
         */
        private void Validate()
        {

        }

    }
}