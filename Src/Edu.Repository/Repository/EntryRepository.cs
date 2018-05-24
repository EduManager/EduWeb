using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Infrastructure.Sql;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Repository
{
    internal class EntryRepository : BaseRepository, IEntryRepository
    {
        public CommandResult<int> AddAccount(AddAccountArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(args.SchoolId, "add_account", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "报名缴费失败，SchoolId:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> AddEntry(AddEntryArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(args.SchoolId, "add_entry", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "学生报名失败，SchoolId:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> UpdateEntry(UpdateEntryArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(args.SchoolId, "update_entry", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "修改报名状态失败，EntryId:" + args.EntryId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
        /// <summary>
        /// 通过分页获取学生信息列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Entry> GetEntryListByPaging(GetObjectsByPagingArgs args)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@p_school_id", args.SchoolId);
                p.Add("@p_page_size", args.PageSize);
                p.Add("@p_page_now", args.PageIndex);
                p.Add("@p_order_string", args.OrderBy);
                p.Add("@p_where_string", args.WhereStr);
                p.Add("@p_out_rows", null, DbType.Int32, ParameterDirection.Output);
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Entry>(args.SchoolId, "get_entryInfos_by_paging", p);
                args.RowsCount = p.Get<int>("@p_out_rows");
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "学生模块--通过分页获取学生列表失败", e);
                return QueryResult.Failure<Entry>(e.ToString());
            }
        }

    }
}
