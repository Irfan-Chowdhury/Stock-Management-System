using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewStockManagementSystemWebApplication.DAL.Gateway;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace BetweenTwoDatesWebApp
{
    public class BetweenTwoDatesManager
    {
        BetweenTwoDatesGateway betweenTwoDatesGateway = new BetweenTwoDatesGateway();
        private int validationValue;
        public string SetValidation(string fromDate, string toDate)
        {
            if (String.IsNullOrEmpty(fromDate) && String.IsNullOrEmpty(toDate))
            {
                validationValue = 1;
                return "Please Select From Date & To Date";
            }
            else if (String.IsNullOrEmpty(fromDate))
            {
                validationValue = 1;

                return "Please Select From Date";
            }
            else if (String.IsNullOrEmpty(toDate))
            {
                validationValue = 1;

                return "Please Select To Date";
            }
            else
            {
                validationValue = 0;
                if (DateTime.Parse(toDate) <= DateTime.Parse(fromDate))
                {

                    string temp = fromDate;
                    fromDate = toDate;
                    toDate = temp;

                }
                return "These items are sold Between " + fromDate + " to " + toDate;
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
        public List<BetweenTwoDates> GetAllitemsBetweenTwoDates(string fromDate, string toDate)
        {
            if (DateTime.Parse(toDate) <= DateTime.Parse(fromDate))
            {

                string temp = fromDate;
                fromDate = toDate;
                toDate = temp;

            }
            return betweenTwoDatesGateway.GetAllitemsBetweenTwoDates(fromDate, toDate);
        }
    }
}