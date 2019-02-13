using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Provision;
using paycell_web_api_client.Session;
using System;
using System.Web.UI.WebControls;

namespace paycell_web_api_client.Aspx
{
    public partial class Provision : BaseAspxPage
    {
        private static System.Collections.Generic.List<extraParameter> extraParameterList = new System.Collections.Generic.List<extraParameter>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((TextBox)provision.FindControl("selectedMsisdn")).Text = MySession.Current.msisdn;
            ((TextBox)provision.FindControl("selectedCardId")).Text = MySession.Current.cardId;
            ((TextBox)provision.FindControl("selectedCardToken")).Text = MySession.Current.cardToken;
            ((TextBox)provision.FindControl("threeDSessionId")).Text = MySession.Current.threeDSessionId;
            
        }

        protected void GetProvision_Click(object sender, EventArgs e)
        {
            string msisdn = MsisdnFormatter();
            string cardId = ((TextBox)provision.FindControl("selectedCardId")).Text;
            string cardToken = ((TextBox)provision.FindControl("selectedCardToken")).Text;
            string amount = ((TextBox)provision.FindControl("Amount")).Text;
            string installmentCountIn = ((DropDownList)provision.FindControl("installmentCountIn")).SelectedValue;
            string acquirerBankCodeIn = ((TextBox)provision.FindControl("acquirerBankCodeIn")).Text;
            string pin = ((TextBox)provision.FindControl("pin")).Text;
            string pointAmount = ((TextBox)provision.FindControl("pointAmount")).Text;
            string currency = GetCurrency(((DropDownList)provision.FindControl("currencyIn")).SelectedValue);
            paymentType getpaymentType = GetPaymentType(((DropDownList)provision.FindControl("paymentTypeIn")).SelectedValue);

            provisionResponse response = GetProvisions(msisdn, cardId, cardToken, amount, getpaymentType, currency, Int32.Parse(installmentCountIn),
                acquirerBankCodeIn, pin, pointAmount);

            if (response != null && response.responseHeader.responseCode == "0")
            {

                Label myLabel = this.FindControl("AcquirerBankCode") as Label;
                myLabel.Text = "my text";

                ((Label)provision.FindControl("AcquirerBankCode")).Text = response.acquirerBankCode;
                ((Label)provision.FindControl("ApprovalCode")).Text = response.approvalCode;
                ((Label)provision.FindControl("OrderId")).Text = response.orderId;
                ((Label)provision.FindControl("ReconciliationDate")).Text = response.reconciliationDate;

            }

        }

        protected provisionResponse GetProvisions(string msisdn, string cardId, string cardToken, string amount, paymentType type, string currency,
            int installmentCount, string acquirerBankCodeIn, string pin, string pointAmount)
        {
            provisionRequest request = null;
            ProvisionRequestFactory factory = new ProvisionRequestFactory();
            factory.request.msisdn = msisdn;
            factory.request.cardId = cardId;
            factory.request.cardToken = cardToken;
            factory.request.amount = amount;
            factory.request.currency = currency;
            factory.request.installmentCountSpecified = true;
            factory.request.installmentCount = installmentCount;
            factory.request.requestHeader.clientIPAddress = "4.4.4.4";
            factory.request.paymentType = type;
            factory.request.paymentTypeSpecified = true;
            factory.request.acquirerBankCode = acquirerBankCodeIn;
            factory.request.pin = pin;
            factory.request.pointAmount = pointAmount;
            factory.request.extraParameters = extraParameterList.ToArray();

            try
            {
                request = factory.Build();
                provisionResponse response = new ProvisionClientService().OptionalRequest(MySession.Current.requestFilter, request);
                ((Label)provision.FindControl("referanceNumber")).Text = request.referenceNumber;
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
            string extraParameterKey = ((TextBox)provision.FindControl("extraParameterKey")).Text;
            string extraParameterValue = ((TextBox)provision.FindControl("extraParameterValue")).Text;

            if (extraParameterKey == "" || extraParameterValue == "")
            {
                ShowMessage("ExtraParameter Eklenemedi!");
            } else
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
    }
}