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
    public class ApiKeysType
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ApiKeyType> Items { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ApiKeyType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date_created")]
        public string DateCreated { get; set; }
    }
}
