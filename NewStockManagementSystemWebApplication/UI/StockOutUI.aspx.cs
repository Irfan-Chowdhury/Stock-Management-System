using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyWebApp.BLL;
using NewStockManagementSystemWebApplication.BLL;
using StockOutWebApp;

namespace NewStockManagementSystemWebApplication.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        StockInManager stockInManager = new StockInManager();

        StockOutManager stockOutManager = new StockOutManager();
        private string item;
        private int companyId;
        int checkInS = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();

            if (Session["id"] == null)
            {
                Response.Redirect("UserLoginUI.aspx?logout=true");
            }
           
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = companyManager.GetAllCompany();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("Select", "0"));
            }

        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            itemDropDownList.DataSource = stockInManager.GetAllItemsByCompanyId(companyId);
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("Select", "0"));
            outputLabel.Text = null;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = null;
            string tempStockOutQuantity = stockOutTextBox.Text;
            int tempCompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            int tempItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
            outputLabel.Text = stockOutManager.SetValidation(tempStockOutQuantity, tempCompanyId, tempItemId);
            if (stockOutManager.PassValidation())
            {

                if (ViewState["stockOutListVS"] == null)
                {
                    StockOut stockOut = new StockOut();

                    stockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                    stockOut.CompanyName = companyDropDownList.SelectedItem.Text;
                    stockOut.ItemName = itemDropDownList.SelectedItem.Text;
                    stockOut.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                    stockOut.StockOutQuantity = Convert.ToInt32(stockOutTextBox.Text);
                    int tempStockOut = stockOut.StockOutQuantity;
                    int checkVS = 0;
                    checkVS = stockOutManager.CheckBefore(tempStockOut, stockOut.ItemName, stockOut.CompanyId);
                    if (checkVS > 0)
                    {
                        outputLabel.Text = "Quantity of " + stockOut.ItemName + " is insufficent";
                    }
                    else
                    {
                        List<StockOut> stockOutList = new List<StockOut>();
                        stockOutList.Add(stockOut);
                        ViewState["stockOutListVS"] = stockOutList;
                    }
                }
                else
                {
                    List<StockOut> stockOut = (List<StockOut>)ViewState["stockOutListVS"];
                    StockOut newStockOut = new StockOut();
                    int check = 0;
                    newStockOut.CompanyName = companyDropDownList.SelectedItem.Text;
                    newStockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                    newStockOut.ItemName = itemDropDownList.SelectedItem.Text;
                    newStockOut.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                    newStockOut.StockOutQuantity = Convert.ToInt32(stockOutTextBox.Text);
                    foreach (StockOut aStockOut in stockOut)
                    {
                        if (aStockOut.CompanyName == newStockOut.CompanyName && aStockOut.ItemName == newStockOut.ItemName)
                        {
                            check = 1;

                            int q = aStockOut.StockOutQuantity;
                     
                            int tempStockOut = q + newStockOut.StockOutQuantity;
                            int checkVS = 0;
                            checkVS = stockOutManager.CheckBefore(tempStockOut, aStockOut.ItemName, aStockOut.CompanyId);
                            if (checkVS > 0)
                            {
                                outputLabel.Text = "Quantity of " + aStockOut.ItemName + " is insufficent";
                            }
                            else
                            {


                                aStockOut.StockOutQuantity = q + newStockOut.StockOutQuantity;
                                newStockOut.StockOutQuantity = aStockOut.StockOutQuantity;
                               
                            }



                        }
                    }
                    if (check == 0)
                    {
                        int tempStockOut = newStockOut.StockOutQuantity;
                        int checkVS = 0;
                        checkVS = stockOutManager.CheckBefore(tempStockOut, newStockOut.ItemName, newStockOut.CompanyId);
                        if (checkVS > 0)
                        {
                            outputLabel.Text = "Quantity of " + newStockOut.ItemName + " is insufficent";
                        }
                        else
                        {

                            stockOut.Add(newStockOut);
                            ViewState["stockOutListVS"] = stockOut;
                        }
                    }
                }
            }


            List<StockOut> aNewstockOut = (List<StockOut>)ViewState["stockOutListVS"];
            stockOutGridView.DataSource = (List<StockOut>)ViewState["stockOutListVS"];
            stockOutGridView.DataBind();
        }


        StockOutDB stockOutDB = new StockOutDB();




        private void SaveInDb(string condition)
        {
            if (ViewState["stockOutListVS"] == null)
            {
                outputLabel.Text = "Please add some items.";
            }
            else
            {
                List<StockOut> stockOut = (List<StockOut>)ViewState["stockOutListVS"];

                foreach (StockOut aStockOut in stockOut)
                {
                    stockOutDB = new StockOutDB();

                    stockOutDB.CompanyId = aStockOut.CompanyId;
                    stockOutDB.ItemId = aStockOut.ItemId;
                    stockOutDB.ItemName = aStockOut.ItemName;
                    stockOutDB.StockOutQuantity = aStockOut.StockOutQuantity;
                    stockOutDB.ItemType = condition;
                    stockOutManager.GetAvailable(stockOutDB.ItemName, stockOutDB.CompanyId);
                   

                    checkInS = checkInS + stockOutManager.Check(stockOutDB);


                }
                if (checkInS > 0)
                {
                    //outputLabel.Text = "Some items are insufficient";
                }
                else
                {



                    foreach (StockOut aStockOut in stockOut)
                    {
                        StockOutDB stockOutDB = new StockOutDB();

                        stockOutDB.CompanyId = aStockOut.CompanyId;
                        stockOutDB.ItemId = aStockOut.ItemId;
                        stockOutDB.ItemName = aStockOut.ItemName;
                        stockOutDB.StockOutQuantity = aStockOut.StockOutQuantity;
                        stockOutDB.ItemType = condition;
                        stockOutManager.GetAvailable(stockOutDB.ItemName, stockOutDB.CompanyId).ToString();
                       
                        outputLabel.Text = stockOutManager.Save(stockOutDB);

                    }
                }

            }
        }


        protected void itemDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            outputLabel.Text = null;
            item = itemDropDownList.SelectedItem.Text;
            companyId = Convert.ToInt32(companyDropDownList.SelectedValue);

            availableLabel.Text = stockOutManager.GetAvailable(item, companyId).ToString();
            reorderLabel.Text = stockOutManager.GetReorderLevel(item, companyId).ToString();

        }

        protected void sellButton_Click1(object sender, EventArgs e)
        {
            SaveInDb("Sell");
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            SaveInDb("Damage");

        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            SaveInDb("Lost");

        }

    }
}
