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
    public class DomainType
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("domain_name")]
        public string DomainName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Enabled { get; set; }
    }
}
