using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.GetProvisionHistory
{
    public class GetProvisionHistoryRequestFactory : BaseFactory
    {

        public getProvisionHistoryRequest request;

        /**
         * Request başlatılır.
         *
         * MerchantCode: Paycell tarafından üye işyeri için tanımlanır.
         */
        public GetProvisionHistoryRequestFactory()
        {
            request = new getProvisionHistoryRequest()
            {
            merchantCode = Constants.MERCHANT_CODE,
            requestHeader = CreateRequestHeader()
            };
        }

        /**
         * Üretilen request döndürülür.
         * 
         * reconciliationDate : YYYYMMDD formatında olmalıdır.
         *
         * 
         * @throws Exception reconciliationDate/clientIpAddress boş ise fırlatılır.
         */
        public getProvisionHistoryRequest Build()
        {
            Validate();
            return request;
        }

        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null)
            {
                throw new Exception("ClientIpAdress must be set first.");
            }
            if (request.reconciliationDate == null)
            {
                throw new Exception("Msisdn must be set first.");
            }
        }
    }
}