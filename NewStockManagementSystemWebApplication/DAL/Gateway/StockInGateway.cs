using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using NewStockManagementSystemWebApplication.DAL.Model;
using NewStockManagementSystemWebApplication.UI;
using StockIn = NewStockManagementSystemWebApplication.DAL.Model.StockIn;

namespace NewStockManagementSystemWebApplication.DAL.Gateway
{
    public class StockInGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        private int availble;


        public StockInGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["StockManagementDBConstring"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public List<Item> GetAllItemsByCompanyId(int companyId)
        {

            string query = "SELECT * FROM ItemSetup WHERE CompanyId ='" + companyId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Item> itemList = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();

                itemList.Add(item);

            }
            reader.Close();
            connection.Close();
            return itemList;
        }


        public int Save(StockIn stockIn)
        {

            availble = GetAvailable(stockIn.ItemName, stockIn.CompanyId);
            string query = "UPDATE ItemSetup SET AvailableQuantity ='" + (availble + stockIn.StockInQuantity) + "' WHERE ItemName= '" + stockIn.ItemName + "' AND CompanyId= '" + stockIn.CompanyId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public int GetAvailable(string itemName, int companyId)
        {
            string query = "SELECT AvailableQuantity FROM ItemSetup WHERE ItemName= '" + itemName + "' AND CompanyId ='" + companyId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            StockIn stockIn = new StockIn();
            reader.Read();
            if (reader.HasRows)
            {
                stockIn = new StockIn();

                stockIn.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                availble = stockIn.AvailableQuantity;

            }
            reader.Close();
            connection.Close();
            return stockIn.AvailableQuantity; ;
        }

        public int GetReorderLevel(string item, int companyId)
        {
            string query = "SELECT ReorderLevel FROM ItemSetup WHERE ItemName= '" + item + "' AND CompanyId ='" + companyId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            StockIn stockIn = new StockIn();
            reader.Read();
            if (reader.HasRows)
            {
                stockIn = new StockIn();

                stockIn.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);


            }
            reader.Close();
            connection.Close();
            return stockIn.ReorderLevel; ;
        }
    }
}
