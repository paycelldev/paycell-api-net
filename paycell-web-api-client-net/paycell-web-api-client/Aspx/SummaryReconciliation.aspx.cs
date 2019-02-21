using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.SummaryReconciliation;
using paycell_web_api_client.Session;
using System;

namespace paycell_web_api_client.Aspx
{
    public partial class SummaryReconciliation : BaseAspxPage
    {
        private string reconciliationDate;
        private string totalSaleAmount;
        private string totalSaleCount;
        private string totalReverseAmount;
        private string totalReverseCount;
        private string totalRefundAmount;
        private string totalRefundCount;

        private string totalPostAuthAmount;
        private string totalPostAuthCount;
        private string totalPostAuthReverseAmount;
        private string totalPostAuthReverseCount;
        private string totalPreAuthAmount;
        private string totalPreAuthCount;
        private string totalPreAuthReverseAmount;
        private string totalPreAuthReverseCount;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            reconciliationDate = reconciliationDateIn.Text;
            totalSaleAmount = totalSaleAmountIn.Text;
            totalSaleCount = totalSaleCountIn.Text;
            totalReverseAmount = totalReverseAmountIn.Text;
            totalReverseCount = totalReverseCountIn.Text;
            totalRefundAmount = totalRefundAmountIn.Text;
            totalRefundCount = totalRefundCountIn.Text;

            totalPostAuthAmount = totalPostAuthAmountIn.Text;
            totalPostAuthCount = totalPostAuthCountIn.Text;
            totalPostAuthReverseAmount = totalPostAuthReverseAmountIn.Text;
            totalPostAuthReverseCount = totalPostAuthReverseCountIn.Text;
            totalPreAuthAmount = totalPreAuthAmountIn.Text;
            totalPreAuthCount = totalPreAuthCountIn.Text;
            totalPreAuthReverseAmount = totalPreAuthReverseAmountIn.Text;
            totalPreAuthReverseCount = totalPreAuthReverseCountIn.Text;


            summaryReconciliationResponse response = SummaryReconciliation_Method();

            if (response != null && response.responseHeader.responseCode == "0")
            {

                reconciliationResult.Text = response.reconciliationResult;
                totalSaleAmountRes.Text = response.totalSaleAmount;
                totalSaleCountRes.Text = response.totalSaleCount.ToString();
                totalReverseAmountRes.Text = response.totalReverseAmount;
                totalReverseCountRes.Text = response.totalReverseCount.ToString();
                totalRefundAmountRes.Text = response.totalRefundAmount;
                totalRefundCountRes.Text = response.totalRefundCount.ToString();

                if (totalPreAuthReverseCount != "" || totalPostAuthReverseCount != "" || totalPostAuthCount != "" || totalPreAuthCountIn.Text != ""
                    || totalPostAuthAmount != "" || totalPostAuthReverseAmount != "" || totalPreAuthAmount != "" || totalPreAuthReverseAmount != "")
                {
                    totalPreAuthReverseCountRes.Text = response.totalPreAuthReverseCount.ToString();
                    totalPostAuthReverseCountRes.Text = response.totalPostAuthReverseCount.ToString();
                    totalPostAuthCountRes.Text = response.totalPostAuthCount.ToString();
                    totalPreAuthCountRes.Text = response.totalPreAuthCount.ToString();
                    totalPostAuthAmountRes.Text = response.totalPostAuthAmount;
                    totalPostAuthReverseAmountRes.Text = response.totalPostAuthReverseAmount;
                    totalPreAuthAmountRes.Text = response.totalPreAuthAmount;
                    totalPreAuthReverseAmountRes.Text = response.totalPreAuthReverseAmount;
                }

            }
        }

        protected summaryReconciliationResponse SummaryReconciliation_Method()
        {
            SummaryReconciliationRequestFactory factory = new SummaryReconciliationRequestFactory();
            summaryReconciliationRequest request = new summaryReconciliationRequest();
            summaryReconciliationResponse response = new summaryReconciliationResponse();
            SummaryReconciliationClienService service = new SummaryReconciliationClienService();

            try
            {
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

                if  (totalPostAuthCount != "" || totalPostAuthReverseCount != "" || totalPreAuthCount != "" || totalPreAuthReverseCount != "" ||
                    totalPostAuthAmount != "" || totalPreAuthAmount != "" || totalPreAuthReverseAmount != "")
                {
                    if (totalPostAuthCount != "")
                    {
                        factory.request.totalPostAuthCountSpecified = true;
                        factory.request.totalPostAuthCount = Int32.Parse(totalPostAuthCount);
                    }
                    if (totalPostAuthReverseCount != "")
                    {
                        factory.request.totalPostAuthReverseCountSpecified = true;
                        factory.request.totalPostAuthReverseCount = Int32.Parse(totalPostAuthReverseCount);
                    }
                    if (totalPreAuthCount != "")
                    {
                        factory.request.totalPreAuthCountSpecified = true;
                        factory.request.totalPreAuthCount = Int32.Parse(totalPreAuthCount);
                    }
                    if (totalPreAuthReverseCount != "")
                    {
                        factory.request.totalPreAuthReverseCountSpecified = true;
                        factory.request.totalPreAuthReverseCount = Int32.Parse(totalPreAuthReverseCount);
                    }
                    factory.request.totalPostAuthAmount = totalPostAuthAmount;
                    factory.request.totalPreAuthAmount = totalPreAuthAmount;
                    factory.request.totalPreAuthReverseAmount = totalPreAuthReverseAmount;
                }

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