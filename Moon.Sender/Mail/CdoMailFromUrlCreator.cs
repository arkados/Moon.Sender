using System;
using System.Net.Mail;
using System.Web;
using CDO;
using Moon.Cdo;

namespace Moon.Sender.Mail
{
   public class CdoMailFromUrlCreator:IMailBodyFromUrl
   {
       protected readonly Configuration MailConfiguration;
       protected readonly ICdoFactory ConfigurationFactory; 

       public CdoMailFromUrlCreator(IMailCdoConfiguration mailConfiguration, ICdoFactory configurationFactory)
       {
           MailConfiguration = mailConfiguration.Create();
           ConfigurationFactory = configurationFactory;
       }
       
       
       public object GetEmailFromUrl(MailMessage message, Uri url)
       {
           var result = ConfigurationFactory.Create<Message>();
           result.Configuration = MailConfiguration;
           result.CreateMHTMLBody(url.ToString(), CdoMHTMLFlags.cdoSuppressStyleSheets, "", "");


           foreach (var priloha in message.Attachments)
           {
               if (priloha.ContentDisposition.FileName == null)
               {
                   throw (new Exception(@" No priloha.ContentDisposition Example:
                                    Attachment data = new Attachment(Server.MapPath(""~/PrilohySmazat/priloha1.xls""));
                                    ContentDisposition disposition = data.ContentDisposition;
                                    disposition.FileName = Server.MapPath(""~/PrilohySmazat/priloha1.xls"");
                                    msg.Attachments.Add(data);
                    
                    "));
               }


               result.AddAttachment(priloha.ContentDisposition.FileName);
           }

           result.MimeFormatted = true;
          
           result.From = message.From.ToString();
           result.To = message.To.ToString();
           result.CC = message.CC.ToString();
           result.BCC = message.Bcc.ToString();
           result.Subject = message.Subject;

           return result;
       }
    }
}
