using System.Net;
using System.Net.Mail;
using CDO;
using Moon.Cdo;

namespace Moon.Sender.Mail
{
    public class CdoMailConfiguration : IMailCdoConfiguration
    {
        protected readonly SmtpClient SmtpClient;
        protected readonly ICdoFactory ConfigurationFactory;  
        private Configuration _configuration;

        public CdoMailConfiguration(ICdoFactory configurationFactory)
        {
            ConfigurationFactory = configurationFactory;
            SmtpClient = new SmtpClient();
        }

        protected virtual Configuration BildConfiguration()
        {
            var result = ConfigurationFactory.Create<Configuration>(); 

            var fields = result.Fields;

            var networkCredential = (NetworkCredential)SmtpClient.Credentials;

            var field = fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"];
            field.Value = SmtpClient.Host;

            if(networkCredential !=null  &&  networkCredential.UserName != "" )
            {

                field = fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"];
                field.Value = 1;

                field =
                    fields["http://schemas.microsoft.com/cdo/configuration/sendusername"];
                field.Value = ((NetworkCredential) SmtpClient.Credentials).UserName;

                field =
                    fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"];
                field.Value = ((NetworkCredential) SmtpClient.Credentials).Password;
            }
            else
            {
                field = fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"];
                field.Value = 0;
            }
          
            field =
                 fields["http://schemas.microsoft.com/cdo/configuration/sendusing"];
            field.Value = 2;

            fields.Update();

            return result;
        }
        
        public Configuration Create()
        {
            return _configuration ?? (_configuration = BildConfiguration());
        }
    }
}
