using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace VelayChuEmail
{
    public partial class Form1 : Form
    {
        public SmtpClient Cliente = new SmtpClient();
        public MailMessage msg = new MailMessage();
        public System.Net.NetworkCredential SmtpCredits = new System.Net.NetworkCredential("corderito.jl@gmail.com", "velaychu");

        public void EnviarMail(string sendTo, string sendFrom, string subject, string body)
        {
            try
            {
                Cliente.Port = 587;
                Cliente.Host = "smtp.gmail.com";
                Cliente.UseDefaultCredentials = false;
                //Cliente.UseDefaultCredentials = true;
                Cliente.Credentials = SmtpCredits;
                Cliente.EnableSsl = true;


                MailAddress to = new MailAddress(sendTo);
                MailAddress from = new MailAddress(sendFrom);

                msg.Subject = subject;
                
                string palinBody =
              "Plain text content, viewable by clients that don\'t support html";
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(
                    palinBody, null, "text/plain");

                string htmlBody = "<b>The embedded image file.</b><DIV> </DIV>";
                htmlBody +=
          "<img alt=\"\" hspace=0 src=\"cid:uniqueId\" align=baseline border=0 >";
                htmlBody += "<DIV> </DIV><b>This is the end of Mail...</b>";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    htmlBody, null, "text/html");

                // create image resource from image path using LinkedResource class..            
                LinkedResource imageResource = new LinkedResource(
                     "c:\\imagen\\arroba.jpg", "image/jpeg");
                imageResource.ContentId = "uniqueId";
                imageResource.TransferEncoding = TransferEncoding.Base64;

                // adding the imaged linked to htmlView...
                htmlView.LinkedResources.Add(imageResource);

                // add the views
                msg.Body = htmlBody;
                msg.AlternateViews.Add(plainView);
                msg.AlternateViews.Add(htmlView);
                msg.From = from;
                msg.To.Add(to);


                Cliente.Send(msg);
            }
            catch (Exception ex)
            {
                FSLogger mylogger = new FSLogger("logfile.txt");
                mylogger.EscribirLog(ex);
            }
            finally
            {
                Application.Exit();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnviarMail("chefo_lc@hotmail.com", "urco.jl@pg.com", "Esta es una Prueba", "Cuerpo");
        }
    }
}
