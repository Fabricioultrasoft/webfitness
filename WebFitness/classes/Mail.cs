using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;


namespace WebFitness
{
    partial class Mail
    {

        public Mail()
        {

        }

        public Mail(string mailTo, string mailSubject, string mailBody)
        {
            this.mailTo = mailTo;
            this.mailSubject = mailSubject;
            this.mailBody = mailBody;
        }

        private Int64 FileSize(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            return (file.Length / 1024 / 1024);
        }

        public void sendMail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            Int64 attachmentSize = 0;

            mail.From     = new MailAddress(mailUserName);
            mail.Subject  = this.mailSubject;
            mail.Body     = this.mailBody;
            mail.Priority = this.mailPriority;

            if (!string.IsNullOrEmpty(this.mailTo))
                mail.To.Add(new MailAddress(this.mailTo));

            if (mailToCollection != null)
                foreach (string item in mailToCollection)
                    mail.To.Add(item);

            if (!string.IsNullOrEmpty(this.mailCc))
                mail.CC.Add(this.mailCc);

            if (mailCcCollection != null)
                foreach (string item in mailCcCollection)
                    mail.CC.Add(item);

            if (!string.IsNullOrEmpty(this.mailBcc))
                mail.Bcc.Add(this.mailBcc);

            if (mailBccCollection != null)
                foreach (string item in mailBccCollection)
                    mail.Bcc.Add(item);

            if (string.IsNullOrEmpty(this.mailAttachment))
            {
                if (File.Exists(this.mailAttachment))
                {
                    FileSize(this.mailAttachment);
                    mail.Attachments.Add(new Attachment(this.mailAttachment));
                }
            }

            if (mailAttachmentCollection != null)
            {
                foreach (string item in mailAttachmentCollection)
                {
                    if (File.Exists(item))
                    {
                        FileSize(item);
                        mail.Attachments.Add(new Attachment(item));
                    }
                }
            }

            if (mail.To.Count == 0)
                throw new Exception("Não há destinatários para envio");

            if (string.IsNullOrEmpty(mail.From.Address))
                throw new Exception("Não há remetente para envio");

            if (attachmentSize > 5)
                throw new Exception("Anexo(s) excedeu o limite de tamanho");

            try
            {
                client.Host = mailServer;
                client.Port = mailServerPort;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(mailUserName, mailPassword);
                client.Send(mail);
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao enviar o e-mail: " + e.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
