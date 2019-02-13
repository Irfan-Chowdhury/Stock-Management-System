using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatagoryWebApp.BLL;
using CompanyWebApp.BLL;
using NewStockManagementSystemWebApplication.DAL.Gateway;
using NewStockManagementSystemWebApplication.DAL.Model;
using NewStockManagementSystemWebApplication.DAL.Model.View_Model;

namespace NewStockManagementSystemWebApplication.BLL
{
    public class SearchAndViewManager
    {
        private SearchANDViewGateway searchAndViewGateway = new SearchANDViewGateway();
        public CompanyManager CompanyManager = new CompanyManager();
        public CategoryManager CategoryManager = new CategoryManager();
        public List<Item> GetItemsByCompany(int companyId)
        {
            return searchAndViewGateway.GetItemsByCompany(companyId);
        }

        public List<Item> GetItemsByCategory(int categoryId)
        {
            return searchAndViewGateway.GetItemsByCategory(categoryId);
        }

        public List<Item> GetItemsByCompanyCategory(int companyId, int categoryId)
        {
            return searchAndViewGateway.GetItemsByCompanyCategory(companyId, categoryId);
        }


        public List<Company> GetAllCompanies()
        {
            return CompanyManager.GetAllCompany();
        }

        public List<Category> GetAllCategories()
        {
            return CategoryManager.GetAllCategory();
        }

        public Company GetCompanyById(int id)
        {
            return CompanyManager.GetCompanyById(id);
        }

        public Category GetCategoryById(int id)
        {
            return CategoryManager.GetCategoryById(id);
        }

        public List<ShowAllItemsView> GetAllItems()
        {
            return searchAndViewGateway.GetAllItems();
        }
    }
}