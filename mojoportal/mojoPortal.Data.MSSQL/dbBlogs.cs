using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mojoPortal.Data
{
   public class dbBlogs
    {
        /// <summary>
        /// Gets stories from the mp_Blogs table.
        /// </summary>
        /// <param name="rowIndex">total stories.</param>       
        public static DataSet GetStories(
            int numberOfStories)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "u_mp_FeaturedStories", 1);
            sph.DefineSqlParameter("@NumberOfStories", SqlDbType.Int, ParameterDirection.Input, numberOfStories);
            return sph.ExecuteDataset();
        }

        /// <summary>
        /// Gets Latest stories from the mp_Blogs table.
        /// </summary>
        /// <param name="numberOfStories">total stories.</param>       
        public static DataSet GetLatestStories(
            int rowIndex)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionString.GetReadConnectionString(), "u_mp_LatestStories", 1);
            sph.DefineSqlParameter("@RowIndex", SqlDbType.Int, ParameterDirection.Input, rowIndex);
            return sph.ExecuteDataset();
        }
    }
}
