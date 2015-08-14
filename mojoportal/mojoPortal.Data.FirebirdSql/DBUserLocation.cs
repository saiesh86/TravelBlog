﻿///							DBUserLocation.cs
/// Author:					Joe Audette
/// Created:				2008-01-04
/// Last Modified:			2011-01-19
/// 
/// The use and distribution terms for this software are covered by the 
/// Common Public License 1.0 (http://opensource.org/licenses/cpl.php)  
/// which can be found in the file CPL.TXT at the root of this distribution.
/// By using this software in any fashion, you are agreeing to be bound by 
/// the terms of this license.
///
/// You must not remove this notice, or any other, from this software.

using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using FirebirdSql.Data.FirebirdClient;


namespace mojoPortal.Data
{
    public static class DBUserLocation
    {
       
        public static String DBPlatform()
        {
            return "FirebirdSql";
        }

        private static String GetConnectionString()
        {
            return ConfigurationManager.AppSettings["FirebirdConnectionString"];

        }


        /// <summary>
        /// Inserts a row in the mp_UserLocation table. Returns rows affected count.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="siteGuid"> siteGuid </param>
        /// <param name="iPAddress"> iPAddress </param>
        /// <param name="iPAddressLong"> iPAddressLong </param>
        /// <param name="hostname"> hostname </param>
        /// <param name="longitude"> longitude </param>
        /// <param name="latitude"> latitude </param>
        /// <param name="iSP"> iSP </param>
        /// <param name="continent"> continent </param>
        /// <param name="country"> country </param>
        /// <param name="region"> region </param>
        /// <param name="city"> city </param>
        /// <param name="timeZone"> timeZone </param>
        /// <param name="captureCount"> captureCount </param>
        /// <param name="firstCaptureUTC"> firstCaptureUTC </param>
        /// <param name="lastCaptureUTC"> lastCaptureUTC </param>
        /// <returns>int</returns>
        public static int Create(
            Guid rowID,
            Guid userGuid,
            Guid siteGuid,
            string iPAddress,
            long iPAddressLong,
            string hostname,
            double longitude,
            double latitude,
            string iSP,
            string continent,
            string country,
            string region,
            string city,
            string timeZone,
            int captureCount,
            DateTime firstCaptureUTC,
            DateTime lastCaptureUTC)
        {

            #region Bit Conversion


            #endregion

            FbParameter[] arParams = new FbParameter[17];


            arParams[0] = new FbParameter("@RowID", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = rowID.ToString();

            arParams[1] = new FbParameter("@UserGuid", FbDbType.Char, 36);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = userGuid.ToString();

            arParams[2] = new FbParameter("@SiteGuid", FbDbType.Char, 36);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = siteGuid.ToString();

            arParams[3] = new FbParameter("@IPAddress", FbDbType.VarChar, 50);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = iPAddress;

            arParams[4] = new FbParameter("@IPAddressLong", FbDbType.BigInt);
            arParams[4].Direction = ParameterDirection.Input;
            arParams[4].Value = iPAddressLong;

            arParams[5] = new FbParameter("@Hostname", FbDbType.VarChar, 255);
            arParams[5].Direction = ParameterDirection.Input;
            arParams[5].Value = hostname;

            arParams[6] = new FbParameter("@Longitude", FbDbType.Float);
            arParams[6].Direction = ParameterDirection.Input;
            arParams[6].Value = longitude;

            arParams[7] = new FbParameter("@Latitude", FbDbType.Float);
            arParams[7].Direction = ParameterDirection.Input;
            arParams[7].Value = latitude;

            arParams[8] = new FbParameter("@ISP", FbDbType.VarChar, 255);
            arParams[8].Direction = ParameterDirection.Input;
            arParams[8].Value = iSP;

            arParams[9] = new FbParameter("@Continent", FbDbType.VarChar, 255);
            arParams[9].Direction = ParameterDirection.Input;
            arParams[9].Value = continent;

            arParams[10] = new FbParameter("@Country", FbDbType.VarChar, 255);
            arParams[10].Direction = ParameterDirection.Input;
            arParams[10].Value = country;

            arParams[11] = new FbParameter("@Region", FbDbType.VarChar, 255);
            arParams[11].Direction = ParameterDirection.Input;
            arParams[11].Value = region;

            arParams[12] = new FbParameter("@City", FbDbType.VarChar, 255);
            arParams[12].Direction = ParameterDirection.Input;
            arParams[12].Value = city;

            arParams[13] = new FbParameter("@TimeZone", FbDbType.VarChar, 255);
            arParams[13].Direction = ParameterDirection.Input;
            arParams[13].Value = timeZone;

            arParams[14] = new FbParameter("@CaptureCount", FbDbType.Integer);
            arParams[14].Direction = ParameterDirection.Input;
            arParams[14].Value = captureCount;

            arParams[15] = new FbParameter("@FirstCaptureUTC", FbDbType.TimeStamp);
            arParams[15].Direction = ParameterDirection.Input;
            arParams[15].Value = firstCaptureUTC;

            arParams[16] = new FbParameter("@LastCaptureUTC", FbDbType.TimeStamp);
            arParams[16].Direction = ParameterDirection.Input;
            arParams[16].Value = lastCaptureUTC;


            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("INSERT INTO mp_UserLocation (");
            sqlCommand.Append("RowID, ");
            sqlCommand.Append("UserGuid, ");
            sqlCommand.Append("SiteGuid, ");
            sqlCommand.Append("IPAddress, ");
            sqlCommand.Append("IPAddressLong, ");
            sqlCommand.Append("Hostname, ");
            sqlCommand.Append("Longitude, ");
            sqlCommand.Append("Latitude, ");
            sqlCommand.Append("ISP, ");
            sqlCommand.Append("Continent, ");
            sqlCommand.Append("Country, ");
            sqlCommand.Append("Region, ");
            sqlCommand.Append("City, ");
            sqlCommand.Append("TimeZone, ");
            sqlCommand.Append("CaptureCount, ");
            sqlCommand.Append("FirstCaptureUTC, ");
            sqlCommand.Append("LastCaptureUTC )");


            sqlCommand.Append(" VALUES (");
            sqlCommand.Append("@RowID, ");
            sqlCommand.Append("@UserGuid, ");
            sqlCommand.Append("@SiteGuid, ");
            sqlCommand.Append("@IPAddress, ");
            sqlCommand.Append("@IPAddressLong, ");
            sqlCommand.Append("@Hostname, ");
            sqlCommand.Append("@Longitude, ");
            sqlCommand.Append("@Latitude, ");
            sqlCommand.Append("@ISP, ");
            sqlCommand.Append("@Continent, ");
            sqlCommand.Append("@Country, ");
            sqlCommand.Append("@Region, ");
            sqlCommand.Append("@City, ");
            sqlCommand.Append("@TimeZone, ");
            sqlCommand.Append("@CaptureCount, ");
            sqlCommand.Append("@FirstCaptureUTC, ");
            sqlCommand.Append("@LastCaptureUTC )");
            sqlCommand.Append(";");

            int rowsAffected = FBSqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);



            return rowsAffected;

        }


        /// <summary>
        /// Updates a row in the mp_UserLocation table. Returns true if row updated.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="siteGuid"> siteGuid </param>
        /// <param name="iPAddress"> iPAddress </param>
        /// <param name="iPAddressLong"> iPAddressLong </param>
        /// <param name="hostname"> hostname </param>
        /// <param name="longitude"> longitude </param>
        /// <param name="latitude"> latitude </param>
        /// <param name="iSP"> iSP </param>
        /// <param name="continent"> continent </param>
        /// <param name="country"> country </param>
        /// <param name="region"> region </param>
        /// <param name="city"> city </param>
        /// <param name="timeZone"> timeZone </param>
        /// <param name="captureCount"> captureCount </param>
        /// <param name="lastCaptureUTC"> lastCaptureUTC </param>
        /// <returns>bool</returns>
        public static bool Update(
            Guid rowID,
            Guid userGuid,
            Guid siteGuid,
            string iPAddress,
            long iPAddressLong,
            string hostname,
            double longitude,
            double latitude,
            string iSP,
            string continent,
            string country,
            string region,
            string city,
            string timeZone,
            int captureCount,
            DateTime lastCaptureUTC)
        {
            #region Bit Conversion


            #endregion

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("UPDATE mp_UserLocation ");
            sqlCommand.Append("SET  ");
            sqlCommand.Append("UserGuid = @UserGuid, ");
            sqlCommand.Append("SiteGuid = @SiteGuid, ");
            sqlCommand.Append("IPAddress = @IPAddress, ");
            sqlCommand.Append("IPAddressLong = @IPAddressLong, ");
            sqlCommand.Append("Hostname = @Hostname, ");
            sqlCommand.Append("Longitude = @Longitude, ");
            sqlCommand.Append("Latitude = @Latitude, ");
            sqlCommand.Append("ISP = @ISP, ");
            sqlCommand.Append("Continent = @Continent, ");
            sqlCommand.Append("Country = @Country, ");
            sqlCommand.Append("Region = @Region, ");
            sqlCommand.Append("City = @City, ");
            sqlCommand.Append("TimeZone = @TimeZone, ");
            sqlCommand.Append("CaptureCount = @CaptureCount, ");
            sqlCommand.Append("LastCaptureUTC = @LastCaptureUTC ");

            sqlCommand.Append("WHERE  ");
            sqlCommand.Append("RowID = @RowID ");
            sqlCommand.Append(";");
            FbParameter[] arParams = new FbParameter[16];

            arParams[0] = new FbParameter("@RowID", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = rowID.ToString();

            arParams[1] = new FbParameter("@UserGuid", FbDbType.Char, 36);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = userGuid.ToString();

            arParams[2] = new FbParameter("@SiteGuid", FbDbType.Char, 36);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = siteGuid.ToString();

            arParams[3] = new FbParameter("@IPAddress", FbDbType.VarChar, 50);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = iPAddress;

            arParams[4] = new FbParameter("@IPAddressLong", FbDbType.BigInt);
            arParams[4].Direction = ParameterDirection.Input;
            arParams[4].Value = iPAddressLong;

            arParams[5] = new FbParameter("@Hostname", FbDbType.VarChar, 255);
            arParams[5].Direction = ParameterDirection.Input;
            arParams[5].Value = hostname;

            arParams[6] = new FbParameter("@Longitude", FbDbType.Float);
            arParams[6].Direction = ParameterDirection.Input;
            arParams[6].Value = longitude;

            arParams[7] = new FbParameter("@Latitude", FbDbType.Float);
            arParams[7].Direction = ParameterDirection.Input;
            arParams[7].Value = latitude;

            arParams[8] = new FbParameter("@ISP", FbDbType.VarChar, 255);
            arParams[8].Direction = ParameterDirection.Input;
            arParams[8].Value = iSP;

            arParams[9] = new FbParameter("@Continent", FbDbType.VarChar, 255);
            arParams[9].Direction = ParameterDirection.Input;
            arParams[9].Value = continent;

            arParams[10] = new FbParameter("@Country", FbDbType.VarChar, 255);
            arParams[10].Direction = ParameterDirection.Input;
            arParams[10].Value = country;

            arParams[11] = new FbParameter("@Region", FbDbType.VarChar, 255);
            arParams[11].Direction = ParameterDirection.Input;
            arParams[11].Value = region;

            arParams[12] = new FbParameter("@City", FbDbType.VarChar, 255);
            arParams[12].Direction = ParameterDirection.Input;
            arParams[12].Value = city;

            arParams[13] = new FbParameter("@TimeZone", FbDbType.VarChar, 255);
            arParams[13].Direction = ParameterDirection.Input;
            arParams[13].Value = timeZone;

            arParams[14] = new FbParameter("@CaptureCount", FbDbType.Integer);
            arParams[14].Direction = ParameterDirection.Input;
            arParams[14].Value = captureCount;

            arParams[15] = new FbParameter("@LastCaptureUTC", FbDbType.TimeStamp);
            arParams[15].Direction = ParameterDirection.Input;
            arParams[15].Value = lastCaptureUTC;


            int rowsAffected = FBSqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        /// <summary>
        /// Deletes a row from the mp_UserLocation table. Returns true if row deleted.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        /// <returns>bool</returns>
        public static bool Delete(Guid rowID)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("DELETE FROM mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("RowID = @RowID ");
            sqlCommand.Append(";");
            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@RowID", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = rowID.ToString();


            int rowsAffected = FBSqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        public static bool DeleteByUser(Guid userGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("DELETE FROM mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("UserGuid = @UserGuid ");
            sqlCommand.Append(";");
            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@UserGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userGuid.ToString();


            int rowsAffected = FBSqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="rowID"> rowID </param>
        public static IDataReader GetOne(Guid rowID)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("RowID = @RowID ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@RowID", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = rowID.ToString();

            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="userguid"> userguid </param>
        /// <param name="iPAddress"> iPAddress </param>
        public static IDataReader GetOne(Guid userguid, long iPAddressLong)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("Userguid = @Userguid ");
            sqlCommand.Append("AND IPAddressLong = @IPAddressLong ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[2];

            arParams[0] = new FbParameter("@Userguid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userguid.ToString();

            arParams[1] = new FbParameter("@IPAddressLong", FbDbType.BigInt);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = iPAddressLong;

            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        public static IDataReader GetByUser(Guid userGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("UserGuid = @UserGuid ");
            sqlCommand.Append("ORDER BY LastCaptureUTC DESC ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@UserGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userGuid.ToString();

            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_UserLocation table.
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        public static IDataReader GetBySite(Guid siteGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("SiteGuid = @SiteGuid ");
            sqlCommand.Append("ORDER BY IPAddressLong ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@SiteGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteGuid.ToString();

            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

        }

        /// <summary>
        /// Gets an IDataReader with rows from the mp_Users table which have the passed in IP Address
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        public static IDataReader GetUsersByIPAddress(Guid siteGuid,  string ipv4Address)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  u.* ");
            sqlCommand.Append("FROM	mp_UserLocation ul ");

            sqlCommand.Append("JOIN	mp_Users u ");
            sqlCommand.Append("ON ul.UserGuid = u.UserGuid ");

            sqlCommand.Append("WHERE ");
            sqlCommand.Append("(u.SiteGuid = @SiteGuid OR @SiteGuid = '00000000-0000-0000-0000-000000000000') ");
            sqlCommand.Append("AND ul.IPAddress = @IPAddress ");

            sqlCommand.Append("ORDER BY ul.LastCaptureUTC DESC ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[2];

            arParams[0] = new FbParameter("@SiteGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteGuid.ToString();

            arParams[1] = new FbParameter("@IPAddress", FbDbType.VarChar, 50);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = ipv4Address;

            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

        }

        /// <summary>
        /// Gets a count of rows in the mp_UserLocation table.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        public static int GetCountByUser(Guid userGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  Count(*) ");
            sqlCommand.Append("FROM	mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("UserGuid = @UserGuid ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@UserGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userGuid.ToString();

            return Convert.ToInt32(FBSqlHelper.ExecuteScalar(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams));

        }

        /// <summary>
        /// Gets a count of rows in the mp_UserLocation table.
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        public static int GetCountBySite(Guid siteGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  Count(*) ");
            sqlCommand.Append("FROM	mp_UserLocation ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("SiteGuid = @SiteGuid ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@SiteGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteGuid.ToString();

            return Convert.ToInt32(FBSqlHelper.ExecuteScalar(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams));

        }




        /// <summary>
        /// Gets a page of data from the mp_UserLocation table.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IDataReader GetPageByUser(
            Guid userGuid,
            int pageNumber,
            int pageSize,
            out int totalPages)
        {
            int pageLowerBound = (pageSize * pageNumber) - pageSize;
            totalPages = 1;
            int totalRows = GetCountByUser(userGuid);

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
            sqlCommand.Append("SELECT FIRST " + pageSize.ToString() + " ");
            sqlCommand.Append("	SKIP " + pageLowerBound.ToString() + " ");
            sqlCommand.Append("	* ");
            sqlCommand.Append("FROM	mp_UserLocation  ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("UserGuid = @UserGuid ");
            sqlCommand.Append("ORDER BY  ");
            sqlCommand.Append("IPAddressLong  ");
            sqlCommand.Append("	; ");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@UserGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = userGuid.ToString();


            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

        }


        /// <summary>
        /// Gets a page of data from the mp_UserLocation table.
        /// </summary>
        /// <param name="siteGuid"> siteGuid </param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IDataReader GetPageBySite(
            Guid siteGuid,
            int pageNumber,
            int pageSize,
            out int totalPages)
        {
            int pageLowerBound = (pageSize * pageNumber) - pageSize;
            totalPages = 1;
            int totalRows = GetCountBySite(siteGuid);

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
            sqlCommand.Append("SELECT FIRST " + pageSize.ToString() + " ");
            sqlCommand.Append("	SKIP " + pageLowerBound.ToString() + " ");
            sqlCommand.Append("	* ");
            sqlCommand.Append("FROM	mp_UserLocation  ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("SiteGuid = @SiteGuid ");
            sqlCommand.Append("ORDER BY  ");
            sqlCommand.Append("IPAddressLong  ");
            sqlCommand.Append("	; ");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@SiteGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = siteGuid.ToString();


            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

        }



    }
}
