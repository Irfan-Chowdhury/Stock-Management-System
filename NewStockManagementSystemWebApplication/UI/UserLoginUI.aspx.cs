using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewStockManagementSystemWebApplication.UI
{
    public partial class UserLoginUI : System.Web.UI.Page
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.QueryString["logout"] == "true")
                {
                    outputLabel.Text = "Please login first to contine";
                }

            }
            
            Response.CacheControl = "no-cache";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();
           
        }

        protected void loginButton_OnClick(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(@"Data Source=IRFAN-PC;Initial Catalog=StockDB_BugBites;Integrated Security=True");
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=StockDB_BugBites;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT UserName,Password FROM UserLogin WHERE UserName='" + txtuser.Text + "' AND Password='" + txtpass.Text + "' ", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Session["id"] = txtuser.Text;
                
                Response.Redirect("MainUI_2.aspx");
                
                
            }

            else
            {
                
                outputLabel.Text = "Please Enter Valid Username & Password";
            }
        }
    }
}