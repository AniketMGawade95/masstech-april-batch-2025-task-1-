using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masstech_task_2_register_login_email
{
    public partial class register : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection conn;
        string query;


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {

            string userid = txtuserid.Text.Trim();
            string email = txtemail.Text.Trim();
            string password = txtPass.Text.Trim();

            try
            {



                conn = new SqlConnection(con);
                conn.Open();
                // Insert new user
                string insertQuery = "INSERT INTO registrationwithmail VALUES (@Username, @Email, @Password)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@Username", userid);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@Password", password);

                    insertCmd.ExecuteNonQuery();

                conn.Close();
                    Response.Write("<script>alert('User Created Successfully')</script>");

                Response.Redirect("login.aspx");
                
            }
            catch (Exception ex)
            {
              
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
    
}