using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Repository;

namespace Edu.Services
{
    public class SysConfigService
    {
        #region Singletonton

        private static SysConfigService _instance = new SysConfigService();

        private SysConfigService()
        {

        }

        public static SysConfigService Instance => _instance ?? (_instance = new SysConfigService());

        #endregion

        /// <summary>
        /// 通过Id获取学校信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<SchoolInfo> GetSchoolInfoById(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            
            return ContainerFactory<ISysConfigRepository>.Instance.GetSchoolInfoById(args);
        }


        /// <summary>
        /// 更新学校Logo
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateSchoolImg(UpdateSchoolImgArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ImgPath, "ImgPath", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<ISysConfigRepository>.Instance.UpdateSchoolImg(args);
        }

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<SysConfig> GetSysConfigByUserId(GetSysConfigByUserIdArgs args)
        {
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<ISysConfigRepository>.Instance.GetSysConfigByUserId(args);
        }

        /// <summary>
        /// 创建或更新用户配置
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public  CommandResult<int> CreateOrUpdateSysConfig(CreateOrUpdateSysConfigArgs args)
        {
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.SKey, "SKey", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.SValue, "SValue", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<ISysConfigRepository>.Instance.CreateOrUpdateSysConfig(args);
        }
    }
}
