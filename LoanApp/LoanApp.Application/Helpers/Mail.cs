using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using LoanApp.Domain.Dto;

namespace LoanApp.Application.Helpers
{
    public class Mail
    {

        private string Transmitter { set; get; }
        private string Token { set; get; }

        public Mail(string transmitter, string token)
        {
            Transmitter = transmitter;
            this.Token = token;
        }

        public void Send(string destinatario, ApplicationEmailDto applicationEmailDto)
        {
            string subject = $"Nueva Solicitud de Préstamo #{applicationEmailDto.ApplicationId} - INVERSIONES GEFE";
            string msg = GetMsg(applicationEmailDto);

            MailMessage mainMassage = new MailMessage();
            mainMassage.From = new MailAddress(Transmitter);
            mainMassage.To.Add(new MailAddress(destinatario));
            mainMassage.Subject = subject;
            mainMassage.IsBodyHtml = true;

            SmtpClient clienteSmtp = new SmtpClient();
            clienteSmtp.Host = "smtp.gmail.com";
            clienteSmtp.Port = 587;
            clienteSmtp.EnableSsl = true;
            clienteSmtp.UseDefaultCredentials = false;

            clienteSmtp.Credentials = new NetworkCredential(Transmitter, Token);
            clienteSmtp.EnableSsl = true;

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(msg, null, MediaTypeNames.Text.Html);
            LinkedResource img = new LinkedResource(applicationEmailDto.Identificationimage);
            img.ContentId = "client";
            htmlView.LinkedResources.Add(img);
            mainMassage.AlternateViews.Add(htmlView);

            try
            {
                clienteSmtp.Send(mainMassage);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        
        private string GetMsg(ApplicationEmailDto applicationEmailDto)
        {
            string msg = string.Empty;

            msg = "<html> <body> ";
            msg += "</br>";
            msg += "</br>";
            msg += "<p><h3><b>Datos del Solicitante :</b></h3></p>";
            //msg += "</br>";
            msg += "<p>";
            msg += $"<b>*- Nombre    :  </b>" + applicationEmailDto.Name + " " + applicationEmailDto.Lastname + $" ({applicationEmailDto.Doctortype})";
            msg += "</br>";
            msg += "<b>*- Cedula     :  </b>" + applicationEmailDto.Identification;
            msg += "</br>";
            msg += "<b>*- Sexo       :  </b>" + applicationEmailDto.Sex;
            msg += "</br>";
            msg += $"<b>*- Centro    :  </b> {applicationEmailDto.Medicalcenter}";
            msg += "</br>";
            msg += $"<b>*- Provincia :  </b> {applicationEmailDto.Province}";
            msg += "</br>";
            msg += $"<b>*- Dirección :  </b> {applicationEmailDto.Address}";
            msg += "</br>";
            msg += $"<b>*- Celular   :  </b> {applicationEmailDto.Movil}";
            msg += "</br>";
            msg += "</br>";
            msg += "<p><h3><b>Datos del Familiar :</b></h3></p>";
            msg += $"<b>*- Nombre    :  </b> {applicationEmailDto.Directfamilyname} - {applicationEmailDto.Typefamilyrelationship}";
            msg += "</br>";
            msg += $"<b>*- Teléfono  :  </b> {applicationEmailDto.Directfamilytelephone}";
            msg += "</br>";
            msg += "</br>";
            msg += $"<b>*- Monto del Préstamo  :  </b> {applicationEmailDto.Amounttolend.ToString("C")}";
            msg += "</br>";
            msg += "</br>";
            msg += "<img id = 'client' = '0' alt = 'client' src = 'cid:client' width = '300' height = '180' >";
            msg += "</p>";
            msg += " </body></html>";

            return msg;
        }
    }
}
