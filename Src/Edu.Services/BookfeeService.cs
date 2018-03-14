﻿using Edu.Core.DomainRepository;
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
  public  class BookfeeService
    {
        #region Singletonton

        private static BookfeeService _instance = new BookfeeService();

        private BookfeeService()
        {

        }

        public static BookfeeService Instance => _instance ?? (_instance = new BookfeeService());

        #endregion

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Bookfee> GetFeeBySchoolId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<IBookfeeRepository>.Instance.GetFeeBySchoolId(args);
        }

        ///// <summary>
        ///// 添加校区
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public CommandResult<int> AddCampus(AddCampusArgs args)
        //{
        //    ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
        //    ArgumentHelper.Require(args.CampusType, "CampusType", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.CampusName, "CampusName", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.Contract, "Contract", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.ContractTel, "ContractTel", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.Address, "Address", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.Tel, "Tel", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
        //    ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

        //    return ContainerFactory<ICampusRepository>.Instance.AddCampus(args);
        //}

        ///// <summary>
        ///// 删除校区
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public CommandResult<int> DeleteCampus(DeleteCampusArgs args)
        //{
        //    ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
        //    ArgumentHelper.Require(args.CampusId, "CampusId", Arguments.Positive);
        //    ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

        //    return ContainerFactory<ICampusRepository>.Instance.DeleteCampus(args);
        //}

        ///// <summary>
        ///// 编辑校区
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public CommandResult<int> UpdateCampus(UpdateCampusArgs args)
        //{
        //    ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
        //    ArgumentHelper.Require(args.CampusType, "CampusType", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.CampusName, "CampusName", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.Contract, "Contract", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.ContractTel, "ContractTel", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.Address, "Address", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.Tel, "Tel", Arguments.NotEmptyOrWhitespace);
        //    ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

        //    return ContainerFactory<ICampusRepository>.Instance.UpdateCampus(args);
        //}

    }
}