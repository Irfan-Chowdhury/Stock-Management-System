using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockOutWebApp
{
    [Serializable]
    public class StockOut
    {
        public int SL { get; set; }
        public int CompanyId { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public string CompanyName { get; set; }
        
        public int StockOutQuantity { get; set; }
        public string ItemType { get; set; }
        
    }
}