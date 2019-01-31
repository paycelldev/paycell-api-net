
namespace paycell_web_api_client.Services
{
    interface IBaseApiClientService<T,E>
    {
        E SoapClient(T requestObject);

        E RestClient(string url, T requestObject);

        E OptionalRequest(string requestType, T requestObject);
    }
}
