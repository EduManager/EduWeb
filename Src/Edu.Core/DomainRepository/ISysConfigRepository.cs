using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Core.DomainRepository
{
    public interface ISysConfigRepository : IRepository
    {
        /// <summary>
        /// 通过Id获取学校信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<SchoolInfo> GetSchoolInfoById(GetObjectByIdArgs args);

        /// <summary>
        /// 更新学校Logo
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateSchoolImg(UpdateSchoolImgArgs args);

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<SysConfig> GetSysConfigByUserId(GetSysConfigByUserIdArgs args);

        /// <summary>
        /// 创建或更新用户配置
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> CreateOrUpdateSysConfig(CreateOrUpdateSysConfigArgs args);
    }
}
