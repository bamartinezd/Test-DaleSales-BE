namespace TestDaleSalesBE.Domain.Contracts
{
    /// <summary>
    /// Generic interface that implements another generics repositories operations CUD and Get 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> : IGenericGetRepository<T>, IGenericCUDRepository<T> where T : class{}
}