using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Moon.Sender.Mail;
using Ninject;

namespace WebTest
{
    public partial class Default : System.Web.UI.Page
    {
        [Inject]
        public IMailBodyFromUrl EMailFromUrlCreator { get; set; }

        [Inject]
        public IMailSender Sender { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var msgMail = new System.Net.Mail.MailMessage();
            msgMail.To.Add(new MailAddress("tuma.rsrobot@gmail.com"));
            
            var email = EMailFromUrlCreator.GetEmailFromUrl(msgMail, new Uri("http://hotel-ubytovani.com")) ;

            Sender.Send(email);
            
            var baseUri = new Uri("http://localhost:3337");
            var url = new Uri(baseUri,"EmailTemplate.aspx");
            
            email = EMailFromUrlCreator.GetEmailFromUrl(msgMail, url);
            
            Sender.Send(email);


        }
    }
}