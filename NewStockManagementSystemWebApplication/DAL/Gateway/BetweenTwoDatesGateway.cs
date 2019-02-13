using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using NewStockManagementSystemWebApplication.DAL.Model;

namespace NewStockManagementSystemWebApplication.DAL.Gateway
{
    public class BetweenTwoDatesGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        SqlDataReader reader;

        public BetweenTwoDatesGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["StockManagementDBConstring"].ConnectionString;
            connection = new SqlConnection(conString);
        }

        public List<BetweenTwoDates> GetAllitemsBetweenTwoDates(string fromDate, string toDate)
        {
            string query = "SELECT Companies.CompanyName, ItemSetup.ItemName,  StockOut.Quantity From StockOut INNER JOIN Companies ON StockOut.CompanyId = Companies.Id INNER JOIN ItemSetup ON StockOut.ItemId= ItemSetup.Id WHERE Date BETWEEN '" + fromDate + "' AND '" + toDate + "' AND ItemType='Sell'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<BetweenTwoDates> betweenTwoDatesList = new List<BetweenTwoDates>();

            while (reader.Read())
            {

                // Category category = new Category();
                BetweenTwoDates betweenTwoDates = new BetweenTwoDates();
                betweenTwoDates.CompanyName = reader["CompanyName"].ToString();
                betweenTwoDates.ItemName = reader["ItemName"].ToString();
                betweenTwoDates.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                int check = 0;
                foreach (BetweenTwoDates aBetweenTwoDates in betweenTwoDatesList)
                {
                    if (aBetweenTwoDates.ItemName == betweenTwoDates.ItemName && aBetweenTwoDates.CompanyName == betweenTwoDates.CompanyName)
                    {
                        check = 1;
                        int q = aBetweenTwoDates.Quantity;
                        aBetweenTwoDates.Quantity = q + betweenTwoDates.Quantity;
                        betweenTwoDates.Quantity = aBetweenTwoDates.Quantity;
                    }


                }
                if (check == 0)
                {
                    betweenTwoDatesList.Add(betweenTwoDates);
                }






            }
            reader.Close();
            connection.Close();
            return betweenTwoDatesList;
        }
        //public List<BetweenTwoDates> GetAllitemsBetweenTwoDates(string fromDate, string toDate)
        //{
        //    string query = "SELECT * FROM StockOut WHERE Date BETWEEN '" + fromDate + "' AND '" + toDate + "' AND ItemType='Sell'";
        //    command = new SqlCommand(query, connection);
        //    connection.Open();
        //    reader = command.ExecuteReader();
        //    List<BetweenTwoDates> betweenTwoDatesList = new List<BetweenTwoDates>();

        //    while (reader.Read())
        //    {

        //        Category category = new Category();
        //        BetweenTwoDates betweenTwoDates = new BetweenTwoDates();
        //        betweenTwoDates.Company = reader["Company"].ToString();
        //        betweenTwoDates.Item = reader["Item"].ToString();
        //        betweenTwoDates.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
        //        int check = 0;
        //        foreach (BetweenTwoDates aBetweenTwoDates in betweenTwoDatesList)
        //        {
        //            if (aBetweenTwoDates.Item == betweenTwoDates.Item && aBetweenTwoDates.Company == betweenTwoDates.Company)
        //            {
        //                check = 1;
        //                int q = aBetweenTwoDates.Quantity;
        //                aBetweenTwoDates.Quantity = q + betweenTwoDates.Quantity;
        //                betweenTwoDates.Quantity = aBetweenTwoDates.Quantity;
        //            }


        //        }
        //        if (check == 0)
        //        {
        //            betweenTwoDatesList.Add(betweenTwoDates);
        //        }






        //    }
        //    reader.Close();
        //    connection.Close();
        //    return betweenTwoDatesList;
        //}

    }
}