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
  public  class StudentService
    {
        #region Singletonton

        private static StudentService _instance = new StudentService();

        private StudentService()
        {

        }

        public static StudentService Instance => _instance ?? (_instance = new StudentService());

        #endregion

        /// <summary>
        /// 通过分页获取学生信息列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Student> GetStudentListByPaging(GetObjectsByPagingArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.PageSize, "PageSize", Arguments.Positive);
            ArgumentHelper.Require(args.PageIndex, "PageIndex", Arguments.Positive);

            return ContainerFactory<IStudentRepository>.Instance.GetStudentListByPaging(args);
        }


        /// <summary>
        /// 创建学生信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddStudent(AddStudentArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.RegionId, "SchoolRegionId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            ArgumentHelper.Require(args.Name, "姓名", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Tel1, "电话", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IStudentRepository>.Instance.AddStudent(args);
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> DeleteStudent(DeleteObjectArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ObjectId, "StudentId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "UserId", Arguments.Positive);

            return ContainerFactory<IStudentRepository>.Instance.DeleteStudent(args);
        }

        /// <summary>
        /// 通过id获取学生信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<Student> GetStudentById(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.OId, "Id", Arguments.Positive);

            return ContainerFactory<IStudentRepository>.Instance.GetStudentById(args);
        }

        /// <summary>
        /// 通过姓名和电话尾号模糊查询
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Student> QueryStudent(GetObjectsByPagingArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.PageSize, "PageSize", Arguments.Positive);
            ArgumentHelper.Require(args.PageIndex, "PageIndex", Arguments.Positive);

            return ContainerFactory<IStudentRepository>.Instance.GetStudentListByPaging(args);
        }
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateUserInfo(UpdateStudentArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.StudentId, "StudentId", Arguments.Positive);

            return ContainerFactory<IStudentRepository>.Instance.UpdateUserInfo(args);
        }
    }
}
