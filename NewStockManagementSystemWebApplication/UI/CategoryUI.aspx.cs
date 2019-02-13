using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CatagoryWebApp.BLL;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace CatagoryWebApp.UI
{
    public partial class CategoryUI : System.Web.UI.Page
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
           
            categoryGridView.DataSource = categoryManager.GetAllCategory();
            categoryGridView.DataBind();
            string U = Request.QueryString["U"];
            outputLabel.Text = U;

        }

        CategoryManager categoryManager = new CategoryManager();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Category aCatagory = new Category();
            string tempCategoryName = categoryNameTextBox.Text;
            outputLabel.Text = categoryManager.SetValidation(tempCategoryName);
            if (categoryManager.PassValidation())
            {
                aCatagory.CategoryName = categoryNameTextBox.Text;

                outputLabel.Text = categoryManager.Save(aCatagory);
            }
        }

        protected void updateLinkButton_OnClick(object sender, EventArgs e)
        {

            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField slhiddenField = (HiddenField)row.FindControl("idHiddenField");
            //Response.Write(idhiddenField.Value);
            int sl = Convert.ToInt32(slhiddenField.Value);
            Response.Redirect("UpdateCategoryUI.aspx?Id=" + sl);

        }
    }
}

