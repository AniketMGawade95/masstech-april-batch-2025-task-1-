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
            conn = new SqlConnection(con);
            conn.Open();
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {

            string userid = txtuserid.Text.Trim();
            string email = txtemail.Text.Trim();
            string password = txtPass.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();

                    // Check for existing user/email
                    string checkQuery = "SELECT * FROM registrationwithmail WHERE username = @Username OR email = @Email";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Username", userid);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // User already exists
                        
                        Response.Write("<script>alert('User already exists')</script>");
                        
                        return;
                    }

                    // Insert new user
                    string insertQuery = "INSERT INTO registrationwithmail (username, email, password) VALUES (@Username, @Email, @Password)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@Username", userid);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@Password", password);

                    insertCmd.ExecuteNonQuery();

                   
                    Response.Write("<script>alert('User Created Successfully')</script>");

                    //// Optional: clear fields
                    //txtuserid.Text = "";
                    //txtemail.Text = "";
                    //// Don't clear password here unless you want it blanked
                }
            }
            catch (Exception ex)
            {
              
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

    }
    }
}