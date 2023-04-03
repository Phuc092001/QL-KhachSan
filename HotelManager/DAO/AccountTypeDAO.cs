﻿using DTO;
using System.Data;

namespace DAO
{
    public class AccountTypeDAO
    {
        private static AccountTypeDAO instance;

        #region Method
        public DataTable LoadFullStaffType()
        {
            string query = "USP_LoadFullStaffType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public AccountType GetStaffTypeByUserName(string username)
        {
            string query = "USP_GetNameStaffTypeByUserName @username";
            AccountType staffType = new AccountType(DataProvider.Instance.ExecuteQuery(query, new object[] { username }).Rows[0]);
            return staffType;
        }
        public bool Delete(string idStaffType)
        {
            string query = "USP_DeleteStaffType @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idStaffType }) > 0;
        }
        public bool Update(string idStaffType, string text)
        {
            string query = "USP_UpdateStaffType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idStaffType, text }) > 0;
        }

        public bool Insert(string id,string text)
        {
            string query = "USP_InsertStaffType @ID , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id , text }) > 0;
        }
        #endregion

        public static AccountTypeDAO Instance {
            get { if (instance == null) instance = new AccountTypeDAO(); return instance; }
            private set => instance = value; }
    }
}
