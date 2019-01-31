using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using paycell_web_api_client.ProvisionService;
using RestSharp;

namespace paycell_web_api_client.Services.Base
{
    public abstract class BaseApiClientServiceImpl<T, E> : IBaseApiClientService<T, E>
    {
        public ProvisionServiceClient ProvisionServiceTool { get; }

        public BaseApiClientServiceImpl()
        {
            ProvisionServiceTool = new ProvisionServiceClient();
        }

        public E RestClient(string url, T requestObject)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                var serializerSettings = new JsonSerializerSettings(){ContractResolver = new CamelCasePropertyNamesContractResolver()};
                string json = JsonConvert.SerializeObject(requestObject, serializerSettings);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                E responseObject = JsonConvert.DeserializeObject<E>(response.Content);

                return responseObject;
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public abstract E SoapClient(T requestObject);

        public abstract E OptionalRequest(string requestType, T requestObject);
    }
}