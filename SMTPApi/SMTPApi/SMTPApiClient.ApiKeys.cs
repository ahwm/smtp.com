using SMTPApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SMTPApi
{
    public partial class SMTPApiClient
    {
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
        public async Task<ResponseType<ApiKeysType>> ListApiKeysAsync()
        {
            var response = await httpClient.GetAsync("api_keys");
			if (!response.IsSuccessStatusCode)
			{
				var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
				throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
			}
			return await response.Content.ReadAsAsync<ResponseType<ApiKeysType>>();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
		public async Task<ResponseType<ApiKeyType>> CreateNewKey(string name, string description)
		{
            var response = await httpClient.PostAsync($"api_keys?name={name}&description={description}", new StringContent(""));
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            return await response.Content.ReadAsAsync<ResponseType<ApiKeyType>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<ApiKeyType>> GetApiKeyAsync(string apiKey)
        {
            var response = await httpClient.GetAsync($"api_keys/{apiKey}");
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            return await response.Content.ReadAsAsync<ResponseType<ApiKeyType>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<object>> DeleteApiKeyAsync(string apiKey)
        {
            using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"api_keys/{apiKey}"))
            {
                var response = await httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                    throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
                }
                return await response.Content.ReadAsAsync<ResponseType<object>>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<object>> UpdateApiKeyAsync(string apiKey, string name, string description)
        {
            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"api_keys/{apiKey}?name={name}&description={description}"))
            {
                var response = await httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                    throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
                }
                return await response.Content.ReadAsAsync<ResponseType<object>>();
            }
        }
    }
}
