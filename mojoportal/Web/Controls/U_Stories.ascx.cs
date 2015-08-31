using mojoPortal.Business.CustomFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mojoPortal.Web.Controls.CustomControls
{
    public partial class U_Stories : System.Web.UI.UserControl
    {
        #region Properties

        public int NumberOfStories
        {
            get;
            set;
        }

        public string Header
        {            
            set
            {
                LabelContentHeader.Text = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataListStories.DataSource = Blogs.GetStories(NumberOfStories);
                DataListStories.DataBind();
            }
        }
    }
}