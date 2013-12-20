using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace WebFitnessLib
{
    partial class Mail
    {
        // Configurações do servidor SMTP
        private static string mailServer = "smpt.google.com";
        private static Int32 mailServerPort = 995;
        private static string mailUserName = "baierle.fitness@gmail.com";
        private static string mailPassword = "baierle123";

        // Variáveis para montar o E-Mail
        public string mailTo { get; set; }
        public string[] mailToCollection { get; set; }
        public string mailFrom { get; set; }
        public string mailSubject { get; set; }
        public string mailBody { get; set; }
        public string mailCc { get; set; }
        public string[] mailCcCollection { get; set; }
        public string mailBcc { get; set; }
        public string[] mailBccCollection { get; set; }
        public MailPriority mailPriority { get; set; }
        public string mailAttachment { get; set; }
        public string[] mailAttachmentCollection { get; set; }

        
    }
}
