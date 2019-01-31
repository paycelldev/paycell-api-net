using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.RegisterCards;
using paycell_web_api_client.Session;
using System;
using System.Web.UI.WebControls;

namespace paycell_web_api_client
{
    public partial class RegisterCard : Aspx.BaseAspxPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ((TextBox)registerCardForm.FindControl("selectedMsisdn")).Text = MySession.Current.msisdn;
            ((TextBox)registerCardForm.FindControl("selectedCardToken")).Text = MySession.Current.cardToken;
            ((TextBox)registerCardForm.FindControl("threeDSessionId")).Text = MySession.Current.threeDSessionId;
        }

        protected void RegisterCardButtonOnClick(Object sender, EventArgs e)
        {
            if (MySession.Current.cardToken != null)
            {
                RegisterCardMethod();
            } else
            {
                ShowMessage("Kayıtlı Olmayan Bir Kart Seçimi Yapmadınız!");
            }
        }


        private void RegisterCardMethod()
        {
            RegisterCardClientService service = new RegisterCardClientService();
            registerCardRequest request = null;
            registerCardResponse response = null;

            RegisterCardRequestFactory factory = new RegisterCardRequestFactory();
            factory.request.msisdn = MySession.Current.msisdn;
            factory.request.cardToken = MySession.Current.cardToken;
            factory.request.threeDSessionId = MySession.Current.threeDSessionId;
            factory.request.alias = ((TextBox)registerCardForm.FindControl("alias")).Text;
            factory.request.isDefaultSpecified = true;
            factory.request.isDefault = GetIsDefault();
            factory.request.requestHeader.clientIPAddress = "4.4.4.4";

            try
            {
                request = factory.Build();
                response = service.OptionalRequest(MySession.Current.requestFilter, request);
                ShowMessage(response.responseHeader.responseDescription);
                

            } catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }

        }

        private bool GetIsDefault()
        {
            string isDef = ((DropDownList)registerCardForm.FindControl("isDefault")).SelectedValue;

            if (isDef == "True")
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}