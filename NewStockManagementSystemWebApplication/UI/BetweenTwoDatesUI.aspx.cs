using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BetweenTwoDatesWebApp
{
    public partial class BetweenTwoDatesUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();

            if (Session["id"] == null)
            {
                Response.Redirect("UserLoginUI.aspx?logout=true");
            }
            

        }
        BetweenTwoDatesManager betweenTwoDatesManager = new BetweenTwoDatesManager();


        protected void searchButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = null;
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;
            outputLabel.Text = betweenTwoDatesManager.SetValidation(fromDate, toDate);
            if (betweenTwoDatesManager.PassValidation())
            {
                itemBetweenDateGridView.DataSource = betweenTwoDatesManager.GetAllitemsBetweenTwoDates(fromDate, toDate);
                itemBetweenDateGridView.DataBind();
                if (itemBetweenDateGridView.Rows.Count == 0)
                {
                    outputLabel.Text = "Nothing sold between these Dates";
                }

            }

        }


      
    }
}