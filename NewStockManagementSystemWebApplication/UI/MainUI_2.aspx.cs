using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewStockManagementSystemWebApplication.UI
{
    public partial class MainUI_21 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();
            
            if (Session["id"] == null)
            {
                Response.Redirect("UserLoginUI.aspx?logout=true");
            }
           
        }
       
        
    }
}