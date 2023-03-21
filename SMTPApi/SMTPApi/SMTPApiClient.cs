using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SMTPApi
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SMTPApiClient
    {
        protected static HttpClient httpClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        public SMTPApiClient(string apiKey) 
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.smtp.com/v4"),
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
