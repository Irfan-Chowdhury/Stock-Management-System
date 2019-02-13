using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockOutWebApp
{
    public class StockOutGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        private int availble;
        private int quantity;


        public StockOutGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["StockManagementDBConstring"].ConnectionString;
            connection = new SqlConnection(conString);
        }
        public int Save(StockOutDB stockOutDB)
        {
            quantity = stockOutDB.StockOutQuantity;

            string query = "INSERT INTO StockOut (CompanyId,ItemId,Quantity,ItemType) VALUES('" + stockOutDB.CompanyId + "','" + stockOutDB.ItemId + "'," + stockOutDB.StockOutQuantity + ",'" + stockOutDB.ItemType + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public int GetAvailable(string item, int companyId)
        {
            string query = "SELECT AvailableQuantity FROM ItemSetup WHERE ItemName= '" + item + "' AND CompanyId= '" + companyId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            StockOutDB stockOutDB = new StockOutDB();
            reader.Read();
            if (reader.HasRows)
            {
                stockOutDB = new StockOutDB();

                stockOutDB.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                availble = stockOutDB.AvailableQuantity;

            }
            reader.Close();
            connection.Close();
            return stockOutDB.AvailableQuantity; ;
        }

        public int GetReorderLevel(string item, int companyId)
        {
            string query = "SELECT ReorderLevel FROM ItemSetup WHERE ItemName= '" + item + "' AND CompanyId='" + companyId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            StockOutDB stockOutDB = new StockOutDB();

            reader.Read();
            if (reader.HasRows)
            {
                stockOutDB = new StockOutDB();

                stockOutDB.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);


            }
            reader.Close();
            connection.Close();
            return stockOutDB.ReorderLevel; ;
        }
        public int ChangeInAvailableInItemSetup(StockOutDB stockOutDB)
        {

            availble = availble - quantity;

            string query = "UPDATE ItemSetup SET AvailableQuantity='" + availble + "' WHERE ItemName= '" + stockOutDB.ItemName + "' AND CompanyId= '" + stockOutDB.CompanyId + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}