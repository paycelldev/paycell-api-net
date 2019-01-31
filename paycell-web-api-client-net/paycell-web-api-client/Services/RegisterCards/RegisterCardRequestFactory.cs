using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.RegisterCards
{
    public class RegisterCardRequestFactory : BaseFactory
    {
        public registerCardRequest request;

        /**
         * request başlatılır.
         *
         * eulaId: Müşterinin ekleyeceği kart için imzalamış olduğu güncel sözleşme metni versiyon numarası
         */

        public RegisterCardRequestFactory()
        {
            request = new registerCardRequest()
            {
                eulaId = Constants.EULAID,
                requestHeader = CreateRequestHeader()
            };
        }
        /**
         *
         * clientIPAddress : Müşteri IP bilgisi
         * 
         * alias : Müşterinin eklemek istediği karta vereceği isim bilgisidir.
         *
         * cardToken : getCardToken servisi ile alınan token değeridir.
         *
         * isDefault : Eklenecek kart default olarak belirlenmek isteniyorsa True gönderilir, diğer durumda bu alan
         * gönderilmez.
         *
         * msisdn : Müşterinin uygulamaya login olduğu telefon numarası. Ülke kodu + Telefon No formatında iletilir.
         *
         * threeDSessionId : Kartın 3D doğrulama yöntemi ile eklenmesi durumunda getThreeDSession servisi cevabında dönülen
         * session ID değeri iletilir.
         *
         */

        /**
         * Üretilen request döndürülür.
         *
         * @return
         * @throws Exception clientIpAddress/cardToken/msisdn bilglier boş ise fırlatılır.
         */
        public registerCardRequest Build()
        {
            Validate();
            return request;
        }

        /**
         *
         * @throws Exception clientIpAddress/cardToken/msisdn bilglier boş ise fırlatılır.
         */
        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null) {
              throw new Exception("ClientIpAddress must be set first.");
            }
            if (request.cardToken == null) {
              throw new Exception("CardToken must be set first");
        }
            if (request.msisdn == null) {
              throw new Exception("Msisdn must be set first");
            }
        }

}
}