using System.Runtime.Serialization;

namespace Edu.Model.Core
{
    [DataContract]
    public class RoleMenuItem : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public string MenuName { get; set; }
    }
}
