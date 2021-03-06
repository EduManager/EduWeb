﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Core.DomainRepository
{
    public interface IRoleRepository : IRepository
    {
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<Role> GetRoleBySchoolId(GetObjectByIdArgs args);

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<object> AddRole(AddRoleArgs args);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> DeleteRole(DeleteRoleArgs args);

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateRole(UpdateRoleArgs args);
    }
}
