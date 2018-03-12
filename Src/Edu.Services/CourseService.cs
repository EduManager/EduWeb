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
        /// 获取课程列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Course> GetCourseBySchoolId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<ICourseRepository>.Instance.GetCourseBySchoolId(args);
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

        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddCourse(AddCourseArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseTypeId, "CourseTypeId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseName, "CourseName", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            return ContainerFactory<ICourseRepository>.Instance.AddCourse(args);
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> DeleteCourse(DeleteCourseArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<ICourseRepository>.Instance.DeleteCourse(args);
        }

        /// <summary>
        /// 编辑课程
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateCourse(UpdateCourseArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseTypeId, "CourseTypeId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseName, "Description", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<ICourseRepository>.Instance.UpdateCourse(args);
        }

    }
}
