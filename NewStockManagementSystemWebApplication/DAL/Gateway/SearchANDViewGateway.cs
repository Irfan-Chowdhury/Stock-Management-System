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
    public class SearchANDViewGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SearchANDViewGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["StockManagementDBConstring"].ConnectionString;
            connection = new SqlConnection(conString);
        }
        //eikhan thke search and view er jonno kaj shuru baki kaj search and view ui te ase bujbi

        public List<Item> GetItemsByCompany(int companyId)
        {
            string query = "SELECT * FROM ItemSetup WHERE CompanyId = " + companyId;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                item.AvailableItem = Convert.ToInt32(reader["AvailableQuantity"]);
                item.ReorderLevel = Convert.ToInt32(reader["Reorderlevel"]);
                items.Add(item);
            }
            connection.Close();

            return items;
        }

        public List<Item> GetItemsByCategory(int categoryId)
        {
            string query = "SELECT * FROM ItemSetup WHERE CategoryId = " + categoryId;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                item.AvailableItem = Convert.ToInt32(reader["AvailableQuantity"]);
                item.ReorderLevel = Convert.ToInt32(reader["Reorderlevel"]);
                items.Add(item);
            }
            connection.Close();

            return items;
        }


        public List<Item> GetItemsByCompanyCategory(int companyId, int categoryId)
        {
            string query = "SELECT * FROM ItemSetup WHERE CompanyId = '" + companyId + "' AND CategoryId = " + categoryId;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                item.AvailableItem = Convert.ToInt32(reader["AvailableQuantity"]);
                item.ReorderLevel = Convert.ToInt32(reader["Reorderlevel"]);
                items.Add(item);
            }
            connection.Close();

            return items;
        }

        public Item GetItemById(int id)
        {
            string query = "SELECT * FROM ItemSetup WHERE Id = " + id;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Item item = new Item();
            if (reader.HasRows)
            {
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                item.AvailableItem = Convert.ToInt32(reader["AvailableQuantity"]);

            }
            connection.Close();

            return item;
        }

        //Shudhu nicher  ei function e view model er kaj ase view model r onno gulate use kori nai

        public List<ShowAllItemsView> GetAllItems()
        {
            string query = "Select * from ShowAllItemsView";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<ShowAllItemsView> Itemlist = new List<ShowAllItemsView>();

            while (reader.Read())
            {
                ShowAllItemsView Item1 = new ShowAllItemsView();
                Item1.ItemId = Convert.ToInt32(reader["ItemId"]);
                Item1.ItemName = reader["ItemName"].ToString();
                Item1.CompanyName = reader["CompanyName"].ToString();
                Item1.Quantity = Convert.ToInt32(reader["AvailableQuantity"]);
                Item1.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                Itemlist.Add(Item1);
            }


            connection.Close();
            return Itemlist;
        }
    }
}