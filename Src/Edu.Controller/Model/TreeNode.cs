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
    public class TreeNode
    {
        [JsonProperty("id")]
        [DataMember]
        public int Id { get; set; }

        [JsonProperty("pId")]
        [DataMember]
        public int PId { get; set; }

        [JsonProperty("name")]
        [DataMember]
        public string Name { get; set; }

        [JsonProperty("checked")]
        [DataMember]
        public bool Checked { get; set; }

        [JsonProperty("open")]
        [DataMember]
        public bool Open => true;
    }
}
