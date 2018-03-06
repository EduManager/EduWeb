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
            return null;
        }

        public CommandResult<int> DeleteCampus(DeleteCampusArgs args)
        {
            throw new NotImplementedException();
        }

        public QueryResult<Campus> GetCampusBySchoolId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Campus>("get_campus_by_school_id",
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
            throw new NotImplementedException();
        }
    }
}
