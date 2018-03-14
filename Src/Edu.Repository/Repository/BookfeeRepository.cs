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
    internal class BookfeeRepository : BaseRepository, IBookfeeRepository
    {
        //public CommandResult<int> AddFee(AddCampusArgs args)
        //{
        //    try
        //    {
        //        var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(0, "add_campus", args);
        //        if (result.Code == 200 && result.Items.Count > 0)
        //        {
        //            return CommandResult.Success(result.Items[0]);
        //        }
        //        return CommandResult.Failure<int>();
        //    }
        //    catch (Exception e)
        //    {
        //        LogHelper.Error(this.GetType(), "校区管理-添加校区失败，SchoolId:" + args.SchoolId + ",学校编号:" + args.SchoolId, e);
        //        return CommandResult.Failure<int>(e.ToString());
        //    }
        //}

        //public CommandResult<int> DeleteCampus(DeleteCampusArgs args)
        //{
        //    try
        //    {
        //        var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "delete_campus", args);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        LogHelper.Error(this.GetType(), "校区管理-删除校区失败，CampusId:" + args.CampusId, e);
        //        return CommandResult.Failure<int>(e.ToString());
        //    }
        //}

        public QueryResult<Bookfee> GetFeeBySchoolId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Bookfee>(args.SchoolId, "get_fees_by_school_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过学校ID获取教材杂费列表失败", e);
                return QueryResult.Failure<Bookfee>(e.ToString());
            }
        }

        //public CommandResult<int> UpdateCampus(UpdateCampusArgs args)
        //{
        //    try
        //    {
        //        var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "update_campus", args);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        LogHelper.Error(this.GetType(), "校区管理-编辑校区失败，CampusId:" + args.CampusId, e);
        //        return CommandResult.Failure<int>(e.ToString());
        //    }
        //}
    }
}
