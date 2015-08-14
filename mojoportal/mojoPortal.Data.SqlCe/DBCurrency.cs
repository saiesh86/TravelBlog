﻿// Author:					Joe Audette
// Created:					2010-04-04
// Last Modified:			2010-04-04
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
    public static class DBCurrency
    {
        private static String GetConnectionString()
        {
            return DBPortal.GetConnectionString();
        }

        /// <summary>
        /// Inserts a row in the mp_Currency table. Returns rows affected count.
        /// </summary>
        /// <param name="guid"> guid </param>
        /// <param name="title"> title </param>
        /// <param name="code"> code </param>
        /// <param name="symbolLeft"> symbolLeft </param>
        /// <param name="symbolRight"> symbolRight </param>
        /// <param name="decimalPointChar"> decimalPointChar </param>
        /// <param name="thousandsPointChar"> thousandsPointChar </param>
        /// <param name="decimalPlaces"> decimalPlaces </param>
        /// <param name="value"> value </param>
        /// <param name="lastModified"> lastModified </param>
        /// <param name="created"> created </param>
        /// <returns>int</returns>
        public static int Create(
            Guid guid,
            string title,
            string code,
            string symbolLeft,
            string symbolRight,
            string decimalPointChar,
            string thousandsPointChar,
            string decimalPlaces,
            decimal value,
            DateTime lastModified,
            DateTime created)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("INSERT INTO mp_Currency ");
            sqlCommand.Append("(");
            sqlCommand.Append("Guid, ");
            sqlCommand.Append("Title, ");
            sqlCommand.Append("Code, ");
            sqlCommand.Append("SymbolLeft, ");
            sqlCommand.Append("SymbolRight, ");
            sqlCommand.Append("DecimalPointChar, ");
            sqlCommand.Append("ThousandsPointChar, ");
            sqlCommand.Append("DecimalPlaces, ");
            sqlCommand.Append("Value, ");
            sqlCommand.Append("LastModified, ");
            sqlCommand.Append("Created ");
            sqlCommand.Append(")");

            sqlCommand.Append(" VALUES ");
            sqlCommand.Append("(");
            sqlCommand.Append("@Guid, ");
            sqlCommand.Append("@Title, ");
            sqlCommand.Append("@Code, ");
            sqlCommand.Append("@SymbolLeft, ");
            sqlCommand.Append("@SymbolRight, ");
            sqlCommand.Append("@DecimalPointChar, ");
            sqlCommand.Append("@ThousandsPointChar, ");
            sqlCommand.Append("@DecimalPlaces, ");
            sqlCommand.Append("@Value, ");
            sqlCommand.Append("@LastModified, ");
            sqlCommand.Append("@Created ");
            sqlCommand.Append(")");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[11];

            arParams[0] = new SqlCeParameter("@Guid", SqlDbType.UniqueIdentifier);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = guid;

            arParams[1] = new SqlCeParameter("@Title", SqlDbType.NVarChar, 50);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = title;

            arParams[2] = new SqlCeParameter("@Code", SqlDbType.NChar, 3);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = code;

            arParams[3] = new SqlCeParameter("@SymbolLeft", SqlDbType.NVarChar, 15);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = symbolLeft;

            arParams[4] = new SqlCeParameter("@SymbolRight", SqlDbType.NVarChar, 15);
            arParams[4].Direction = ParameterDirection.Input;
            arParams[4].Value = symbolRight;

            arParams[5] = new SqlCeParameter("@DecimalPointChar", SqlDbType.NChar, 1);
            arParams[5].Direction = ParameterDirection.Input;
            arParams[5].Value = decimalPointChar;

            arParams[6] = new SqlCeParameter("@ThousandsPointChar", SqlDbType.NChar, 1);
            arParams[6].Direction = ParameterDirection.Input;
            arParams[6].Value = thousandsPointChar;

            arParams[7] = new SqlCeParameter("@DecimalPlaces", SqlDbType.NChar, 1);
            arParams[7].Direction = ParameterDirection.Input;
            arParams[7].Value = decimalPlaces;

            arParams[8] = new SqlCeParameter("@Value", SqlDbType.Decimal);
            arParams[8].Direction = ParameterDirection.Input;
            arParams[8].Value = value;

            arParams[9] = new SqlCeParameter("@LastModified", SqlDbType.DateTime);
            arParams[9].Direction = ParameterDirection.Input;
            arParams[9].Value = lastModified;

            arParams[10] = new SqlCeParameter("@Created", SqlDbType.DateTime);
            arParams[10].Direction = ParameterDirection.Input;
            arParams[10].Value = created;

            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return rowsAffected;


        }

        /// <summary>
        /// Updates a row in the mp_Currency table. Returns true if row updated.
        /// </summary>
        /// <param name="guid"> guid </param>
        /// <param name="title"> title </param>
        /// <param name="code"> code </param>
        /// <param name="symbolLeft"> symbolLeft </param>
        /// <param name="symbolRight"> symbolRight </param>
        /// <param name="decimalPointChar"> decimalPointChar </param>
        /// <param name="thousandsPointChar"> thousandsPointChar </param>
        /// <param name="decimalPlaces"> decimalPlaces </param>
        /// <param name="value"> value </param>
        /// <param name="lastModified"> lastModified </param>
        /// <param name="created"> created </param>
        /// <returns>bool</returns>
        public static bool Update(
            Guid guid,
            string title,
            string code,
            string symbolLeft,
            string symbolRight,
            string decimalPointChar,
            string thousandsPointChar,
            string decimalPlaces,
            decimal value,
            DateTime lastModified)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("UPDATE mp_Currency ");
            sqlCommand.Append("SET  ");
            sqlCommand.Append("Title = @Title, ");
            sqlCommand.Append("Code = @Code, ");
            sqlCommand.Append("SymbolLeft = @SymbolLeft, ");
            sqlCommand.Append("SymbolRight = @SymbolRight, ");
            sqlCommand.Append("DecimalPointChar = @DecimalPointChar, ");
            sqlCommand.Append("ThousandsPointChar = @ThousandsPointChar, ");
            sqlCommand.Append("DecimalPlaces = @DecimalPlaces, ");
            sqlCommand.Append("Value = @Value, ");
            sqlCommand.Append("LastModified = @LastModified ");


            sqlCommand.Append("WHERE  ");
            sqlCommand.Append("Guid = @Guid ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[10];

            arParams[0] = new SqlCeParameter("@Guid", SqlDbType.UniqueIdentifier);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = guid;

            arParams[1] = new SqlCeParameter("@Title", SqlDbType.NVarChar, 50);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = title;

            arParams[2] = new SqlCeParameter("@Code", SqlDbType.NChar, 3);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = code;

            arParams[3] = new SqlCeParameter("@SymbolLeft", SqlDbType.NVarChar, 15);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = symbolLeft;

            arParams[4] = new SqlCeParameter("@SymbolRight", SqlDbType.NVarChar, 15);
            arParams[4].Direction = ParameterDirection.Input;
            arParams[4].Value = symbolRight;

            arParams[5] = new SqlCeParameter("@DecimalPointChar", SqlDbType.NChar, 1);
            arParams[5].Direction = ParameterDirection.Input;
            arParams[5].Value = decimalPointChar;

            arParams[6] = new SqlCeParameter("@ThousandsPointChar", SqlDbType.NChar, 1);
            arParams[6].Direction = ParameterDirection.Input;
            arParams[6].Value = thousandsPointChar;

            arParams[7] = new SqlCeParameter("@DecimalPlaces", SqlDbType.NChar, 1);
            arParams[7].Direction = ParameterDirection.Input;
            arParams[7].Value = decimalPlaces;

            arParams[8] = new SqlCeParameter("@Value", SqlDbType.Decimal);
            arParams[8].Direction = ParameterDirection.Input;
            arParams[8].Value = value;

            arParams[9] = new SqlCeParameter("@LastModified", SqlDbType.DateTime);
            arParams[9].Direction = ParameterDirection.Input;
            arParams[9].Value = lastModified;

            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        /// <summary>
        /// Deletes a row from the mp_Currency table. Returns true if row deleted.
        /// </summary>
        /// <param name="guid"> guid </param>
        /// <returns>bool</returns>
        public static bool Delete(Guid guid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("DELETE FROM mp_Currency ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("Guid = @Guid ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@Guid", SqlDbType.UniqueIdentifier);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = guid;

            int rowsAffected = SqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_Currency table.
        /// </summary>
        /// <param name="guid"> guid </param>
        public static IDataReader GetOne(Guid guid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_Currency ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("Guid = @Guid ");
            sqlCommand.Append(";");

            SqlCeParameter[] arParams = new SqlCeParameter[1];

            arParams[0] = new SqlCeParameter("@Guid", SqlDbType.UniqueIdentifier);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = guid;

            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                arParams);

        }

        /// <summary>
        /// Gets an IDataReader with all rows in the mp_Currency table.
        /// </summary>
        public static IDataReader GetAll()
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_Currency ");
            sqlCommand.Append("ORDER BY ");
            sqlCommand.Append("Title ");
            sqlCommand.Append(";");

            //SqlCeParameter[] arParams = new SqlCeParameter[1];

            //arParams[0] = new SqlCeParameter("@ApplicationID", SqlDbType.UniqueIdentifier);
            //arParams[0].Direction = ParameterDirection.Input;
            //arParams[0].Value = applicationId;

            return SqlHelper.ExecuteReader(
                GetConnectionString(),
                CommandType.Text,
                sqlCommand.ToString(),
                null);

        }


    }
}
