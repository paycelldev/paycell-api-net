using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.GetTermsOfServiceContent;
using paycell_web_api_client.Session;
using System;
using System.Web.UI.WebControls;

namespace paycell_web_api_client.Aspx
{
    public partial class GetTermsOfServiceContent : BaseAspxPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TermsOfServiceButton_Click(Object sender, EventArgs e)
        {

            getTermsOfServiceContentResponse response = GetTermsOfServiceContentMethod();

            if (response != null)
            {
                if (response.responseHeader != null && response.responseHeader.responseCode == "0")
                {
                    ((Literal)form.FindControl("TermsOfTr")).Text = response.termsOfServiceHtmlContentTR;
                    ((Literal)form.FindControl("TermsOfEn")).Text = response.termsOfServiceHtmlContentEN;

                }
            }

        }

        private getTermsOfServiceContentResponse GetTermsOfServiceContentMethod()
        {
            GetTermsOfServiceContentClientService client = new GetTermsOfServiceContentClientService();
            getTermsOfServiceContentResponse response = null;
            getTermsOfServiceContentRequest request = null;

            GetTermsOfServiceContentRequestFactory factory = new GetTermsOfServiceContentRequestFactory();

            try
            {
                request = factory.Build();
                response = client.OptionalRequest(MySession.Current.requestFilter, request);
                return response;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }
        }

        protected void TRButton_Click(object sender, EventArgs e)
        {
            ((Literal)form.FindControl("TermsOfTr")).Visible = true;
            ((Literal)form.FindControl("TermsOfEn")).Visible = false;
        }

        protected void ENButton_Click(object sender, EventArgs e)
        {
            ((Literal)form.FindControl("TermsOfTr")).Visible = false;
            ((Literal)form.FindControl("TermsOfEn")).Visible = true;

        }
    }
}