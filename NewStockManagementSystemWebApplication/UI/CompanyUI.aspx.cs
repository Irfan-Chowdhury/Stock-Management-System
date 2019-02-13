using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyWebApp.BLL;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace CompanyWebApp.UI
{
    public partial class CompanyUI : System.Web.UI.Page
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
   
            companyGridView.DataSource = companyManager.GetAllCompany();
            companyGridView.DataBind();

        }

        CompanyManager companyManager = new CompanyManager();

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company aCompany = new Company();
            string tempCompanyName = nameTextBox.Text;
            outputLabel.Text = companyManager.SetValidation(tempCompanyName);
            if (companyManager.PassValidation())
            {

                aCompany.CompanyName = nameTextBox.Text;

                outputLabel.Text = companyManager.Save(aCompany);
            }

        }

        protected void backMenuButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainUI_2.aspx");
        }
    }
}

