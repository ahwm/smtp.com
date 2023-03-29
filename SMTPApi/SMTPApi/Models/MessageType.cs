using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SMTPApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Disposition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RecipientType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Body
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Part> Parts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Attachment> Attachments { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Originator
    {
        /// <summary>
        /// 
        /// </summary>
        public RecipientType From { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("reply_to")]
        public RecipientType ReplyTo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Part
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Charset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Encoding { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Recipients
    {
        /// <summary>
        /// 
        /// </summary>
        public List<RecipientType> To { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RecipientType> CC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RecipientType> BCC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("bulk_list")]
        public List<RecipientType> BulkList { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MessageType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Recipients Recipients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Originator Originator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("custom_headers")]
        public Dictionary<string, string> CustomHeaders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Body Body { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MimeMessageType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Mime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Recipients Recipients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Originator Originator { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MessageResponseType
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("msg_id")]
        public string MessageId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Abuse
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Complaint> complaints { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Clicks
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Item> items { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Complaint
    {
        /// <summary>
        /// 
        /// </summary>
        public string report_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string provider { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// 
        /// </summary>
        public string finished { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int retries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @event { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 
        /// </summary>
        public Delivery delivery { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 
        /// </summary>
        public string open_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remote_ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ua { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string click_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string unsub_time { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MsgData
    {
        /// <summary>
        /// 
        /// </summary>
        public string rcpt_to { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subject { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Opens
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Item> items { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MessageDetailsType
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("msg_id")]
        public string MessageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("msg_time")]
        public int MessageTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string channel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SmtpVars smtp_vars { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MsgData msg_data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Details details { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Opens opens { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Clicks clicks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Abuse abuse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Unsubs unsubs { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SmtpVars
    {
    }
    /// <summary>
    /// 
    /// </summary>
    public class Unsubs
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Item> items { get; set; }
    }


}
