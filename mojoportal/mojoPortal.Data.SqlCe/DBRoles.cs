﻿// Author:					Joe Audette
// Created:					2010-04-06
// Last Modified:			2012-04-10
// 
// The use and distribution terms for this software are covered by the 
// Common Public License 1.0 (http://opensource.org/licenses/cpl.php)  
// which can be found in the file CPL.TXT at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by 
// the terms of this license.
//
// You must not remove this notice, or any other, from this software.

using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Data.SqlServerCe;

namespace mojoPortal.Data
{
    public static class DBRoles
    {
        private static String GetConnectionString()
        {
            return DBPortal.GetConnectionString();
        }


        public static int RoleCreate(
            Guid roleGuid,
            Guid siteGuid,
            int siteId,
            string roleName)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("INSERT INTO mp_Roles ");
            sqlCommand.Append("(");
            sqlCommand.Append("SiteID, ");
            sqlCommand.Append("RoleName, ");
            sqlCommand.Append("DisplayName, ");
            sqlCommand.Append("SiteGuid, ");
            sqlCommand.Append("RoleGuid ");
            sqlCommand.Append(")");

            sqlCommand.Append(" VALUES ");
            sqlCommand.Append("(");
            sqlCommand.Append("@SiteID, ");
            sqlCommand.Append("@RoleName, ");
            sqlCommand.Append("@DisplayName, ");
            sqlCommand.Append("@SiteGuid, ");
            sqlCommand.Append("@RoleGuid ");
            sqlCommand.Append(")");
            
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[5];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@RoleName", SqlDbType.NVarChar, 50);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleName;

            arParams[2] = new SqlCeParameter("@DisplayName", SqlDbType.NVarChar, 50);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = roleName;

            arParams[3] = new SqlCeParameter("@SiteGuid", SqlDbType.UniqueIdentifier);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = siteGuid;

            arParams[4] = new SqlCeParameter("@RoleGuid", SqlDbType.UniqueIdentifier);
            arParams[4].Direction = ParameterDirection.Input;
            arParams[4].Value = roleGuid;


            int newId = Convert.ToInt32(SqlHelper.DoInsertGetIdentitiy(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams));

            return newId;

        }

        public static bool Update(int roleId, string roleName)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("UPDATE mp_Roles ");
            sqlCommand.Append("SET  ");
            sqlCommand.Append("DisplayName = @DisplayName ");
            
            sqlCommand.Append("WHERE  ");
            sqlCommand.Append("RoleID = @RoleID ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = roleId;

            arParams[1] = new SqlCeParameter("@DisplayName", SqlDbType.NVarChar, 50);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleName;

            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        public static bool Delete(int roleId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("DELETE FROM mp_Roles ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("RoleID = @RoleID ");
            //these roles are not allowed to be deleted
            sqlCommand.Append("AND RoleName  <> 'Admins' ");
            sqlCommand.Append("AND RoleName <> 'Content Administrators' ");
            sqlCommand.Append("AND RoleName <> 'Authenticated Users' ");
            sqlCommand.Append("AND RoleName <> 'Role Admins' ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = roleId;

            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        public static bool DeleteUserRoles(int userId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("DELETE FROM mp_UserRoles ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("UserID = @UserID ");
            
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@UserID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userId;

            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        public static bool Exists(int siteId, string roleName)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  Count(*) ");
            sqlCommand.Append("FROM	mp_Roles ");
            sqlCommand.Append("WHERE SiteID = @SiteID ");
            sqlCommand.Append("AND (RoleName = @RoleName OR DisplayName = @RoleName) ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@RoleName", SqlDbType.NVarChar, 50);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleName;

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams));

            return (count > 0);
        }

        public static IDataReader GetById(int roleId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_Roles ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("RoleID = @RoleID ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = roleId;

            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        public static IDataReader GetByName(int siteId, string roleName)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_Roles ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("SiteID = @SiteID ");
            sqlCommand.Append("AND RoleName = @RoleName ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@RoleName", SqlDbType.NVarChar, 50);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleName;

            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        public static IDataReader GetSiteRoles(int siteId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT ");
            sqlCommand.Append("r.RoleID, ");
            sqlCommand.Append("r.SiteID, ");
            sqlCommand.Append("r.RoleName, ");
            sqlCommand.Append("r.DisplayName, ");
            sqlCommand.Append("r.SiteGuid, ");
            sqlCommand.Append("r.RoleGuid, ");
            sqlCommand.Append("COUNT(ur.UserID) As MemberCount ");

            sqlCommand.Append("FROM	mp_Roles r ");

            sqlCommand.Append("LEFT OUTER JOIN mp_UserRoles ur ");
            sqlCommand.Append("ON ur.RoleID = r.RoleID ");

            sqlCommand.Append("WHERE ");

            sqlCommand.Append("r.SiteID = @SiteID ");

            sqlCommand.Append("GROUP BY ");
            sqlCommand.Append("r.RoleID, ");
            sqlCommand.Append("r.SiteID, ");
            sqlCommand.Append("r.RoleName, ");
            sqlCommand.Append("r.DisplayName, ");
            sqlCommand.Append("r.SiteGuid, ");
            sqlCommand.Append("r.RoleGuid ");

            sqlCommand.Append("ORDER BY r.DisplayName ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        public static IDataReader GetRoleMembers(int roleId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT ");
            sqlCommand.Append("ur.UserID, ");
            sqlCommand.Append("u.[Name], ");
            sqlCommand.Append("u.Email, ");
            sqlCommand.Append("u.LoginName ");


            sqlCommand.Append("FROM	mp_UserRoles ur ");

            sqlCommand.Append("JOIN mp_Users  u ");
            sqlCommand.Append("ON u.UserID = ur.UserID ");

            sqlCommand.Append("WHERE ");
            sqlCommand.Append("ur.RoleID = @RoleID ");

            sqlCommand.Append("ORDER BY u.[Name] ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = roleId;

            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        public static int GetCountOfUsersNotInRole(int siteId, int roleId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  Count(*) ");
            sqlCommand.Append("FROM	mp_Users  u ");

            sqlCommand.Append("LEFT OUTER JOIN mp_UserRoles ur ");
            sqlCommand.Append("ON u.UserID = ur.UserID ");
            sqlCommand.Append("AND ur.RoleID = @RoleID ");

            sqlCommand.Append("WHERE u.SiteID = @SiteID ");
            sqlCommand.Append("AND ur.RoleID IS NULL ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleId;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams));

        }

        public static IDataReader GetUsersNotInRole(
            int siteId,
            int roleId,
            int pageNumber,
            int pageSize,
            out int totalPages)
        {
            int pageLowerBound = (pageSize * pageNumber) - pageSize;
            totalPages = 1;
            int totalRows = GetCountOfUsersNotInRole(siteId, roleId);

            if (pageSize > 0) totalPages = totalRows / pageSize;

            if (totalRows <= pageSize)
            {
                totalPages = 1;
            }
            else
            {
                int remainder;
                Math.DivRem(totalRows, pageSize, out remainder);
                if (remainder > 0)
                {
                    totalPages += 1;
                }
            }

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT * FROM ");
            sqlCommand.Append("(");
            sqlCommand.Append("SELECT TOP (" + pageSize.ToString(CultureInfo.InvariantCulture) + ") * FROM ");
            sqlCommand.Append("(");
            sqlCommand.Append("SELECT TOP (" + pageNumber.ToString(CultureInfo.InvariantCulture) + " * " + pageSize.ToString(CultureInfo.InvariantCulture) + ")  ");
            sqlCommand.Append("u.UserID, ");
            sqlCommand.Append("u.[Name], ");
            sqlCommand.Append("u.Email, ");
            sqlCommand.Append("u.LoginName ");


            sqlCommand.Append("FROM	mp_Users u ");

            sqlCommand.Append("LEFT OUTER JOIN mp_UserRoles ur ");
            sqlCommand.Append("ON u.UserID = ur.UserID ");
            sqlCommand.Append("AND ur.RoleID = @RoleID ");

            sqlCommand.Append("WHERE u.SiteID = @SiteID ");
            sqlCommand.Append("AND ur.RoleID IS NULL ");

            sqlCommand.Append("ORDER BY  ");
            sqlCommand.Append("u.[Name]  ");

            sqlCommand.Append(") AS t1 ");
            //sqlCommand.Append("ORDER BY  ");

            sqlCommand.Append(") AS t2 ");

            //sqlCommand.Append("WHERE   ");
            //sqlCommand.Append("ORDER BY  ");
            sqlCommand.Append(";");


            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleId;


            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        public static int GetCountOfUsersInRole(int siteId, int roleId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  Count(*) ");
            sqlCommand.Append("FROM	mp_Users  u ");

            sqlCommand.Append("JOIN mp_UserRoles ur ");
            sqlCommand.Append("ON u.UserID = ur.UserID ");
            sqlCommand.Append("AND ur.RoleID = @RoleID ");

            sqlCommand.Append("WHERE u.SiteID = @SiteID ");

            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleId;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams));

        }

        public static IDataReader GetUsersInRole(
            int siteId,
            int roleId,
            int pageNumber,
            int pageSize,
            out int totalPages)
        {
            int pageLowerBound = (pageSize * pageNumber) - pageSize;
            totalPages = 1;
            int totalRows = GetCountOfUsersInRole(siteId, roleId);

            if (pageSize > 0) totalPages = totalRows / pageSize;

            if (totalRows <= pageSize)
            {
                totalPages = 1;
            }
            else
            {
                int remainder;
                Math.DivRem(totalRows, pageSize, out remainder);
                if (remainder > 0)
                {
                    totalPages += 1;
                }
            }

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT * FROM ");
            sqlCommand.Append("(");
            sqlCommand.Append("SELECT TOP (" + pageSize.ToString(CultureInfo.InvariantCulture) + ") * FROM ");
            sqlCommand.Append("(");
            sqlCommand.Append("SELECT TOP (" + pageNumber.ToString(CultureInfo.InvariantCulture) + " * " + pageSize.ToString(CultureInfo.InvariantCulture) + ")  ");
            sqlCommand.Append("u.UserID, ");
            sqlCommand.Append("u.[Name], ");
            sqlCommand.Append("u.Email, ");
            sqlCommand.Append("u.LoginName ");


            sqlCommand.Append("FROM	mp_Users u ");

            sqlCommand.Append("JOIN mp_UserRoles ur ");
            sqlCommand.Append("ON u.UserID = ur.UserID ");
            sqlCommand.Append("AND ur.RoleID = @RoleID ");

            sqlCommand.Append("WHERE u.SiteID = @SiteID ");
           

            sqlCommand.Append("ORDER BY  ");
            sqlCommand.Append("u.[Name]  ");

            sqlCommand.Append(") AS t1 ");
            //sqlCommand.Append("ORDER BY  ");

            sqlCommand.Append(") AS t2 ");

            //sqlCommand.Append("WHERE   ");
            //sqlCommand.Append("ORDER BY  ");
            sqlCommand.Append(";");


            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleId;


            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        public static IDataReader GetRolesUserIsNotIn(
            int siteId,
            int userId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  r.* ");
            sqlCommand.Append("FROM	mp_Roles r ");

            sqlCommand.Append("LEFT OUTER JOIN mp_UserRoles ur ");
            sqlCommand.Append("ON r.RoleID = ur.RoleID ");
            sqlCommand.Append("AND ur.UserID = @UserID ");

            sqlCommand.Append("WHERE ");
            sqlCommand.Append("r.SiteID = @SiteID ");
            sqlCommand.Append("AND ur.UserID IS NULL ");
            sqlCommand.Append("ORDER BY	r.[DisplayName] ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            arParams[1] = new SqlCeParameter("@UserID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = userId;

            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        public static bool AddUser(
            int roleId,
            int userId,
            Guid roleGuid,
            Guid userGuid
            )
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("INSERT INTO mp_UserRoles ");
            sqlCommand.Append("(");
            sqlCommand.Append("UserID, ");
            sqlCommand.Append("RoleID, ");
            sqlCommand.Append("UserGuid, ");
            sqlCommand.Append("RoleGuid ");
            sqlCommand.Append(")");

            sqlCommand.Append(" VALUES ");
            sqlCommand.Append("(");
            sqlCommand.Append("@UserID, ");
            sqlCommand.Append("@RoleID, ");
            sqlCommand.Append("@UserGuid, ");
            sqlCommand.Append("@RoleGuid ");
            sqlCommand.Append(")");
            
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[4];

            arParams[0] = new SqlCeParameter("@UserID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userId;

            arParams[1] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleId;

            arParams[2] = new SqlCeParameter("@UserGuid", SqlDbType.UniqueIdentifier);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = userGuid;

            arParams[3] = new SqlCeParameter("@RoleGuid", SqlDbType.UniqueIdentifier);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = roleGuid;


            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > 0);

        }

        public static bool RemoveUser(int roleId, int userId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("DELETE FROM mp_UserRoles ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("UserID = @UserID ");
            sqlCommand.Append("AND ");
            sqlCommand.Append("RoleID = @RoleID ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[2];

            arParams[0] = new SqlCeParameter("@UserID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userId;

            arParams[1] = new SqlCeParameter("@RoleID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = roleId;

            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        public static int GetCountOfSiteRoles(int siteId)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  Count(*) ");
            sqlCommand.Append("FROM	mp_Roles ");
            sqlCommand.Append("WHERE SiteID = @SiteID ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@SiteID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteId;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams));

        }

    }
}
