using System.Runtime.Serialization;

namespace Edu.Model.Core
{
    [DataContract]
    public class RoleMenuItem : DomainEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }
}
