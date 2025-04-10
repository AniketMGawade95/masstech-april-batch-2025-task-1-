using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masstech_task_2_register_login_email
{
    public partial class dashboard : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection conn;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {




            conn = new SqlConnection(con);
            conn.Open();

            if (!IsPostBack) // ✅ This avoids reloading data on every postback
            {
                Label1.Text = "hello " + Session["email"].ToString();

                query = "select email from registrationwithmail";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ListBox1.DataSource = ds.Tables[0];
                    ListBox1.DataTextField = "email";
                    ListBox1.DataValueField = "email";
                    ListBox1.DataBind();

                    DropDownList1.DataSource = ds.Tables[0];
                    DropDownList1.DataTextField = "email";
                    DropDownList1.DataValueField = "email";
                    DropDownList1.DataBind();
                }
            }


        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            



            if (ListBox1.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Please select an email from the list.');</script>");
                return;
            }

            if (Session["email"] == null || Session["password"] == null)
            {
                Response.Write("<script>alert('Session expired. Please log in again.');</script>");
                return;
            }

            string tmail = ListBox1.SelectedValue;
            string fmail = Session["email"].ToString();
            string fpass = Session["password"].ToString();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fmail);
                mail.To.Add(tmail);
                mail.Subject = "Files after login";
                mail.Body = txtmessage.Text;

                if (FileUpload1.HasFiles)
                {
                    foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        string filename = file.FileName;
                        mail.Attachments.Add(new Attachment(file.InputStream, filename));
                    }
                }

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Credentials = new NetworkCredential(fmail, fpass);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);

                Response.Write("<script>alert('Mail sent successfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}