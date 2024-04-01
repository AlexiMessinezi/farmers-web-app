using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ProgTask2v2
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hides error label
            lblError.Visible = false;
            lblWelcomeEmployee.Text = "Welcome: " + Request.QueryString["Username"];
            updateTable();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Redirects user to Login Page
            String url = "Login.aspx";
            Response.Redirect(url);
        }

        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            String farmerName = txtFarmerUsername.Text;
            String farmerPassword = txtFarmerPassword.Text;
            String farmerRole = "farmer";

            //Data validation
            if(farmerName == "" || farmerPassword =="")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Please ensure all fields are filled in";
                lblError.Visible = true;
                return;
            }

            // If we get here, we can add new farmer to the database
            SqlConnection SQLcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FarmCentralDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand com = new SqlCommand("INSERT INTO [UserTable] (Username, Password, UserRole) VALUES (@Username, @Password, @UserRole)", SQLcon);

            SQLcon.Open();
            com.Parameters.AddWithValue("@Username", farmerName);
            com.Parameters.AddWithValue("@Password", farmerPassword);
            com.Parameters.AddWithValue("@UserRole", farmerRole);

            int result = com.ExecuteNonQuery();
            
            //Data validation
            if (result == 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Failed to add farmer to database, please try again";
                lblError.Visible = true;
                return;
            }

            // added to database successfully
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Farmer added to database successfully";
            lblError.Visible = true;

            txtFarmerUsername.Text = "";
            txtFarmerPassword.Text = "";

            updateTable();

            SQLcon.Close();
        }

        public void updateTable()
        {
            SqlConnection SQLcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FarmCentralDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SQLcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * from [ProductsTable]",SQLcon);         
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            //poppulates Data grid
            grdView.DataSource = dtbl;
            grdView.DataBind();

            SQLcon.Close();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFilterFarmer.Text = "";
            txtFilterProduct.Text = "";
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            string filterFarmer = txtFilterFarmer.Text;
            string filterProduct = txtFilterProduct.Text;

            SqlConnection SQLcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FarmCentralDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SQLcon.Open();
            String sql = "";

            if((filterFarmer.Length > 0) && (filterProduct.Length == 0))
            {
                // Only name is being filtered
                sql = "SELECT * from [ProductsTable] where Username = '" + filterFarmer + "'";

            }
            else if((filterFarmer.Length == 0) && (filterProduct.Length > 0))
            {
                // Only product is being filtered
                sql = "SELECT * from [ProductsTable] where ProductName = '" + filterProduct + "'";
            }
            else if ((filterFarmer.Length >0 )&& (filterProduct.Length >0))
                {
                // Both fields is being filtered
                sql = "SELECT * from [ProductsTable] where Username = '" + filterFarmer + "' and ProductName = '" + filterProduct + "'";                
            }
            else
            {
                sql = "SELECT * from [ProductsTable]";
            }           

            SqlDataAdapter sqlDa = new SqlDataAdapter(sql, SQLcon);

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            grdView.DataSource = dtbl;
            grdView.DataBind();
            SQLcon.Close();
        }
    }
}