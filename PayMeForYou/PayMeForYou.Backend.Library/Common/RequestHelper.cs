using PayMeForYou.Entity.Entities;
using PayMeForYou.Helper;
using System.Net.Http;
using System.Threading.Tasks;

namespace PayMeForYou.Backend.Library.Common
{
    public class RequestHelper
    {
        private readonly HttpClientHelper _httpClientHelper;
        public RequestHelper(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }
        public async Task<string> SendRequestAsync(string url, HttpMethod method, string content = null)
        {
            _httpClientHelper.Url = url;
            _httpClientHelper.ContentType = HttpEntity.ContentType.Application_Json;
            _httpClientHelper.FormMethod = method;
            _httpClientHelper.FormContent = !string.IsNullOrWhiteSpace(content) ? new StringContent(content) : null;

            using var response = await _httpClientHelper.SubmitAsync();
            var rContent = await _httpClientHelper.ReadResponseContentAsStringAsync(response);
            return rContent;
        }
    }
}
