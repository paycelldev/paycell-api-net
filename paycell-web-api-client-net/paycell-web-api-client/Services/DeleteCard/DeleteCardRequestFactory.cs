using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.DeleteCard
{
    public class DeleteCardRequestFactory : BaseFactory
    {
        public deleteCardRequest request;

        /**
         * request başlatılır.
         *
         */

        public DeleteCardRequestFactory()
        {
            request = new deleteCardRequest()
            {
                requestHeader = CreateRequestHeader()
            };
        }

        /**
         *
         * @param silinecek karta ait msisdn ve cardId bilgileri
         * msisdn : Ülke kodu + Telefon No formatında iletilir.
         * cardId : silinmek istenen kayıtlı kartın id bilgisi.
         * 
         */


        /**
         * Üretilen request döndürülür.
         *
         * @return
         * @throws Exception clientIpAddress/cardToken/msisdn bilglier boş ise fırlatılır.
         */
        public deleteCardRequest Build()
        {
            Validate();
            return request;
        }

        /**
         *
         * @throws Exception clientIPAddress/cardId/msisdn bilglier boş ise fırlatılır.
         */
        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null)
            {
                throw new Exception("clientIPAddress must be set first");
            }
            if (request.cardId == null)
            {
              throw new Exception("CardId must be set first");
            }
            if (request.msisdn == null)
            {
              throw new Exception("Msisdn must be set first");
            }
        }

    }
}