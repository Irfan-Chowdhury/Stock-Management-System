using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatagoryWebApp.BLL;
using CompanyWebApp.BLL;
using NewStockManagementSystemWebApplication.BLL;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace NewStockManagementSystemWebApplication.UI
{
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        CompanyManager companyManager = new CompanyManager();
        ItemSetupManager itemSetupManager = new ItemSetupManager();
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
            //else
            //{
            //    Response.Write(Session["id"]);
            //}
            if (!IsPostBack)
            {
                categoryDropDownList.DataSource = categoryManager.GetAllCategory();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Insert(0, new ListItem("Select Category", "0"));

                companyDropDownList.DataSource = companyManager.GetAllCompany();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));
            }
        }

        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            Item item = new Item();
            string tempItemName = itemNameTextBox.Text;
            int tempCategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            int tempCompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            string tempReorderLevel = reorderLevelTextBox.Text;
            outputLabel.Text = itemSetupManager.SetValidation(tempItemName, tempCategoryId, tempCompanyId, tempReorderLevel);
            if (itemSetupManager.PassValidation())
            {
                item.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);


                item.ItemName = itemNameTextBox.Text;
                item.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                item.AvailableItem = 0;
               

                outputLabel.Text = itemSetupManager.Save(item);
            }
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}
