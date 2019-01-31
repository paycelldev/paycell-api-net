using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.SummaryReconciliation;
using paycell_web_api_client.Session;
using System;
using System.Web.UI.WebControls;

namespace paycell_web_api_client
{
    public partial class SummaryReconciliation : Aspx.BaseAspxPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string reconciliationDate = ((TextBox)summaryReconciliationForm.FindControl("reconciliationDate")).Text;
            string totalSaleAmount = ((TextBox)summaryReconciliationForm.FindControl("totalSaleAmount")).Text;
            string totalSaleCount = ((TextBox)summaryReconciliationForm.FindControl("totalSaleCount")).Text;
            string totalReverseAmount = ((TextBox)summaryReconciliationForm.FindControl("totalReverseAmount")).Text;
            string totalReverseCount = ((TextBox)summaryReconciliationForm.FindControl("totalReverseCount")).Text;
            string totalRefundAmount = ((TextBox)summaryReconciliationForm.FindControl("totalRefundAmount")).Text;
            string totalRefundCount = ((TextBox)summaryReconciliationForm.FindControl("totalRefundCount")).Text;

            summaryReconciliationResponse response = SummaryReconciliation_Method(reconciliationDate, totalSaleAmount, totalSaleCount,
                totalReverseAmount, totalReverseCount, totalRefundAmount, totalRefundCount);

            if (response != null && response.responseHeader.responseCode == "0")
            {

                ((TextBox)summaryReconciliationForm.FindControl("reconciliationResult")).Text = response.reconciliationResult;
                ((TextBox)summaryReconciliationForm.FindControl("totalSaleAmountRes")).Text = response.totalSaleAmount;
                ((TextBox)summaryReconciliationForm.FindControl("totalSaleCountRes")).Text = response.totalSaleCount.ToString();
                ((TextBox)summaryReconciliationForm.FindControl("totalReverseAmountRes")).Text = response.totalReverseAmount;
                ((TextBox)summaryReconciliationForm.FindControl("totalReverseCountRes")).Text = response.totalReverseCount.ToString();
                ((TextBox)summaryReconciliationForm.FindControl("totalRefundAmountRes")).Text = response.totalRefundAmount;
                ((TextBox)summaryReconciliationForm.FindControl("totalRefundCountRes")).Text = response.totalRefundCount.ToString();

            }
        }

        protected summaryReconciliationResponse SummaryReconciliation_Method(string reconciliationDate, string totalSaleAmount, string totalSaleCount,
             string totalReverseAmount, string totalReverseCount, string totalRefundAmount, string totalRefundCount)
        {
            SummaryReconciliationRequestFactory factory = new SummaryReconciliationRequestFactory();
            summaryReconciliationRequest request = new summaryReconciliationRequest();
            summaryReconciliationResponse response = new summaryReconciliationResponse();
            SummaryReconciliationClienService service = new SummaryReconciliationClienService();

            try
            {
                factory.request.requestHeader.clientIPAddress = ("4.4.4.4");
                factory.request.reconciliationDate = reconciliationDate;
                factory.request.totalSaleAmount = totalSaleAmount;
                factory.request.totalReverseAmount = totalReverseAmount;
                factory.request.totalRefundAmount = totalRefundAmount;
                factory.request.totalSaleCountSpecified = true;
                factory.request.totalRefundCountSpecified = true;
                factory.request.totalReverseCountSpecified = true;
                factory.request.totalSaleCount = Int32.Parse(totalSaleCount);
                factory.request.totalReverseCount = Int32.Parse(totalReverseCount);
                factory.request.totalRefundCount = Int32.Parse(totalRefundCount);

                request = factory.Build();

                response = service.OptionalRequest(MySession.Current.requestFilter, request);
                
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