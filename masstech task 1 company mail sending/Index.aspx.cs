using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masstech_task_1_company_mail_sending
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCtc.Visible = false;
            lblEctc.Visible = false;
            lblNp.Visible = false;

            txtctc.Visible = false;
            txtEctc.Visible = false;
            txtNoticePeriod.Visible = false;
        }

        protected void DropDownListStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DropDownListStream.SelectedIndex == 17)
            {
                btnUpload.Enabled = false;
                Response.Write("<script>alert('Only CS Candidates Are Allowed From The List')</script>");
                return;
            }
            else
            {
                btnUpload.Enabled = true;
            }
        }

        protected void DropDownListExperience_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            if (DropDownListExperience.SelectedIndex==1)
            {
                txtctc.Enabled = false;
                txtEctc.Enabled = false;
                txtNoticePeriod.Enabled = false;
                lblCtc.Enabled = false;

                lblCtc.Visible = false;
                lblEctc.Visible = false;
                lblNp.Visible = false;

                txtctc.Visible = false;
                txtEctc.Visible = false;
                txtNoticePeriod.Visible = false;

            }
            else if(DropDownListExperience.SelectedIndex==2)
            {
                txtctc.Enabled = true;
                txtEctc.Enabled = true;
                txtNoticePeriod.Enabled = true;
            
                lblCtc.Visible = true;
                lblEctc.Visible = true;
                lblNp.Visible = true;

                txtctc.Visible = true;
                txtEctc.Visible = true;
                txtNoticePeriod.Visible = true;

            }

            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            Session["stream"] = DropDownListStream.SelectedValue.ToString();
            Session["experience"] = DropDownListExperience.SelectedValue.ToString();
            Session["email"]=txtEmail.Text;
            Session["contact"]=txtContact.Text;


            byte[] fileData = FileUploadResume.FileBytes; // Get file as byte array
            string fileName = FileUploadResume.FileName;


            Session["UploadedFileData"] = fileData;
            Session["UploadedFileName"] = fileName;

            if (DropDownListStream.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Select Stream')</script>");
                return;
            }

            if (DropDownListExperience.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Select Experience')</script>");
                return;
            }


            if (DropDownListExperience.SelectedIndex == 2)
            {
                try
                {

                    //mail to HR

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("aniketmgawade2019@gmail.com");
                    mail.To.Add("aniketgawade2013@gmail.com");
                    mail.Subject = "Experienced Candidate Resume";
                    mail.Body = $"Respected HR Please Review The Resume And Shedule The Interview With Candidate\nStream= {Session["stream"].ToString()}\nExpericence = {Session["experience"].ToString()}\nCTC Of Candidate= {txtctc.Text}\nECTC Of Candidate= {txtEctc.Text}\nNotice Period Of Candidate= {txtNoticePeriod.Text}\nEmail Of Candidate= {txtEmail.Text}\nContact No. Of Candidate= {txtContact.Text}";

                    if (FileUploadResume.HasFiles)
                    {

                        string filename = FileUploadResume.PostedFile.FileName;
                        mail.Attachments.Add(new Attachment(FileUploadResume.PostedFile.InputStream, filename));
                    }


                    //Mail to Candidate

                    MailMessage mail2 = new MailMessage();
                    mail2.From = new MailAddress("aniketmgawade2019@gmail.com");
                    mail2.To.Add(txtEmail.Text);
                    mail2.Subject = "Interview";
                    mail2.Body = "We Will Get Back To You";


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


            if (DropDownListExperience.SelectedIndex==1)
            {
                Response.Redirect("fresher.aspx");
            }

            
        }
    }
}