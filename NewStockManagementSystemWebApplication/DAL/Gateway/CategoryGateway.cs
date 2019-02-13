using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace CatagoryWebApp.DAL.Gateway
{
    public class CategoryGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public CategoryGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["StockManagementDBConstring"].ConnectionString;
            connection = new SqlConnection(conString);
        }
        public int Save(Category category)
        {

            string query = "INSERT INTO Categories VALUES('" + category.CategoryName + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsCategoryExists(string name)
        {

            string query = "SELECT * FROM Categories WHERE CategoryName ='" + name + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();

            return isExists;

        }
        public List<Category> GetAllCategory()
        {
            string query = "SELECT * FROM Categories";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Category> categoryList = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();

                categoryList.Add(category);

            }
            reader.Close();
            connection.Close();
            return categoryList;
        }

        public Category GetCategoryBySL(int sl)
        {
            string query = "SELECT * FROM Categories WHERE Id=" + sl;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            Category category = null;
            reader.Read();
            if (reader.HasRows)
            {
                category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();

            }

            reader.Close();
            connection.Close();
            return category;
        }

        public Category GetCategoryById(int id)
        {
            string query = "SELECT * FROM Categories WHERE Id=" + id;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Category category = new Category();

            if (reader.HasRows)
            {
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();
            }
            connection.Close();
            return category;
        }

        public int UpdateBySL(Category category)
        {
            string query = "UPDATE Categories SET CategoryName='" + category.CategoryName + "' WHERE Id=" + category.Id;
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}