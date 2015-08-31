using mojoPortal.Business.CustomFeatures;
using mojoPortal.Business.WebHelpers.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mojoPortal.Web.Controls.CustomControls
{
    public partial class U_LatestStories : System.Web.UI.UserControl
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
                GetData();
                //DataListStories.DataSource = Blogs.GetStories(NumberOfStories);
                //DataListStories.DataBind();
            }
        }
        protected void DataListStories_DataBinding(object sender, EventArgs e)
        {


        }

        private void GetData()
        {
            GridViewStories.DataSource = new string[] { "", "", "" };
            GridViewStories.DataBind();
        }

        protected void GridViewStories_DataBound(object sender, EventArgs e)
        {
            var gridViewStories = (GridView)sender;
            var rowCollection = gridViewStories.Rows;

            for(int rowIndex=0; rowIndex<gridViewStories.Rows.Count; rowIndex++)
            {
                var dataListRow = (DataList) gridViewStories.Rows[rowIndex].FindControl("DataListRowStories");
                dataListRow.DataSource = Blogs.GetLatestStories(rowIndex);
                dataListRow.DataBind();
            }
            //ExtensionGridView.RemoveEmptyColumns(gridViewStories);
        }

        protected void GridViewStories_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}