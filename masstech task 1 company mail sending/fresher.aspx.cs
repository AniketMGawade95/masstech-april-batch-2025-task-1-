using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace masstech_task_1_company_mail_sending
{
    public partial class fresher : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection conn;
        string query;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(con);
            conn.Open();
            string stream = Session["stream"].ToString();
            string experience = Session["experience"].ToString();
            string email = Session["email"].ToString();
            string contact = Session["contact"].ToString();


        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownListDays.SelectedIndex == 0)
                {
                    Response.Write("<script>alert('Select Day')</script>");
                }

                if (DropDownListTiming.SelectedIndex == 0)
                {
                    Response.Write("<script>alert('Select Timing')</script>");
                }

                query = "select * from resumesending where email='" + Session["email"].ToString()+"'";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Write($"<script>alert('You have already booked the meeting')</script>");
                    return;
                    
                    
                }





                query =$"INSERT INTO resumesending (email, day, time) VALUES ('{Session["email"].ToString()}', '{DropDownListDays.SelectedValue.ToString()}', '{DropDownListTiming.SelectedValue.ToString()}')";

                    SqlCommand sqlCommand = new SqlCommand(query, conn);
                    sqlCommand.ExecuteNonQuery();


                    //mail to HR

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("aniketmgawade2019@gmail.com");
                    mail.To.Add("aniketgawade2013@gmail.com");
                    mail.Subject = "Fresher Candidate Resume";
                    mail.Body = $"Respected HR Please Review The Resume And Take The Interview Of The Fresher Candidate\nStream= {Session["stream"].ToString()}\nExpericence = {Session["experience"].ToString()}\nEmail= {Session["email"].ToString()}\nContact No.={Session["contact"].ToString()}";                 


                    
                        byte[] fileData = (byte[])Session["UploadedFileData"];
                        string fileName = Session["UploadedFileName"].ToString();

                        MemoryStream ms = new MemoryStream(fileData);
                        Attachment attach = new Attachment(ms, fileName);
                        mail.Attachments.Add(attach);

                    //Mail to Candidate

                    MailMessage mail2 = new MailMessage();
                    mail2.From = new MailAddress("aniketmgawade2019@gmail.com");
                    mail2.To.Add(Session["email"].ToString());
                    mail2.Subject = "Interview Shedule";
                    mail2.Body = $"Day={DropDownListDays.SelectedValue.ToString()}\nTime= {DropDownListTiming.SelectedValue.ToString()}\nMeeting Link=https://meet.google.com/pci-pjuj-fao";


                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Credentials = new NetworkCredential("aniketmgawade2019@gmail.com", "dpdivxmqwngsrgvk");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    smtp.Send(mail2);


                    Response.Write("<script>alert('Mail send Succecfully')</script>");
                



                


            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }


           


        }

        protected void DropDownListTiming_SelectedIndexChanged(object sender, EventArgs e)
        {


            query = "select * from resumesending where day='" + DropDownListDays.SelectedValue.ToString().Trim() + "' and time='" + DropDownListTiming.SelectedValue.ToString().Trim() + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count >= 2)
            {
                Response.Write($"<script>alert('This time slot is full. Please choose another.')</script>");
            }


        }
    }
}