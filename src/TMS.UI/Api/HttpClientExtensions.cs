using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace TMS.UI.Api
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            string uri)
        {
            await AddAccessToken<T>(httpClient, httpContextAccessor);

            return await httpClient.GetJsonAsync<T>(uri);
        }

        private static async Task AddAccessToken<T>(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            if (httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                return;
            }
            
            var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken == null)
            {
                return;
            }
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        public static async Task<TResult> PostJsonAsync<T, TResult>(this HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor, string uri, T value)
        {
            await AddAccessToken<T>(httpClient, httpContextAccessor);

            return await httpClient.PostJsonAsync<TResult>(uri, value);
        }
        
        public static async Task<TResult> PutJsonAsync<T, TResult>(this HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor, string uri, T value)
        {
            await AddAccessToken<T>(httpClient, httpContextAccessor);

            return await httpClient.PutJsonAsync<TResult>(uri, value);
        }
    }
}