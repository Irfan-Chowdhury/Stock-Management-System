using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewStockManagementSystemWebApplication.DAL.Gateway;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace NewStockManagementSystemWebApplication.BLL
{
    public class ItemSetupManager
    {
        private ItemSetupGateway itemSetupGateway = new ItemSetupGateway();



        public string Save(Item item)
        {
            if (itemSetupGateway.IsItemExists(item))
            {
                return "Item already Exists";
            }
            else
            {
                int rowAffect = itemSetupGateway.Save(item);
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

        private int validationValue = 0;

        public string SetValidation(string tempItemName, int tempCategoryId, int tempCompanyId, string tempReorderLevel)
        {
            if (String.IsNullOrWhiteSpace(tempItemName))
            {
                validationValue = 1;
                return "Item Name is Empty or Only WhiteSpace";
            }

            else if (tempItemName.Count(char.IsLetter) < 2)
            {
                validationValue = 1;

                return "Minimum 2 alphabet need for Valid Item name";
            }
            else if (tempCategoryId <= 0 && tempCompanyId <= 0)
            {
                validationValue = 1;

                return "Select Category & Company from dropdown List";
            }
            else if (tempCategoryId <= 0)
            {
                validationValue = 1;
                return "Select a Category";
            }
            else if (tempCompanyId <= 0)
            {
                validationValue = 1;
                return "Select a Company";
            }
            else if (String.IsNullOrWhiteSpace(tempReorderLevel))
            {
                validationValue = 1;
                return "Reorder Level is Empty";
            }
            else if (!tempReorderLevel.All(char.IsDigit))
            {
                validationValue = 1;
                return "Reorder Level must be Positive Numeric Value or 0";
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