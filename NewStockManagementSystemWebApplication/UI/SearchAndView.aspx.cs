using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewStockManagementSystemWebApplication.BLL;
using NewStockManagementSystemWebApplication.DAL.Model;
using NewStockManagementSystemWebApplication.DAL.Model.View_Model;

namespace NewStockManagementSystemWebApplication.UI
{
    public partial class SearchAndView : System.Web.UI.Page
    {
        public SearchAndViewManager SearchAndViewManager = new SearchAndViewManager();
        public List<Item> Items = new List<Item>();
        public List<ItemViewModel> ItemViewModels = new List<ItemViewModel>();
        public SearchAndViewModel SearchAndViewModel = new SearchAndViewModel(); 

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
                CategoryDropDownList.DataSource = SearchAndViewManager.GetAllCategories();
                CategoryDropDownList.DataTextField = "CategoryName";
                CategoryDropDownList.DataValueField = "Id";
                CategoryDropDownList.DataBind();
                CategoryDropDownList.Items.Insert(0, new ListItem("Select Category", ""));

                CompanyDropDownList.DataSource = SearchAndViewManager.GetAllCompanies();
                CompanyDropDownList.DataTextField = "CompanyName";
                CompanyDropDownList.DataValueField = "Id";
                CompanyDropDownList.DataBind();
                CompanyDropDownList.Items.Insert(0, new ListItem("Select Company", ""));
            }
        }

        protected void searchButton_OnClick(object sender, EventArgs e)
        {
            if (CompanyDropDownList.SelectedValue == "" && CategoryDropDownList.SelectedValue == "")
            {
                itemsGridView.DataSource = SearchAndViewManager.GetAllItems();
                itemsGridView.DataBind();
                if (itemsGridView.Rows.Count == 0)
                {
                    outputLabel.Text = "No Items Found by Your Search Options";
                }
                
            }
            else if (CategoryDropDownList.SelectedValue == "")
            {
                SearchAndViewModel.CompanyId = Convert.ToInt32(CompanyDropDownList.SelectedValue);

                Items = SearchAndViewManager.GetItemsByCompany(SearchAndViewModel.CompanyId);
                GetItems();

            }
            else if (CompanyDropDownList.SelectedValue == "")
            {
                SearchAndViewModel.CategoryId = Convert.ToInt32(CategoryDropDownList.SelectedValue);

                Items = SearchAndViewManager.GetItemsByCategory(SearchAndViewModel.CategoryId);
                GetItems();

              
            }
            else
            {
                SearchAndViewModel.CompanyId = Convert.ToInt32(CompanyDropDownList.SelectedValue);
                SearchAndViewModel.CategoryId = Convert.ToInt32(CategoryDropDownList.SelectedValue);

                Items = SearchAndViewManager.GetItemsByCompanyCategory(SearchAndViewModel.CompanyId, SearchAndViewModel.CategoryId);
                GetItems();

                outputLabel.Text = String.Empty;
            }
            if (itemsGridView.Rows.Count == 0)
            {
                outputLabel.Text = "No Items Found by Your Search Options";
            }
        }

        private void GetItems()
        {
            foreach (Item item in Items)
            {
                SearchAndViewModel.Company = SearchAndViewManager.GetCompanyById(item.CompanyId);
                SearchAndViewModel.Category = SearchAndViewManager.GetCategoryById(item.CategoryId);
                

                ItemViewModel itemViewModel = new ItemViewModel();
                itemViewModel.Id = ItemViewModels.Count + 1;
                itemViewModel.ItemName = item.ItemName;
                itemViewModel.CompanyName = SearchAndViewModel.Company.CompanyName;
                itemViewModel.CategoryName = SearchAndViewModel.Category.CategoryName;
                itemViewModel.Quantity = item.AvailableItem;
                itemViewModel.ReorderLevel = item.ReorderLevel;

                ItemViewModels.Add(itemViewModel);
            }

            itemsGridView.DataSource = ItemViewModels;
            itemsGridView.DataBind();
            if (itemsGridView.Rows.Count == 0)
            {
                outputLabel.Text = "No Items Found by Your Search Options";
            }
        }
    }
}