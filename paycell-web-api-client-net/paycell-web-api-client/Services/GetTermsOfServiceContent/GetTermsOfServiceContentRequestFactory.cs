using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.GetTermsOfServiceContent
{
    public class GetTermsOfServiceContentRequestFactory : BaseFactory
    {

        public getTermsOfServiceContentRequest request;

        public GetTermsOfServiceContentRequestFactory()
        {
            request = new getTermsOfServiceContentRequest()
            {
                requestHeader = CreateRequestHeader()
            };
        }

        /**
         *eulaId : 	Karta ait güncel sözleşme metni versiyon numarasıdır.
         * 
         *termsOfServiceHtmlContentEN : Güncel sözleşmenin İngilizce metninin HTML formatında görüntülenen halidir.
         * 
         *termsOfServiceHtmlContentTR : Güncel sözleşmenin Türkçe metninin HTML formatında görüntülenen halidir.
         */

        public getTermsOfServiceContentRequest Build()
        {
            return request;
        }

    }
}