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
    public partial class Login : System.Web.UI.Page
    {                   
        //Add database string
        SqlConnection SQLcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FarmCentralDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            SqlCommand com = new SqlCommand("SELECT * from [UserTable] where Username = @username and Password = @password", SQLcon);
            SQLcon.Open();
            com.Parameters.AddWithValue("@username", txtUsername.Text);
            com.Parameters.AddWithValue("@password", txtPassword.Text);
            //Makes the command type equal to the command text
            com.CommandType = CommandType.Text;
            //Creates a new sql adapter called adapter
            SqlDataAdapter adapter = new SqlDataAdapter();
            //The sql adapter select command is equal to the command
            adapter.SelectCommand = com;
            //Creates a new dataset dataSet
            DataSet dataSet = new DataSet();
            //Fills the adapter with the dataSet
            adapter.Fill(dataSet);


            if (dataSet.Tables[0].Rows.Count == 0)
            {
                lblError.Text = "Invalid Credentials, Please try again";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                clearFields();
                return;                
            }

            String tempRole = dataSet.Tables[0].Rows[0][2].ToString();
            if(tempRole == "farmer")
            {
                //redirect to farmers page
                String url = "FarmerMenu.aspx?Username=" + txtUsername.Text;
                clearFields();
                Response.Redirect(url);

            }
            else 
            {
                // redirect to employee page
                String url = "EmployeeMenu.aspx?Username=" + txtUsername.Text;
                clearFields();
                Response.Redirect(url);
            }
        }

        public void clearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}