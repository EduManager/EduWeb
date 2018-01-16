using System;

namespace Edu.Model
{
    public class DomainEntity : IDomainEntity
    {
        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
