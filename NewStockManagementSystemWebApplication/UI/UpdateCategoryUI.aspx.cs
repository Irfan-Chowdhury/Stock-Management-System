using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatagoryWebApp.BLL;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace CatagoryWebApp.UI
{
    public partial class UpdateCategoryUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();

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
            if (IsPostBack == false)
            {
                int sl = Convert.ToInt32(Request.QueryString["Id"]);
                Category category = categoryManager.GetCategoryBySL(sl);
                if (category != null)
                {
                    LoadFormWithStudent(category);
                }
            }

        }

        private void LoadFormWithStudent(Category category)
        {
            slHiddenField.Value = category.Id.ToString();

            categoryNameTextBox.Text = category.CategoryName;

        }



        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(slHiddenField.Value);
            string tempCategoryName = categoryNameTextBox.Text;
            outputLabel.Text = categoryManager.SetValidation(tempCategoryName);
            if (categoryManager.PassValidation())
            {
                category.CategoryName = categoryNameTextBox.Text;

                //outputLabel.Text = categoryManager.UpdateBySL(category);
                string UpdateNoti = categoryManager.UpdateBySL(category);
                Response.Redirect("CategoryUI.aspx?U=" + UpdateNoti);
            }

        }
    }
}

