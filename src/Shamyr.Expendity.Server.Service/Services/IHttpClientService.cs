using System.Net.Http;

namespace Shamyr.Expendity.Server.Service.Services
{
  public interface IHttpClientService
  {
    HttpClient Client { get; }
  }
}