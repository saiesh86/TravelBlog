using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mojoPortal.Web.Controls.CustomControls
{
    public partial class LatestStories : System.Web.UI.UserControl
    {
        #region Properties

        public int NumberOfStories
        {
            get;
            set;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {


        }
    }
}