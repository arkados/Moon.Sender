namespace Moon.Factory
{
    /// <summary>
    /// Třída , která Implementuje toto rozhraní má 
    /// metodu Create ktera vrací objekt typu T
    /// </summary>
   public interface ICreate
    {
       /// <summary>
       /// Vytvoří objekt typu T
       /// </summary>
       /// <typeparam name="T">Jaký objekt se má vytvořit</typeparam>
       /// <returns>Nově vytvořený objekt</returns>
       T Create<T>();
    }
}
