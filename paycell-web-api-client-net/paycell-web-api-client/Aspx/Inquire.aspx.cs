using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Inquire;
using paycell_web_api_client.Services.Provision;
using paycell_web_api_client.Services.Refund;
using paycell_web_api_client.Services.Reverse;
using paycell_web_api_client.Session;
using paycell_web_api_client.Util;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace paycell_web_api_client.Aspx
{
    public partial class Inquire : Aspx.BaseAspxPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((TextBox)inquireForm.FindControl("selectedMsisdn")).Text = MySession.Current.msisdn;
            ((TextBox)inquireForm.FindControl("selectedCardId")).Text = MySession.Current.cardId;
            ((TextBox)inquireForm.FindControl("selectedCardToken")).Text = MySession.Current.cardToken;
            ((TextBox)inquireForm.FindControl("threeDSessionId")).Text = MySession.Current.threeDSessionId;
        }

        protected void Inquire_Click(object sender, EventArgs e)
        {
            string msisdn = ((TextBox)inquireForm.FindControl("selectedMsisdn")).Text;
            string originalReferenceNumber = ((TextBox)inquireForm.FindControl("originalReferenceNumber")).Text;

            inquireResponse response = Inquire_Method(MsisdnFormatter(), originalReferenceNumber);

            if (response != null && response.responseHeader.responseCode == "0")
            {

                ((TextBox)inquireForm.FindControl("acquirerBankCode")).Text = response.acquirerBankCode;
                ((TextBox)inquireForm.FindControl("orderId")).Text = response.orderId;
                ((TextBox)inquireForm.FindControl("status")).Text = response.status;

                if (response.provisionList.Length > 0)
                {
                    SetGridView(response.provisionList);
                    ReverseButton.Visible = true;
                    RefundLabel.Visible = true;
                }
            }

        }

        protected inquireResponse Inquire_Method(string msisdn, string originalReferenceNumber)
        {
            inquireRequest request = new InquireRequestFactory().Build();
            request.msisdn = msisdn;
            request.originalReferenceNumber = originalReferenceNumber;
            request.requestHeader.clientIPAddress = "4.4.4.4";

            try
            {
                inquireResponse response = new InquireClientService().OptionalRequest(MySession.Current.requestFilter, request);
                return response;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }
        }

        public void SetGridView(provision[] provisions)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] {
                            new DataColumn("approvalCode", typeof(string)),
                            new DataColumn("amount",typeof(string)),
                            new DataColumn("dateTime", typeof(string)),
                            new DataColumn("provisionType", typeof(string)),
                            new DataColumn("reconciliationDate", typeof(string)),
                            new DataColumn("transactionId", typeof(string))});

            foreach (provision item in provisions)
            {
                dt.Rows.Add(item.approvalCode, item.amount, item.dateTime, item.provisionType, item.reconciliationDate, item.transactionId);
            }
            
            ProvisionsGridView.DataSource = dt;
            ProvisionsGridView.DataBind();
        }

        protected void ReverseButton_Click(object sender, EventArgs e)
        {
            string originalReferenceNumber = ((TextBox)inquireForm.FindControl("originalReferenceNumber")).Text;

            reverseResponse response = Reverse_Method(MsisdnFormatter(), originalReferenceNumber);

            if (response != null && response.responseHeader.responseCode == "0")
            {
                ShowMessage(response.responseHeader.responseDescription);
                Page_Load(sender, e);
            }
        }

        protected reverseResponse Reverse_Method(string msisdn, string originalReferenceNumber)
        {
            reverseRequest request = new ReverseRequestFactory().Build();
            request.msisdn = msisdn;
            request.originalReferenceNumber = originalReferenceNumber;
            request.requestHeader.clientIPAddress = "4.4.4.4";
            request.merchantCode = Constants.MERCHANT_CODE;

            try
            {
                reverseResponse response = new ReverseClientService().OptionalRequest(MySession.Current.requestFilter, request);
                return response;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }
        }

        protected void RefundButton_Click(object sender, EventArgs e)
        {
            string msisdn = MsisdnFormatter();
            string originalReferenceNumber = ((TextBox)inquireForm.FindControl("originalReferenceNumber")).Text;
            string amount = ((TextBox)inquireForm.FindControl("amount")).Text;

            refundResponse response = Refund_Method(msisdn, originalReferenceNumber, amount);

            if (response != null && response.responseHeader.responseCode == "0")
            {
                ShowMessage(response.responseHeader.responseDescription);
                Page_Load(sender, e);
            }
        }

        protected refundResponse Refund_Method(string msisdn, string originalReferenceNumber, string amount)
        {
            RefundRequestFactory factory = new RefundRequestFactory();
            refundRequest request = null;
            factory.request.msisdn = msisdn;
            factory.request.originalReferenceNumber = originalReferenceNumber;
            factory.request.amount = amount;
            factory.request.requestHeader.clientIPAddress = "4.4.4.4";
            factory.request.merchantCode = Constants.MERCHANT_CODE;

            try
            {
                request = factory.Build();
                refundResponse response = new RefundClientService().OptionalRequest(MySession.Current.requestFilter, request);
                return response;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }
        }

    }
}