using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Repository
{
    internal class CampusRepository : BaseRepository, ICampusRepository
    {
        public CommandResult<int> AddCampus(AddCampusArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(0, "add_campus", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "校区管理-添加校区失败，SchoolId:" + args.SchoolId + ",学校编号:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> DeleteCampus(DeleteObjectArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "delete_campus", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "校区管理-删除校区失败，CampusId:" + args.ObjectId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
        
        public QueryResult<Campus> GetCampusBySchoolId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Campus>(0,"get_campus_by_school_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过学校ID获取校区列表败", e);
                return QueryResult.Failure<Campus>(e.ToString());
            }
        }
        public QueryResult<Campus> GetCampusByRegionName(GetObjectByNameArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Campus>(0, "get_school_region_by_name",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过学校ID获取校区列表败", e);
                return QueryResult.Failure<Campus>(e.ToString());
            }
        }

        public CommandResult<int> UpdateCampus(UpdateCampusArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "update_campus", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "校区管理-编辑校区失败，CampusId:" + args.CampusId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
    }
}
