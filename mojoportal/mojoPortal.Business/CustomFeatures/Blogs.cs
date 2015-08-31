using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mojoPortal.Data;

namespace mojoPortal.Business.CustomFeatures
{
    public class Blogs
    {
        /// <summary>
        /// Gets stories from the mp_Blogs table.
        /// </summary>
        /// <param name="numberOfStories">total stories.</param>       
        public static DataSet GetStories(
            int numberOfStories)
        {
            return dbBlogs.GetStories(numberOfStories);
        }

        /// <summary>
        /// Gets Latest stories from the mp_Blogs table.
        /// </summary>
        /// <param name="numberOfStories">total stories.</param>       
        public static DataSet GetLatestStories(
            int rowIndex)
        {
            return dbBlogs.GetLatestStories(rowIndex);
        }
    }
}
