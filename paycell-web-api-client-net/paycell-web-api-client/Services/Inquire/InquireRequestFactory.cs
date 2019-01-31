using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.Inquire
{
    public class InquireRequestFactory : BaseFactory
    {

        public inquireRequest request;

        public InquireRequestFactory()
        {
            request = new inquireRequest()
            {
                merchantCode = Constants.MERCHANT_CODE,
                referenceNumber = UniqueIdGenerator.GenerateReferanceNumber(),
                requestHeader = CreateRequestHeader()
            };
        }

        /**
         *msisdn : Müşteri telefon nuumarası, ülke kodu dahil edilmeyecek.
         * 
         *originalReferanceNumber : Sorgulanacak işlemin "referenceNumber" değeridir.
         * 
         *referanceNumber : Üye işyeri uygulaması tarafından üretilecek unique numerik işlem referans numarası değeridir. 
         */

        public inquireRequest Build()
        {
            return request;
        }

    }
}