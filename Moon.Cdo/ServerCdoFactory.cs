using System.Web;

namespace Moon.Cdo
{  
    /// <summary>
     /// Pro vytváření objektů pomocí Server.CreateObject
    /// </summary>
    public class ServerCdoFactory :ICdoFactory
    {
        public virtual T Create<T>()
        {
            return (T)HttpContext.Current.Server.CreateObject(typeof(T).FullName);
        }
        
    }
}
