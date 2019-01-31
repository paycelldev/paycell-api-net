using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.GetProvisionHistory;
using paycell_web_api_client.Services.Provision;
using paycell_web_api_client.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace paycell_web_api_client
{
    public partial class GetProvisionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetProvisionHistory_Click(object sender, EventArgs e)
        {
            string reconciliationDate = ((TextBox)form.FindControl("reconciliationDate")).Text;

            getProvisionHistoryResponse response = GetProvisionHistory_Method(reconciliationDate);

            if (response != null && response.responseHeader.responseCode == "0")
            {

                if (response.transactionList.Length > 0)
                {
                    SetGridView(response.transactionList);
                }
            }

        }

        protected getProvisionHistoryResponse GetProvisionHistory_Method(string reconciliationDate)
        {
            GetProvisionHistoryRequestFactory factory = new GetProvisionHistoryRequestFactory();
            factory.request.requestHeader.clientIPAddress = "4.4.4.4";
            factory.request.reconciliationDate = reconciliationDate;


            try
            {
                getProvisionHistoryRequest request = factory.Build();
                getProvisionHistoryResponse response = new GetProvisionHistoryClientService().OptionalRequest(MySession.Current.requestFilter, request);
                return response;

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
                return null;
            }
        }

        public void SetGridView(transaction[] provisions)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] {
                            new DataColumn("transactionDateTime", typeof(string)),
                            new DataColumn("amount",typeof(string)),
                            new DataColumn("netAmount", typeof(string)),
                            new DataColumn("approvalCode", typeof(string)),
                            new DataColumn("orderId", typeof(string)),
                            new DataColumn("transactionId", typeof(string)),
                            new DataColumn("referenceNumber", typeof(string))});

            foreach (transaction item in provisions)
            {
                dt.Rows.Add(item.transactionDateTime, item.amount, item.netAmount, item.approvalCode, item.orderId, 
                    item.transactionId, item.referenceNumber);
            }

            ProvisionHistoryGridView.DataSource = dt;
            ProvisionHistoryGridView.DataBind();
        }
    }
}