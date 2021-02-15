using System.Net.Http;

namespace Shamyr.Expendity.Server.Service.Services
{
  public class HttpClientService: IHttpClientService
  {
    public HttpClient Client { get; }

    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
      Client = httpClientFactory.CreateClient();
    }
  }
}
