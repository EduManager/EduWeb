using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Edu.Controller.Model
{
    [DataContract]
    public class LoginUserInfo
    {
        [JsonProperty("valid_code")]
        [DataMember]
        public string ValidCode { get; set; }

        [JsonProperty("token")]
        [DataMember]
        public string Token { get; set; }

        [JsonProperty("account")]
        [DataMember]
        public string Account { get; set; }

        [JsonProperty("secret_password")]
        [DataMember]
        public string Password { get; set; }
        
        [JsonProperty("token_timespan")]
        [DataMember]
        public long TimeSpan { get; set; }
    }
}
