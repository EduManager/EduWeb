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
    }
}
