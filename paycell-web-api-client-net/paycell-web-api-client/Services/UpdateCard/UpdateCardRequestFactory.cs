using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.UpdateCard
{
    public class UpdateCardRequestFactory : BaseFactory
    {
        public updateCardRequest request;


        /**
         * request başlatılır.
         *
         * eulaId: Müşterinin ekleyeceği kart için imzalamış olduğu güncel sözleşme metni versiyon numarası
         */
        public UpdateCardRequestFactory()
        {
            request = new updateCardRequest();
            request.eulaId = Constants.EULAID;
            request.requestHeader = CreateRequestHeader();
        }

        public updateCardRequest Build()
        {
            Validate();
            return request;
        }

        /**
         * threeDSessionId : 3D doğrulama yöntemi ile eklenmemiş bir kart için 3D doğrulama yapılarak 3DValidasyon bilgisinin
         * güncellenmesi isteniyorsa bu alan gönderilir. getThreeDSession servisi cevabında dönülen session
         * ID değeri iletilir.
         *
         */

        /**
        *
        * @throws Exception clientIpAddress/cardId/msisdn boş ise fırlatılır.
        */
        private void Validate() {
            if (request.requestHeader.clientIPAddress == null) {
            throw new Exception("ClientIpAddress must be set first.");
            }
            if (request.cardId == null) {
            throw new Exception("CardId must be set first");
            }
            if (request.msisdn == null) {
            throw new Exception("Msisdn must be set first");
            }
        }

    }
}