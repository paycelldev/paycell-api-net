using System;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Models.ViewModel;
using paycell_web_api_client.Util;
using System.Threading;

namespace paycell_web_api_client.Services.ThreeDSession
{
    public class GetThreeDSessionResultClientService : BaseApiClientServiceImpl<getThreeDSessionResultRequest, getThreeDSessionResultResponse>
    {

        public override getThreeDSessionResultResponse SoapClient(getThreeDSessionResultRequest requestObject)
        {

            getThreeDSessionResultResponse response = ProvisionServiceTool.getThreeDSessionResult(requestObject);

            return response;
        }

        public override getThreeDSessionResultResponse OptionalRequest(string requestType, getThreeDSessionResultRequest requestObject)
        {
            getThreeDSessionResultResponse response = null;

            if (requestType == Constants.SOAP)
            {
                response = SoapClient(requestObject);
            }
            else
            {
                response = RestClient(Constants.GET_THREE_D_SESSION_RESULT_URL, requestObject);
            }

            if (response != null && response.responseHeader.responseCode == "0" 
                && response.threeDOperationResult != null && response.threeDOperationResult.threeDResult == "0")
            {
                return response;
            }
            else if (response != null && response.threeDOperationResult.threeDResult != null)
            {
                string message = "threeDResult : " + response.threeDOperationResult.threeDResult + " threeDResultDescription : " + response.threeDOperationResult.threeDResultDescription;
                throw new Exception(message);
            }
            else
            {
                string message = "ThreeDSessionId Banka Dogrulama İslemi Gerceklestirilmemistir!";
                throw new Exception(message);
            }
        }

        public getThreeDSessionResultResponse GetThreeDSessionResultResponseHandler(string requestType, getThreeDSessionResultRequest requestObject)
        {
            getThreeDSessionResultResponse response = null;

            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(5000);
                response = OptionalRequest(requestType, requestObject);

                if (response.threeDOperationResult != null && response.threeDOperationResult.threeDResult != null)
                {
                    return response;
                }
            }

            throw new Exception("3D Secure timeout limit is reached.");
        }

    }
}