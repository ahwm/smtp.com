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
        /// <param name="start">The starting time. RFC 2822 or UNIX epoch format</param>
        /// <param name="end">The ending time. If not specified, defaults to now. RFC 2822 or UNIX epoch format.</param>
        /// <param name="event">Array of any event names for which stats has been requested ('accepted', 'failed', 'delivered').</param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="msgId"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<List<MessageDetailsType>>> GetMessagesAsync(string start, string end, string @event, int limit, int offset, string msgId, string channel)
        {
            var response = await httpClient.GetAsync($"messages?start={start}&end={end}&event={@event}&limit={limit}&offset={offset}&msg_id={msgId}&channel={channel}");
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            return await response.Content.ReadAsAsync<ResponseType<List<MessageDetailsType>>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<MessageResponseType>> SendMessageAsync(MessageType msg)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(msg, new JsonSerializerOptions { WriteIndented = true })))
            {
                var response = await httpClient.PostAsync($"messages", content);
                if (!response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                    throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
                }
                return await response.Content.ReadAsAsync<ResponseType<MessageResponseType>>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ResponseType<MessageResponseType>> SendMimeMessageAsync(MimeMessageType msg)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(msg, new JsonSerializerOptions { WriteIndented = true })))
            {
                var response = await httpClient.PostAsync($"messages/mime", content);
                if (!response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Dictionary<string, object>>();
                    throw new Exception(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
                }
                return await response.Content.ReadAsAsync<ResponseType<MessageResponseType>>();
            }
        }
    }
}
