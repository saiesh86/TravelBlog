using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace mojoPortal.Web.Controls
{
    public partial class SMT_MyStories : mojoPortal.Web.SiteModuleControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = System.Configuration.ConfigurationManager.AppSettings["MSSQLConnectionString"];
            SqlConnection conn = new SqlConnection(connection);
        }

        protected void FetchStoriesList(string emailId, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(Utilities.myStoriesCmd, conn);
            conn.Open();
            cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }
    }
}