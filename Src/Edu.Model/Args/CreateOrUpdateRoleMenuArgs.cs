﻿namespace Edu.Model.Args
{
    public class CreateOrUpdateRoleMenuArgs
    {
        public int SchoolId { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }
    }
}
