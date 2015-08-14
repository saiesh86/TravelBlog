﻿using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using FirebirdSql.Data.FirebirdClient;
//using log4net;
using mojoPortal.Data;

namespace SurveyFeature.Data
{
    /// <summary>
    /// Author:				Joe Audette
    /// Created:			2008-08-29
    /// Last Modified:		2008-08-29
    /// 
    /// The use and distribution terms for this software are covered by the 
    /// Common Public License 1.0 (http://opensource.org/licenses/cpl.php)
    /// which can be found in the file CPL.TXT at the root of this distribution.
    /// By using this software in any fashion, you are agreeing to be bound by 
    /// the terms of this license.
    ///
    /// You must not remove this notice, or any other, from this software.
    ///  
    /// </summary>
    public static class DBQuestion
    {
        private static String GetConnectionString()
        {
            return ConfigurationManager.AppSettings["FirebirdConnectionString"];

        }

        /// <summary>
        /// Inserts a row in the mp_SurveyQuestions table. Returns rows affected count.
        /// </summary>
        /// <param name="questionGuid"> questionGuid </param>
        /// <param name="pageGuid"> pageGuid </param>
        /// <param name="questionText"> questionText </param>
        /// <param name="questionTypeId"> questionTypeId </param>
        /// <param name="answerIsRequired"> answerIsRequired </param>
        /// <param name="questionOrder"> questionOrder </param>
        /// <param name="validationMessage"> validationMessage </param>
        /// <returns>int</returns>
        public static int Add(
            Guid questionGuid,
            Guid pageGuid,
            string questionText,
            int questionTypeId,
            bool answerIsRequired,
            string validationMessage)
        {
            #region Bit Conversion

            int intAnswerIsRequired;
            if (answerIsRequired)
            {
                intAnswerIsRequired = 1;
            }
            else
            {
                intAnswerIsRequired = 0;
            }


            #endregion

            FbParameter[] arParams = new FbParameter[6];


            arParams[0] = new FbParameter("@QuestionGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = questionGuid.ToString();

            arParams[1] = new FbParameter("@PageGuid", FbDbType.Char, 36);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = pageGuid.ToString();

            arParams[2] = new FbParameter("@QuestionText", FbDbType.VarChar);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = questionText;

            arParams[3] = new FbParameter("@QuestionTypeId", FbDbType.Integer);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = questionTypeId;

            arParams[4] = new FbParameter("@AnswerIsRequired", FbDbType.SmallInt);
            arParams[4].Direction = ParameterDirection.Input;
            arParams[4].Value = intAnswerIsRequired;

            arParams[5] = new FbParameter("@ValidationMessage", FbDbType.VarChar, 256);
            arParams[5].Direction = ParameterDirection.Input;
            arParams[5].Value = validationMessage;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("INSERT INTO mp_SurveyQuestions (");
            sqlCommand.Append("QuestionGuid, ");
            sqlCommand.Append("PageGuid, ");
            sqlCommand.Append("QuestionText, ");
            sqlCommand.Append("QuestionTypeId, ");
            sqlCommand.Append("AnswerIsRequired, ");
            sqlCommand.Append("QuestionOrder, ");
            sqlCommand.Append("ValidationMessage )");

            sqlCommand.Append("SELECT @QuestionGuid, @PageGuid, @QuestionText, ");
            sqlCommand.Append("@QuestionTypeId, @AnswerIsRequired, Count(*), @ValidationMessage ");
            sqlCommand.Append("FROM mp_SurveyPages; ");

            int rowsAffected = FBSqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

            return rowsAffected;


        }

        /// <summary>
        /// Updates a row in the mp_SurveyQuestions table. Returns true if row updated.
        /// </summary>
        /// <param name="questionGuid"> questionGuid </param>
        /// <param name="pageGuid"> pageGuid </param>
        /// <param name="questionText"> questionText </param>
        /// <param name="questionTypeId"> questionTypeId </param>
        /// <param name="answerIsRequired"> answerIsRequired </param>
        /// <param name="questionOrder"> questionOrder </param>
        /// <param name="validationMessage"> validationMessage </param>
        /// <returns>bool</returns>
        public static bool Update(
            Guid questionGuid,
            Guid pageGuid,
            string questionText,
            int questionTypeId,
            bool answerIsRequired,
            int questionOrder,
            string validationMessage)
        {
            #region Bit Conversion

            int intAnswerIsRequired;
            if (answerIsRequired)
            {
                intAnswerIsRequired = 1;
            }
            else
            {
                intAnswerIsRequired = 0;
            }


            #endregion

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("UPDATE mp_SurveyQuestions ");
            sqlCommand.Append("SET  ");
            sqlCommand.Append("PageGuid = @PageGuid, ");
            sqlCommand.Append("QuestionText = @QuestionText, ");
            sqlCommand.Append("QuestionTypeId = @QuestionTypeId, ");
            sqlCommand.Append("AnswerIsRequired = @AnswerIsRequired, ");
            sqlCommand.Append("QuestionOrder = @QuestionOrder, ");
            sqlCommand.Append("ValidationMessage = @ValidationMessage ");

            sqlCommand.Append("WHERE  ");
            sqlCommand.Append("QuestionGuid = @QuestionGuid ");
            sqlCommand.Append(";");
            FbParameter[] arParams = new FbParameter[7];

            arParams[0] = new FbParameter("@QuestionGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = questionGuid.ToString();

            arParams[1] = new FbParameter("@PageGuid", FbDbType.Char, 36);
            arParams[1].Direction = ParameterDirection.Input;
            arParams[1].Value = pageGuid.ToString();

            arParams[2] = new FbParameter("@QuestionText", FbDbType.VarChar);
            arParams[2].Direction = ParameterDirection.Input;
            arParams[2].Value = questionText;

            arParams[3] = new FbParameter("@QuestionTypeId", FbDbType.Integer);
            arParams[3].Direction = ParameterDirection.Input;
            arParams[3].Value = questionTypeId;

            arParams[4] = new FbParameter("@AnswerIsRequired", FbDbType.SmallInt);
            arParams[4].Direction = ParameterDirection.Input;
            arParams[4].Value = intAnswerIsRequired;

            arParams[5] = new FbParameter("@QuestionOrder", FbDbType.Integer);
            arParams[5].Direction = ParameterDirection.Input;
            arParams[5].Value = questionOrder;

            arParams[6] = new FbParameter("@ValidationMessage", FbDbType.VarChar, 256);
            arParams[6].Direction = ParameterDirection.Input;
            arParams[6].Value = validationMessage;


            int rowsAffected = FBSqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);


        }

        /// <summary>
        /// Deletes a row from the mp_SurveyQuestions table. Returns true if row deleted.
        /// </summary>
        /// <param name="questionGuid"> questionGuid </param>
        /// <returns>bool</returns>
        public static bool Delete(
            Guid questionGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("DELETE FROM mp_SurveyQuestions ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("QuestionGuid = @QuestionGuid ");
            sqlCommand.Append(";");
            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@QuestionGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = questionGuid.ToString();


            int rowsAffected = FBSqlHelper.ExecuteNonQuery(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);

            return (rowsAffected > -1);

        }

        /// <summary>
        /// Gets an IDataReader with one row from the mp_SurveyQuestions table.
        /// </summary>
        /// <param name="questionGuid"> questionGuid </param>
        public static IDataReader GetOne(
            Guid questionGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_SurveyQuestions ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("QuestionGuid = @QuestionGuid ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@QuestionGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = questionGuid.ToString();

            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);


        }

        /// <summary>
        /// Gets an IDataReader with all rows in the mp_SurveyQuestions table.
        /// </summary>
        public static IDataReader GetAllByPage(Guid pageGuid)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT  * ");
            sqlCommand.Append("FROM	mp_SurveyQuestions ");
            sqlCommand.Append("WHERE ");
            sqlCommand.Append("PageGuid = @PageGuid ");
            sqlCommand.Append("ORDER BY QuestionOrder ");
            sqlCommand.Append(";");

            FbParameter[] arParams = new FbParameter[1];

            arParams[0] = new FbParameter("@PageGuid", FbDbType.Char, 36);
            arParams[0].Direction = ParameterDirection.Input;
            arParams[0].Value = pageGuid.ToString();

            return FBSqlHelper.ExecuteReader(
                GetConnectionString(),
                sqlCommand.ToString(),
                arParams);


        }


    }
}
