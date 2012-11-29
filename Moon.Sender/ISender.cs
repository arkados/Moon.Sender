namespace Moon.Sender
{
    /// <summary>
    /// Obecne rozhrani sender. 
    /// Pokud budeme chtit mit kolekci nejakejch objektu
    /// implementujici rozhrani sender a budou ruznych typu
    /// sms sender email sender atd ...
    /// </summary>
   public interface ISender
   {
       void Send(object obj);
   }
}
