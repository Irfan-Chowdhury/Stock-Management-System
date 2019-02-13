using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using NewStockManagementSystemWebApplication.DAL.Model;
using NewStockManagementSystemWebApplication.DAL.Model.View_Model;

namespace NewStockManagementSystemWebApplication.DAL.Gateway
{
    public class ItemSetupGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public ItemSetupGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["StockManagementDBConstring"].ConnectionString;
            connection = new SqlConnection(conString);
        }
        public int Save(Item item)
        {

            string query = "INSERT INTO ItemSetup VALUES('" + item.CategoryId + "','" + item.CompanyId + "','" + item.ItemName + "'," + item.ReorderLevel + ",'" + item.AvailableItem + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsItemExists(Item item)
        {

            string query = "SELECT * FROM ItemSetup WHERE ItemName ='" + item.ItemName + "' AND CompanyId = '" + item.CompanyId + "' AND CategoryId = '" + item.CategoryId + "' ";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();

            return isExists;

        }


    }
}