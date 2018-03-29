﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;
using Domain;
using Common;
namespace BLL {
	public partial class B_Users
	{

        private readonly IUsers dal = new D_Users();
		public B_Users()
		{}
		//这个里面是通用方法,实现增删改查排序(动软代码生成器自动生成)
		#region  Method
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Domain.Users Get(int id) 
        {
            return dal.Get(id);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public IList<Domain.Users> GetList(List<SearchTemplate> st, List<SortOrder> order) 
        {

            return dal.GetList(st,order);
        }

        /// <summary>
        /// 获取当前条件下的用户总记录
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public int GetCount(List<SearchTemplate> st)
        {
            return dal.GetCount(st);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="m_user"></param>
        /// <returns></returns>
        public int Save(Domain.Users m_user) 
        {
            return Convert.ToInt32(dal.Save(m_user));
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="m_user"></param>
        /// <returns></returns>
        public void Update(Domain.Users m_user) 
        {
            dal.Update(m_user);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public bool Exists(int id) 
        {
            return dal.Exists(id);
        }
		#endregion

        #region 自定义

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="un"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Domain.Users Login(string un, string pwd)
        {
            List<SearchTemplate> st = new List<SearchTemplate>()
            {
                new SearchTemplate(){key="user_name",value=un,searchType=Common.EnumBase.SearchType.Eq},
                new SearchTemplate(){key="password",value=pwd,searchType=Common.EnumBase.SearchType.Eq}
            };
            IList<Domain.Users> list = GetList(st, null);
            if (list.Count > 0) return list[0];
            return null;
        }

        #endregion
    }
}