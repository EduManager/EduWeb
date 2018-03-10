using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Services
{
  public  class CourseService
    {
        #region Singletonton

        private static CourseService _instance = new CourseService();

        private CourseService()
        {

        }

        public static CourseService Instance => _instance ?? (_instance = new CourseService());

        #endregion

        /// <summary>
        /// 获取课程类别列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<CourseType> GetCourseTypeBySchoolId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<ICourseRepository>.Instance.GetCourseTypeBySchoolId(args);
        }

        /// <summary>
        /// 添加课程类别
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddCourseType(AddCourseTypeArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseType, "CourseType", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Description, "Description", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            return ContainerFactory<ICourseRepository>.Instance.AddCourseType(args);
        }

        /// <summary>
        /// 删除课程类别
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> DeleteCourseType(DeleteCourseTypeArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseTypeId, "CourseTypeId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<ICourseRepository>.Instance.DeleteCourseType(args);
        }

        /// <summary>
        /// 编辑课程类别
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateCourseType(UpdateCourseTypeArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseType, "CourseType", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Description, "Description", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<ICourseRepository>.Instance.UpdateCourseType(args);
        }

    }
}
