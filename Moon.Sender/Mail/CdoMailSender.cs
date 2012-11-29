namespace Moon.Sender.Mail
{
   public class CdoMailSender:IMailSender
    {
        public void Send(object obj)
        {
            ((CDO.Message)obj).Send();
        }
    }
}
