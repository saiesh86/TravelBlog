using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace mojoPortal.Business.WebHelpers.ExtensionMethods
{
    public static class ExtensionGridView
    {
        public static void RemoveEmptyColumns(this GridView grdView)
        {
                bool notAvailable = true;

                foreach (GridViewRow row in grdView.Rows)
                {
                    for(int cellIndex=0; cellIndex <row.Cells.Count; cellIndex++)
                    {
                        if(!string.IsNullOrEmpty(row.Cells[cellIndex].Text))
                        {
                            notAvailable = false;
                            grdView.Columns[cellIndex].Visible = notAvailable;
                            break;
                        }
                    }                  
                }                
            }            
        }
    }

