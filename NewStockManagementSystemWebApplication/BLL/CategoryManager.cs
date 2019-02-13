using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatagoryWebApp.DAL.Gateway;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace CatagoryWebApp.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();

        public string Save(Category category)
        {
            if (categoryGateway.IsCategoryExists(category.CategoryName))
            {
                return "Category already Exists";
            }
            else
            {
                int rowAffect = categoryGateway.Save(category);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }

        }
        public List<Category> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }

        public Category GetCategoryBySL(int sl)
        {
            return categoryGateway.GetCategoryBySL(sl);
        }

        public Category GetCategoryById(int id)
        {
            return categoryGateway.GetCategoryById(id);
        }

        public string UpdateBySL(Category category)
        {
            if (categoryGateway.IsCategoryExists(category.CategoryName))
            {
                return "Category already Exists";
            }
            else
            {
                int rowAffect = categoryGateway.UpdateBySL(category);
                if (rowAffect > 0)
                {
                    return "Update Successful";
                }
                else
                {
                    return "Update Failed";
                }
            }
        }

        private int validationValue = 0;
        public string SetValidation(string tempCategoryName)
        {
            if (String.IsNullOrWhiteSpace(tempCategoryName))
            {
                validationValue = 1;
                return "Category Name is Empty or Only WhiteSpace";
            }

            else if (tempCategoryName.Count(char.IsLetter) < 2)
            {
                validationValue = 1;

                return "Minimum 2 alphabet need for Valid Category name";
            }

            else
            {
                validationValue = 0;
                return "";
            }

        }

        public bool PassValidation()
        {
            if (validationValue == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}