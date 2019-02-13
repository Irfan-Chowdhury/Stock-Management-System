using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewStockManagementSystemWebApplication.DAL.Gateway;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace NewStockManagementSystemWebApplication.BLL
{
    public class StockInManager
    {
        StockInGateway stockInGateway = new StockInGateway();
        public List<Item> GetAllItemsByCompanyId(int comapanyId)
        {
            return stockInGateway.GetAllItemsByCompanyId(comapanyId);
        }


        public string Save(StockIn stockIn)
        {

            int rowAffect = stockInGateway.Save(stockIn);
            if (rowAffect > 0)
            {
                return "Save Successful";
            }
            else
            {
                return "Save Failed. Please Check Your Input";
            }
        }

        public int GetAvailable(string item, int companyId)
        {
            return stockInGateway.GetAvailable(item, companyId);
        }

        public int GetReorderLevel(string item, int companyId)
        {
            return stockInGateway.GetReorderLevel(item, companyId);
        }


        private int validationValue = 0;
        public string SetValidation(string tempStockInQuantity, int tempCompanyId, string tempItemName)
        {
            if (tempCompanyId <= 0)
            {
                validationValue = 1;
                return "Please Select a Company";
            }
            else if (tempItemName == "Select")
            {
                validationValue = 1;

                return "Please Select a Item";
            }
            else if (String.IsNullOrWhiteSpace(tempStockInQuantity))
            {
                validationValue = 1;

                return "Stock In Quantity Value is Empty";
            }

            else if (!tempStockInQuantity.All(char.IsDigit))
            {
                validationValue = 1;

                return "Not Valid Input";
            }
            else if (Convert.ToInt32(tempStockInQuantity) < 1)
            {
                validationValue = 1;

                return "Minimum Quantity must be 1";
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