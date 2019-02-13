using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewStockManagementSystemWebApplication.DAL.Model
{
    public class StockIn 
    {
        public int CompanyId { get; set; }
        public int Id { get; set; }
        public int  AvailableQuantity { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int StockInQuantity { get; set; }
    }
}