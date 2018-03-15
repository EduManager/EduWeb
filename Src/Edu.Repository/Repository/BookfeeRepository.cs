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
        public CommandResult<int> AddBookfee(AddBookfeeArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(1, "add_fees", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "校区管理-添加教材杂费失败，SchoolId:" + args.SchoolId , e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> DeleteBookfee(DeleteBookfeeArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(1, "delete_fees", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "校区管理-教材杂费失败，CampusId:" + args.FeeId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

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

        public CommandResult<int> UpdateBookfee(UpdateBookfeeArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(1, "update_fees", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "校区管理-编辑教材杂费失败，FeeId:" + args.FeeId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
    }
}
