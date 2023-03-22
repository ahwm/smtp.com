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
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<AccountStatusType>> UpdateAccountAsync(AccountType account)
        {
            string query = "";
            if (!String.IsNullOrWhiteSpace(account.FirstName))
                query += $"first_name={account.FirstName}&";
            if (!String.IsNullOrWhiteSpace(account.LastName))
                query += $"last_name={account.LastName}&";
            if (!String.IsNullOrWhiteSpace(account.Email))
                query += $"email={account.Email}&";
            if (!String.IsNullOrWhiteSpace(account.CompanyName))
                query += $"company_name={account.CompanyName}&";
            if (!String.IsNullOrWhiteSpace(account.Phone))
                query += $"phone={account.Phone}&";
            if (!String.IsNullOrWhiteSpace(account.Website))
                query += $"website={account.Website}&";
            if (!String.IsNullOrWhiteSpace(account.Address.Street))
                query += $"address.street={account.Address.Street}&";
            if (!String.IsNullOrWhiteSpace(account.Address.City))
                query += $"address.city={account.Address.City}&";
            if (!String.IsNullOrWhiteSpace(account.Address.State))
                query += $"address.state={account.Address.State}&";
            if (!String.IsNullOrWhiteSpace(account.Address.Country))
                query += $"address.country={account.Address.Country}&";
            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"account?{query}"))
            {
                var response = await httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                    throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
                }
                return await response.Content.ReadAsAsync<ResponseType<AccountStatusType>>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<AccountType>> GetAccountAsync()
        {
            var response = await httpClient.GetAsync($"account");
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            return await response.Content.ReadAsAsync<ResponseType<AccountType>>();
        }
    }
}