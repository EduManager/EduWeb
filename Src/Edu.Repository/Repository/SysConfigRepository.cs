using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Repository.Repository
{
    internal class SysConfigRepository : BaseRepository, ISysConfigRepository
    {
        public QueryResult<SysConfig> GetSysConfigByUserId(GetSysConfigByUserIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<SysConfig>(0,
                        "get_sys_config_by_user_id", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "系统配置模块--通过用户Id获取用户配置列表失败", e);
                return QueryResult.Failure<SysConfig>(e.ToString());
            }
        }

        public CommandResult<int> CreateOrUpdateSysConfig(CreateOrUpdateSysConfigArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "create_or_update_sys_config", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "系统配置模块--创建或更新配置失败", e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
    }
}
