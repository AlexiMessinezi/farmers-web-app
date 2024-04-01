using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProgTask2v2
{
    public partial class FarmerMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblWelcomeFarmer.Text = "Welcome: " + Request.QueryString["Username"];
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            String farmerName = Request.QueryString["Username"];
            String farmerProduct = txtProductName.Text;
            DateTime farmerDate = cldProductDate.SelectedDate;

            if (farmerName == "" || farmerProduct == "" || farmerDate == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Please ensure all fields are filled in";
                lblError.Visible = true;
                return;
            }
            //If we get here we can insert product in table
            SqlConnection SQLcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FarmCentralDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand com = new SqlCommand("INSERT INTO [ProductsTable] (Username, ProductName, ProductDate) VALUES (@Username, @ProductName, @ProductDate)", SQLcon);
     
            SQLcon.Open();
            com.Parameters.AddWithValue("@Username", farmerName);
            com.Parameters.AddWithValue("@ProductName", farmerProduct);
            com.Parameters.AddWithValue("@ProductDate", farmerDate);

            int result = com.ExecuteNonQuery();
            if (result == 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Failed to add product to database, please try again";
                lblError.Visible = true;
                return;
            }

            // added to database successfully
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Product added to database successfully";
            lblError.Visible = true;

            txtProductName.Text = "";
            cldProductDate.SelectedDates.Clear();
            SQLcon.Close();            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String url = "Login.aspx";
            Response.Redirect(url);
        }
    }
}