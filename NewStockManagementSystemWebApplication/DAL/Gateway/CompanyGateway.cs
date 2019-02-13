using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace CompanyWebApp.DAL.Gateway
{
    public class CompanyGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public CompanyGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["StockManagementDBConstring"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public int Save(Company company)
        {



            string query = "INSERT INTO Companies VALUES('" + company.CompanyName + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsCompanyExists(string name)
        {

            string query = "SELECT * FROM Companies WHERE CompanyName ='" + name + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();

            return isExists;
        }



        public List<Company> GetAllCompany()
        {
            string query = "SELECT * FROM Companies";
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Company> categoryList = new List<Company>();
            while (reader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.CompanyName = reader["CompanyName"].ToString();

                categoryList.Add(company);

            }
            reader.Close();
            connection.Close();
            return categoryList;
        }

        public Company GetCompanyById(int id)
        {
            string query = "SELECT * FROM Companies WHERE Id=" + id;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Company company = new Company();

            if (reader.HasRows)
            {
                company.Id = Convert.ToInt32(reader["Id"]);
                company.CompanyName = reader["CompanyName"].ToString();
            }
            connection.Close();
            return company;
        }
    }
}