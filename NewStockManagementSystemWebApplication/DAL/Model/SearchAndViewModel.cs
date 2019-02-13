using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewStockManagementSystemWebApplication.DAL.Model
{
    public class SearchAndViewModel
    {
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public Company Company { get; set; }
        public Category Category { get; set; }
    }
}