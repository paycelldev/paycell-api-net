using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.GetCardToken;
using paycell_web_api_client.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace paycell_web_api_client.Aspx
{
    public class BaseAspxPage : System.Web.UI.Page
    {

        protected string MsisdnFormatter()
        {
            string msisdn = MySession.Current.msisdn;

            if (MySession.Current.msisdn != null)
            {
                return msisdn.Substring(2, msisdn.Length - 2);
            }
            return null;
        }

        protected paymentType GetPaymentType(string selectPayment)
        {

            if (selectPayment == paymentType.SALE.ToString())
            {
                return paymentType.SALE;
            }
            else if (selectPayment == paymentType.PREAUTH.ToString())
            {
                return paymentType.PREAUTH;
            }
            else
            {
                return paymentType.POSTAUTH;
            }
        }

        protected string GetCurrency(string currency)
        {
            if (currency == "TRY")
            {
                return "TRY";
            }
            else if (currency == "EUR")
            {
                return "EUR";
            }
            else
            {
                return "USD";
            }
        }


        protected bool BoolParse(string value)
        {
            try
            {
                return bool.Parse(value);
            }
            catch
            {
                return false;
            }

        }

        protected string GenerateHashData(GetCardTokenResponse response)
        {
            string transactionId = response.header.transactionId;
            string responseDateTime = response.header.responseDateTime;
            string responseCode = response.header.responseCode;
            string cardToken = response.cardToken;
            return HashDataGenerator.GenerateForResponse(transactionId, responseDateTime, responseCode, cardToken);
        }

        protected void ShowMessage(string message)
        {
            if (message.Length > 200)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message.Substring(0, 200) + "');", true);

            } else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
            }

        }
    }
} 