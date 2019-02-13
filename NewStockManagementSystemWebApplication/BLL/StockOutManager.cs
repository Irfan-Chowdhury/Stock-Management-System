using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockOutWebApp
{
    public class StockOutManager
    {
        StockOutGateway stockOutGateway = new StockOutGateway();
        private int available;
        private int quantity;
        private int checkInS = 0;

        public int Check(StockOutDB stockOutDB)
        {
            available = stockOutGateway.GetAvailable(stockOutDB.ItemName, stockOutDB.CompanyId);
            quantity = stockOutDB.StockOutQuantity;
            if (quantity > available)
            {
                return checkInS + 1;
            }
            else
            {
                return 0;
            }

        }
        public int CheckBefore(int quantity, string itemName, int companyId)
        {
            StockOutDB stockOutDB = new StockOutDB();
            available = stockOutGateway.GetAvailable(itemName, companyId);
            int check_CheckBefore = 0;
            if (quantity > available)
            {
                check_CheckBefore = check_CheckBefore + 1;
                return check_CheckBefore;
            }
            else
            {
                return 0;
            }

        }

        public string Save(StockOutDB stockOutDB)
        {
            // stockOutGateway.GetAvailable()
            //available = stockOutGateway.GetAvailable(stockOutDB.Item);
            //quantity = stockOutDB.StockOutQuantity;


            //if (quantity > available)
            //{

            //    return "Insufficient Items in ="+stockOutDB.Item;


            //}
            //else
            //{

            int rowAffect = stockOutGateway.Save(stockOutDB);

            int rowAffect2 = stockOutGateway.ChangeInAvailableInItemSetup(stockOutDB);
            if (rowAffect > 0 && rowAffect2 > 0)
            {
                return "Save Successful";
            }
            else
            {
                return "Save Failed";
            }



        }
        public int GetAvailable(string item, int companyId)
        {
            //available = stockOutGateway.GetAvailable(item);
            return stockOutGateway.GetAvailable(item, companyId);
        }

        public int GetReorderLevel(string item, int companyId)
        {
            return stockOutGateway.GetReorderLevel(item, companyId);
        }


        private int validationValue = 0;

        public string SetValidation(string tempStockOutQuantity, int tempCompanyId, int tempItemId)
        {
            if (String.IsNullOrWhiteSpace(tempStockOutQuantity))
            {
                validationValue = 1;
                return "Stock Out Quantity Value is Empty";
            }
            else if (!tempStockOutQuantity.All(char.IsDigit))
            {
                validationValue = 1;

                return "Not Valid Input";
            }
            else if (Convert.ToInt32(tempStockOutQuantity) < 1)
            {
                validationValue = 1;

                return "Minimum Quantity must be 1";
            }
            else if (tempCompanyId == 0)
            {
                validationValue = 1;

                return "Select a Company From Company Dropdown list";
            }
            else if (tempItemId == 0)
            {
                validationValue = 1;

                return "Select a Item From Item Dropdown list";
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

        //public void ChangeInAvailableInItemSetup(StockOutDB stockOutDB)
        //{
        //    int rowAffect = stockOutGateway.ChangeInAvailableInItemSetup(stockOutDB);

        //    }
    }
  }
