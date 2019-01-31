using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.DeleteCard;
using paycell_web_api_client.Services.GetCard;
using paycell_web_api_client.Services.GetCardToken;
using paycell_web_api_client.Services.ThreeDSession;
using paycell_web_api_client.Services.UpdateCard;
using paycell_web_api_client.Session;
using paycell_web_api_client.Util;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace paycell_web_api_client
{
    public partial class GetCardsList : Aspx.BaseAspxPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSelectedValues();
            }
        }

        protected void SearchButtonOnClick(Object sender, EventArgs e)
        {
            string msisdn = ((TextBox)form1.FindControl("Msisdn")).Text;

            getCardsResponse response = GetCards(msisdn); 

            if (response != null)
            {
                if (response.cardList == null || response.cardList.Length == 0)
                {
                    ShowMessage("Kart Bulunamadı!");

                } else
                {
                    DataGet(response);
                }
            }

        }

        protected void GetCardsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cardId = GetCardsGridView.Rows[e.RowIndex].Cells[1].Text;
            string msisdn = Request.Form["Msisdn"].ToString();

            if (DeleteCard(msisdn, cardId) == "0")
            {
                DataTable dt = TempDataTable();
                TempDataTable().Rows.Remove(dt.Rows[e.RowIndex]);
                GetCardsGridView.DataSource = dt;
                GetCardsGridView.DataBind();
            }
        }


        protected void GetCardsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string cardId = GetCardsGridView.Rows[e.NewEditIndex].Cells[1].Text;
            GetCardsGridView.EditIndex = e.NewEditIndex;

        }

        protected void GetCardsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string msisdn = Request.Form["Msisdn"].ToString();
            string cardId = GetCardsGridView.Rows[e.RowIndex].Cells[1].Text;
            string alias = e.NewValues[0].ToString();
            string threeDSessionId = MySession.Current.threeDSessionId;
            bool isDefault = BoolParse(e.NewValues[1].ToString());

            string responseCode = UpdateCard(cardId, msisdn, threeDSessionId, alias, isDefault);

            if (responseCode != "0")
            {
                GetCardsGridView.DataBind();
            } else
            {
                GetCardsGridView.Rows[e.RowIndex].Cells[4].Text = e.NewValues[0].ToString();
                GetCardsGridView.Rows[e.RowIndex].Cells[5].Text = e.NewValues[1].ToString();
                GetCardsGridView.DataBind();
                GetCardsGridView.EditIndex = -1;
            }
        }

        protected void GetCardsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GetCardsGridView.EditIndex = -1;

            GetCardsGridView.DataSource = TempDataTable();
            GetCardsGridView.DataBind();

        }

        private getCardsResponse GetCards(string msisdn)
        {
            GetCardsClientService client = new GetCardsClientService();
            getCardsResponse response = null;
            getCardsRequest request = null;

            GetCardsRequestFactory factory = new GetCardsRequestFactory();
            factory.request.msisdn = msisdn;

            try
            {
                request = factory.Build();
                response = client.OptionalRequest(MySession.Current.requestFilter, request);
                return response;
            } catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }

        }

        private string DeleteCard(string msisdn, string cardId)
        {
            DeleteCardRequestFactory factory = new DeleteCardRequestFactory();
            factory.request.requestHeader.clientIPAddress = "4.4.4.4";
            factory.request.msisdn = msisdn;
            factory.request.cardId = cardId;

            try
            {
                deleteCardRequest request = factory.Build();
                DeleteCardClientService service = new DeleteCardClientService();
                deleteCardResponse response = service.OptionalRequest(MySession.Current.requestFilter, request);
                ShowMessage(response.responseHeader.responseDescription);
                return response.responseHeader.responseCode;
            } catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }

        }

        private string UpdateCard(string cardId, string msisdn, string threeDSessionId, string alias, bool isDefault)
        {

            updateCardRequest request = new updateCardRequest();
            updateCardResponse response = new updateCardResponse();
            UpdateCardClientService service = new UpdateCardClientService();
            UpdateCardRequestFactory factory = new UpdateCardRequestFactory();
            factory.request.cardId = cardId;
            factory.request.alias = alias;
            factory.request.msisdn = msisdn;
            factory.request.threeDSessionId = threeDSessionId;
            factory.request.isDefault = isDefault;

            try
            {
                request = factory.Build();
                response = service.OptionalRequest(MySession.Current.requestFilter, request);
                ShowMessage(response.responseHeader.responseDescription);
                return response.responseHeader.responseCode;
            } catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }

        }

        protected void DataGet(getCardsResponse getCards)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] {
                            new DataColumn("CardId", typeof(string)),
                            new DataColumn("CardBrand",typeof(string)),
                            new DataColumn("Alias", typeof(string)),
                            new DataColumn("MaskedCardNo", typeof(string)),
                            new DataColumn("IsDefault", typeof(string)),
                            new DataColumn("IsExpired", typeof(string)),
                            new DataColumn("ShowEulaId", typeof(string)),
                            new DataColumn("IsThreeDValidated", typeof(string)),
                            new DataColumn("IsOTPValidated", typeof(string)),
                            new DataColumn("ActivationDate", typeof(string)) });

            if (getCards != null && getCards.cardList != null)
            {

                foreach (card item in getCards.cardList)
                {
                    dt.Rows.Add(item.cardId, item.cardBrand, item.alias, item.maskedCardNo, item.isDefault, item.isExpired, item.showEulaId,
                                item.isThreeDValidated, item.isOTPValidated, item.activationDate);
                }

            }
            TempDataTable(dt);
            GetCardsGridView.DataSource = dt;
            GetCardsGridView.DataBind();
        }

        protected void TempDataTable(DataTable dataTable)
        {
            MySession.Current.dataTable = dataTable;
        }

        protected DataTable TempDataTable()
        {
            return MySession.Current.dataTable;
        }


        protected void GetCardsGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string cardId = GetCardsGridView.Rows[e.NewSelectedIndex].Cells[1].Text;
            string msisdn = Request.Form["Msisdn"].ToString();

            MySession.Current.msisdn = msisdn;
            MySession.Current.cardToken = null;
            MySession.Current.threeDSessionId = null;
            MySession.Current.cardId = cardId;
            LoadSelectedValues();
            ((TextBox)form1.FindControl("ThreeDSecureId")).Text = null;

            ShowMessage("Kart Seçimi Başarılı!");
        }

        protected void SelectUnRegisterCard_Click(object sender, EventArgs e)
        {
            string msisdn = ((TextBox)form1.FindControl("Msisdn")).Text;
            string creditCardNo = ((TextBox)form1.FindControl("creditCardNo")).Text;
            string expireDateMonth = ((TextBox)form1.FindControl("expireDateMonth")).Text;
            string expireDateYear = ((TextBox)form1.FindControl("expireDateYear")).Text;
            string cvcNo = ((TextBox)form1.FindControl("cvcNo")).Text;

            string cardToken = GetCardToken_Method(creditCardNo, expireDateMonth, expireDateYear, cvcNo);

            if (cardToken != null)
            {

                MySession.Current.msisdn = msisdn;
                MySession.Current.cardId = null;
                MySession.Current.threeDSessionId = null;
                MySession.Current.cardToken = cardToken;
                LoadSelectedValues();
                ((TextBox)form1.FindControl("ThreeDSecureId")).Text = null;
                GetCardsGridView.SelectedIndex = -1;
                ShowMessage("Kart Seçimi Başarılı!");

            }
        }

        protected string GetCardToken_Method(string creditCardNo, string expireDateMonth, string expireDateYear, string cvcNo)
        {
            GetCardTokenClientService clientService = new GetCardTokenClientService();
            GetCardTokenRequest request = null;
            GetCardTokenResponse response = null;

            GetCardTokenRequestFactory factory = new GetCardTokenRequestFactory();
            factory.request.creditCardNo = creditCardNo;
            factory.request.expireDateMonth = expireDateMonth;
            factory.request.expireDateYear = expireDateYear;
            factory.request.cvcNo = cvcNo;

            try
            {
                request = factory.Build();
                response = clientService.GetCardToken(request);

                if (response.hashData == GenerateHashData(response))
                {
                    return response.cardToken;
                }
                else
                {
                    ShowMessage("CardToken Doğrulanamadı!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }
        }

        private void LoadSelectedValues()
        {
            string msisdn = MySession.Current.msisdn;
            string cardId = MySession.Current.cardId;
            string cardToken = MySession.Current.cardToken;
            string threeDSessionId = MySession.Current.threeDSessionId;

            ((TextBox)form1.FindControl("selectedMsisdn")).Text = msisdn;
            ((TextBox)form1.FindControl("selectedCardId")).Text = cardId;
            ((TextBox)form1.FindControl("selectedCardToken")).Text = cardToken;
            ((TextBox)form1.FindControl("selectedThreeDSessionId")).Text = threeDSessionId;

        }

        protected void GetThreeDSessionIdButton_Click(object sender, EventArgs e)
        {
            string amount = "253";
            string msisdn = MySession.Current.msisdn;
            string cardId = MySession.Current.cardId;
            string cardToken = MySession.Current.cardToken;

            string sessionId = GetThreeDSessionId(amount, msisdn, cardId, cardToken);

            if (sessionId != null)
            {
                ((TextBox)form1.FindControl("ThreeDSecureId")).Text = sessionId;
                ShowMessage("ThreeDSessionId Alındı. Dogrulama İslemini Tamamlayınız!");
            }

        }

        protected string GetThreeDSessionId(string amount, string msisdn, string cardId, string cardToken)
        {
            GetThreeDSessionRequestFactory factory = new GetThreeDSessionRequestFactory();
            factory.request.target = target.MERCHANT;
            factory.request.amount = amount;
            factory.request.msisdn = msisdn;
            factory.request.cardId = cardId;
            factory.request.cardToken = cardToken;
            factory.request.transactionType = transactionType.AUTH;

            try
            {
                getThreeDSessionRequest request = factory.Build();
                getThreeDSessionResponse response = new GetThreeDSessionClientService().OptionalRequest(MySession.Current.requestFilter, request);
                return response.threeDSessionId;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }

        }
        
        protected void ThreeDSecureResultButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("document.cookie = \" threeDSessionId="+ ((TextBox)form1.FindControl("ThreeDSecureId")).Text + "\";");
            Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl("securePage.html")));
            Response.Write("</script>");
        }

        protected void TestThreeDSessionId_Click(object sender, EventArgs e)
        {
            string unverifiedThreeDSessionId = ((TextBox)form1.FindControl("ThreeDSecureId")).Text;
            string threeDSessionId = GetThreeDSessionResult_Method(MySession.Current.msisdn, unverifiedThreeDSessionId);

            if (threeDSessionId == null)
            {
                MySession.Current.threeDSessionId = null;
            } else
            {
                MySession.Current.threeDSessionId = threeDSessionId;
                ((TextBox)form1.FindControl("selectedThreeDSessionId")).Text = threeDSessionId;
            }
        }
        
        protected string GetThreeDSessionResult_Method(string msisdn, string threeDSessionId)
        {
            GetThreeDSessionResultRequestFactory factory = new GetThreeDSessionResultRequestFactory();
            getThreeDSessionResultRequest request = null;
            getThreeDSessionResultResponse response = null;
            factory.request.msisdn = msisdn;
            factory.request.merchantCode = Constants.MERCHANT_CODE;
            factory.request.threeDSessionId = threeDSessionId;

            try
            {
                request = factory.Build();
                response = new GetThreeDSessionResultClientService().GetThreeDSessionResultResponseHandler(MySession.Current.requestFilter, request);

                if (response != null)
                {
                    ShowMessage(response.threeDOperationResult.threeDResultDescription);
                    return threeDSessionId;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return null;
            }

            return null;
        }

    }
}