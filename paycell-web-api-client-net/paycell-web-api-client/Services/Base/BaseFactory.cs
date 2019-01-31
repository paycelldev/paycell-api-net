using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paycell_web_api_client.Services.Base
{

    /**
     * Request header oluşturulur.
     *
     * ApplicationName: Paycell tarafından kayıt sırasında belirlenerek, üye iş yerine verilir.
     *
     * ApplicationPassword: Paycell tarafından kayıt sırasında belirlenerek, üye iş yerine verilir.
     *
     * TransactionDateTime: işlem tarihi YYYYMMddHHmmssSSS formatı kullanılır.
     *
     * TransactionId: işlem tekil numarasıdır, üye iş yeri tarafından oluşturulur. "\\d{20}" formatında
     * olmalıdır.
     *
     * @return Oluşturulan header bilgisi
     */

    public abstract class BaseFactory
    {
        public requestHeader CreateRequestHeader()
        {
            requestHeader RequestHeader = new requestHeader()
            {

                applicationName = Constants.APPLICATION_NAME,
                applicationPwd = Constants.APPLICATION_PASSWORD,
                transactionId = UniqueIdGenerator.GenerateTransactionId(),
                clientIPAddress = "10.252.187.81",
                transactionDateTime = DateTime.Now.ToString("yyyyMMddHHmmss") + "000"
            };

            return RequestHeader;
        }
    }
}