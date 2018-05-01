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
    public class ClassesService
    {
        #region Singletonton

        private static ClassesService _instance = new ClassesService();

        private ClassesService()
        {

        }

        public static ClassesService Instance => _instance ?? (_instance = new ClassesService());

        #endregion

        /// <summary>
        /// 获取全部班级
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Classes> GetClassesBySchoolId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<IClassesRepository>.Instance.GetClassesBySchoolId(args);
        }

        /// <summary>
        /// 获取班级的课时表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<AttendClass> GetAttendClassesByClassId(GetAttendByClassIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ClassId, "ClassId", Arguments.Positive);

            return ContainerFactory<IClassesRepository>.Instance.GetAttendClassesByClassId(args);
        }
        /// <summary>
        /// 添加课时
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddAttendClass(AddAttendClassArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            return ContainerFactory<IClassesRepository>.Instance.AddAttendClass(args);
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> DeleteClass(DeleteClassArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ClassId, "ClassId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IClassesRepository>.Instance.DeleteClass(args);
        }

        /// <summary>
        /// 编辑班级
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateClass(UpdateClassesArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IClassesRepository>.Instance.UpdateClass(args);
        }
        /// <summary>
        /// 删除课时
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> DeleteAttendClass(DeleteAttendClassArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.AttendClassId, "AttendClassId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IClassesRepository>.Instance.DeleteAttendClass(args);
        }

        /// <summary>
        /// 编辑课时
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateAttendClass(UpdateAttendClassArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IClassesRepository>.Instance.UpdateAttendClass(args);
        }
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddClass(AddClassesArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            return ContainerFactory<IClassesRepository>.Instance.AddClass(args);
        }
    }
}
