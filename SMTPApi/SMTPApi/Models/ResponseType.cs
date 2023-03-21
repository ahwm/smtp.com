using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPApi.Models
{
    /// <summary>
    /// Base wrapper class for all responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseType<T>
    {
        /// <summary>
        /// Indicates status of the request
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Returned data
        /// </summary>
        public T Data { get; set; }
    }
}
