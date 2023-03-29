using SMTPApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public async Task<ResponseType<List<DomainType>>> ListDomainsAsync()
        {
            var response = await httpClient.GetAsync($"domains");
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            return await response.Content.ReadAsAsync<ResponseType<List<DomainType>>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<DomainType>> RegisterDomainAsync(string domainName)
        {
            var response = await httpClient.PostAsync($"domains?domain_name={domainName}", new StringContent(""));
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            return await response.Content.ReadAsAsync<ResponseType<DomainType>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<DomainType>> GetDomainAsync(string domainName)
        {
            var response = await httpClient.GetAsync($"domains/{domainName}");
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            return await response.Content.ReadAsAsync<ResponseType<DomainType>>();
        }
    }
}
