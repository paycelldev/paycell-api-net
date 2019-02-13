using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.ProvisionForMarketplace;
using paycell_web_api_client.Services.ProvisionForMarketPlace;
using paycell_web_api_client.Session;
using System;
using System.Web.UI.WebControls;

namespace paycell_web_api_client.Aspx
{
    public partial class ProvisionForMarketPlace : BaseAspxPage
    {
        private static System.Collections.Generic.List<extraParameter> extraParameterList = new System.Collections.Generic.List<extraParameter>();
        private static System.Collections.Generic.List<subMerchant> subMerchantList = new System.Collections.Generic.List<subMerchant>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((TextBox)form.FindControl("selectedMsisdn")).Text = MySession.Current.msisdn;
            ((TextBox)form.FindControl("selectedCardId")).Text = MySession.Current.cardId;
            ((TextBox)form.FindControl("selectedCardToken")).Text = MySession.Current.cardToken;
            ((TextBox)form.FindControl("threeDSessionId")).Text = MySession.Current.threeDSessionId;
        }

        protected void GetProvision_Click(object sender, EventArgs e)
        {
            string msisdn = MsisdnFormatter();
            string cardId = MySession.Current.cardId;
            string cardToken = MySession.Current.cardToken;
            string threeDSessionId = MySession.Current.threeDSessionId;
            string amount = ((TextBox)form.FindControl("Amount")).Text;
            string currency = GetCurrency(((DropDownList)form.FindControl("currencyIn")).SelectedValue);
            string installmentCountIn = ((DropDownList)form.FindControl("installmentCountIn")).SelectedValue;
            paymentType getpaymentType = GetPaymentType(((DropDownList)form.FindControl("paymentTypeIn")).SelectedValue);
            string customerEmail = ((TextBox)form.FindControl("customerEmail")).Text;
            string acquirerBankCodeIn = ((TextBox)form.FindControl("acquirerBankCodeIn")).Text;
            string pin = ((TextBox)form.FindControl("pin")).Text;
            string pointAmount = ((TextBox)form.FindControl("pointAmount")).Text;

            provisionForMarketPlaceResponse response = GetProvisionForMarketplace(msisdn, cardId, cardToken, threeDSessionId, amount, customerEmail,
                 acquirerBankCodeIn, pin, pointAmount, Int32.Parse(installmentCountIn));

            if (response != null && response.responseHeader.responseCode == "0")
            {

                ((TextBox)form.FindControl("acquirerBankCode")).Text = response.acquirerBankCode;
                ((TextBox)form.FindControl("approvalCode")).Text = response.approvalCode;
                ((TextBox)form.FindControl("orderId")).Text = response.orderId;
                ((TextBox)form.FindControl("reconciliationDate")).Text = response.reconciliationDate;
            }

        }

        protected provisionForMarketPlaceResponse GetProvisionForMarketplace(string msisdn, string cardId, string cardToken, string threeDSessionId, string amount,
            string customerEmail, string acquirerBankCodeIn, string pin, string pointAmount, int installmentCount)
        {
            ProvisionForMarketPlaceRequestFactory factory = new ProvisionForMarketPlaceRequestFactory();
            factory.request.msisdn = msisdn;
            factory.request.cardId = cardId;
            factory.request.cardToken = cardToken;
            factory.request.threeDSessionId = threeDSessionId;
            factory.request.amount = amount;
            factory.request.requestHeader.clientIPAddress = "4.4.4.4";
            factory.request.currency = "TRY";
            factory.request.paymentTypeSpecified = true;
            factory.request.paymentType = (paymentType.SALE);
            factory.request.customerEmail = customerEmail;
            factory.request.acquirerBankCode = acquirerBankCodeIn;
            factory.request.pin = pin;
            factory.request.pointAmount = pointAmount;
            factory.request.installmentCountSpecified = true;
            factory.request.installmentCount = installmentCount;

            if (extraParameterList.Capacity > 0)
            {
                factory.request.extraParameters = extraParameterList.ToArray();
            }
            if (subMerchantList.Capacity > 0) {
                factory.request.subMerchants = subMerchantList.ToArray();
            }

            try
            {
                provisionForMarketPlaceRequest request = factory.Build();
                provisionForMarketPlaceResponse response = new ProvisionForMarketPlaceClientService().OptionalRequest(MySession.Current.requestFilter, request);
                ((TextBox)form.FindControl("referenceNumber")).Text = request.referenceNumber;
                return response;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }
        }

        protected void AddExtraParameter_Click(object sender, EventArgs e)
        {
            string extraParameterKey = ((TextBox)form.FindControl("extraParameterKey")).Text;
            string extraParameterValue = ((TextBox)form.FindControl("extraParameterValue")).Text;

            if (extraParameterKey == "" || extraParameterValue == "")
            {
                ShowMessage("ExtraParameter Eklenemedi!");
            }
            else
            {
                extraParameter parameter = new extraParameter()
                {
                    key = extraParameterKey,
                    value = extraParameterValue
                };

                extraParameterList.Add(parameter);
                ShowMessage("ExtraParameter Başarılı Bir Şekilde Eklendi.");
            }
        }

        protected void AddSubMerchant_Click(object sender, EventArgs e)
        {
            string subMerchantKey = ((TextBox)form.FindControl("subMerchantKey")).Text;
            string subMerchantPrice = ((TextBox)form.FindControl("subMerchantPrice")).Text;

            if (subMerchantKey == "" || subMerchantPrice == "")
            {
                ShowMessage("SubMerchant Eklenemedi!");
            }
            else
            {
                subMerchant parameter = new subMerchant()
                {
                    subMerchantKey = subMerchantKey,
                    subMerchantPrice = subMerchantPrice
                };

                subMerchantList.Add(parameter);
                ShowMessage("SubMerchant Başarılı Bir Şekilde Eklendi.");
            }
        }

    }
}