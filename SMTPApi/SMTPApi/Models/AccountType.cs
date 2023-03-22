using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMTPApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("company_name")] 
        public string CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AddressType Address { get; set; } = new AddressType();
        /// <summary>
        /// 
        /// </summary>
        public int Usage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date created")] // documentation says "date created" but other properties use snake_case
        public int DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreatedParsed 
        {
            get
            {
                DateTime? date = null;
                try
                {
                    date = DateTimeOffset.FromUnixTimeSeconds(DateCreated).DateTime;
                }
                catch { }

                return date;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AddressType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AccountStatusType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }
    }
}