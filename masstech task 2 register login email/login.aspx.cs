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
    public partial class login : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection conn;
        string query;


        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(con);
            conn.Open();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["email"] = txtemail.Text;
            Session["password"] = txtpass.Text;


            string email = txtemail.Text.Trim();
            string password = txtpass.Text.Trim();


            query = "select * from registrationwithmail where email='" + email + "' and password='" + password + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("dashboard.aspx");
            }
        }
    }
}