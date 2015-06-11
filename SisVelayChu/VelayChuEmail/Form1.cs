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
using VelaychuBE;
using VelaychuBL;

namespace VelayChuEmail
{
    public partial class Form1 : Form
    {
        public SmtpClient Cliente = new SmtpClient();
        public MailMessage msg = new MailMessage();
        public System.Net.NetworkCredential SmtpCredits = new System.Net.NetworkCredential("b.pacheco@velaychu.com", "1440bhli");
        List<TmpAlertaBE> lTTmpAlertaBE;
        TmpAlertaBL _TmpAlertaBL = new TmpAlertaBL();

        public void EnviarMail(TmpAlertaBE _miAlerta)
        {
            //string sendTo, string sendFrom, string subject, string body
            try
            {
                Cliente.Port = 587;
                Cliente.Host = "smtp.gmail.com";
                Cliente.UseDefaultCredentials = false;
                //Cliente.UseDefaultCredentials = true;
                Cliente.Credentials = SmtpCredits;
                Cliente.EnableSsl = true;


                MailAddress to = new MailAddress(_miAlerta.Email);
                MailAddress from = new MailAddress("noreply@velaychu.com");

                msg.Subject = "Alerta de Impulso Expediente Nº " + _miAlerta.CodigoExpediente;

                string palinBody =
              "Plain text content, viewable by clients that don\'t support html";
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(
                    palinBody, null, "text/plain");

                string htmlBody = "<html><head>";
                htmlBody += "<style type=\"text/css\">h2 {  font-size: 21px;  line-height: 28px;  margin-bottom: 10px;  color: #009dee;}";
                htmlBody += "Body{	background-color: #FFFFFF;	font-family: Arial, Helvetica, sans-serif;	font-size: 12px;	line-height: 1.5em;	color: #000000;}";
                htmlBody += "body,td,th {	color: #202020;}</style></head>";
                htmlBody += "<body><h2>Alerta de Impulso</h2>";
                htmlBody += "<table width=\"337\" border=\"0\">";
                htmlBody += "<tr><td width=\"141\">Expediente Nº:</td><td width=\"186\">" + _miAlerta.CodigoExpediente + "</td></tr>";
                htmlBody += "<tr><td width=\"141\">Cliente:</td><td width=\"186\">" + _miAlerta.NombreCompletoCliente + "</td></tr>";
                htmlBody += "<tr><td valign=\"top\">Detalle Nº:</td><td>" + _miAlerta.CodigoDetalleExpediente + "</td></tr>";
                htmlBody += "<tr><td valign=\"top\">Contrato Nº:</td><td>" + _miAlerta.CodigoExpedienteContrato + "</td></tr>";
                htmlBody += "<tr><td valign=\"top\">Evento:</td><td>" + _miAlerta.CodigoEvento + "</td></tr>";
                htmlBody += "<tr><td valign=\"top\">Etapa:</td><td>" + _miAlerta.CodigoEtapa + "</td></tr><tr>";
                htmlBody += "<tr><td valign=\"top\">Estado:</td><td>" + _miAlerta.Estado + "</td></tr><tr>";
                htmlBody += "<tr><td valign=\"top\">Fecha de Impulso</td><td>" + _miAlerta.FechaImpulso + "</td></tr>";
                htmlBody += "<tr><td width=\"141\">Abogado:</td><td width=\"186\">" + _miAlerta.NombreCompletoAbogado + "</td></tr>";
                htmlBody += "</table></body></html>";
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
            try
            {
                lTTmpAlertaBE = _TmpAlertaBL.TraerAlerta();
                foreach (TmpAlertaBE _miAlerta in lTTmpAlertaBE)
                {
                    EnviarMail(_miAlerta);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }


        }
    }
}
