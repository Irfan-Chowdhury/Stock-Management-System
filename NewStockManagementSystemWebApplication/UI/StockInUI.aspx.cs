using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyWebApp.BLL;
using NewStockManagementSystemWebApplication.BLL;
using NewStockManagementSystemWebApplication.DAL.Model;




namespace NewStockManagementSystemWebApplication.UI
{
    public partial class StockIn : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        StockInManager stockInManager = new StockInManager();


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
            
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = companyManager.GetAllCompany();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            itemDropDownList.DataSource = stockInManager.GetAllItemsByCompanyId(companyId);
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("Select", "0"));
           
        }


        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string item = itemDropDownList.SelectedItem.Text;
            int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            availableLabel.Text = stockInManager.GetAvailable(item, companyId).ToString();
            reorderLabel.Text = stockInManager.GetReorderLevel(item, companyId).ToString();

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            DAL.Model.StockIn stockIn = new DAL.Model.StockIn();

            string tempStockInQuantity = stockInTextBox.Text;
            string tempItemName = itemDropDownList.SelectedItem.Text;
            int tempCompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            outputLabel.Text = stockInManager.SetValidation(tempStockInQuantity, tempCompanyId, tempItemName);
            if (stockInManager.PassValidation())
            {

                stockIn.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                stockIn.ItemName = itemDropDownList.SelectedItem.Text;
                stockIn.StockInQuantity = Convert.ToInt32(stockInTextBox.Text);

                outputLabel.Text = stockInManager.Save(stockIn);
                availableLabel.Text = stockInManager.GetAvailable(stockIn.ItemName, stockIn.CompanyId).ToString();
                reorderLabel.Text = stockInManager.GetReorderLevel(stockIn.ItemName, stockIn.CompanyId).ToString();
               
            }
        }

    }
}

