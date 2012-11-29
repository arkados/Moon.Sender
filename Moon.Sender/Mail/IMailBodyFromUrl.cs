using System;
using System.Net.Mail;

namespace Moon.Sender.Mail
{
    /// <summary>
    /// Ma metodu ktera umi vratit nejaky objekt reprezentujici email z predaneho url.
    /// Vraci obecnej typ objekt prave proto ze nevime jestli je vracenej objekt napriklad System.Net.Mail.MesgMail
    /// nebo CDO.Message nebo uplne jinej objekt reprezentujici email to vi az sender kterej se pouzije.
    /// </summary>
   public interface IMailBodyFromUrl
   {
       /// <summary>
       /// Vrati nejaky objekt reprezentujici email. O jakej presne objekt jde vi az konkretni sender .
       /// Objekt kterej vraci ma jiz naplnene body ktere se vytvori z predaneho url
       /// </summary>
       /// <param name="message">Objekt email</param>
       /// <param name="url">Z ceho se ma udelat Body emailu Musi byt absolute path</param>
       /// <returns>Objekt reprezentujici email s naplnenym Body </returns>
        object GetEmailFromUrl(MailMessage message,Uri url);
   }
}
