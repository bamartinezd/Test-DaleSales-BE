using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestDaleSalesBE.Domain.Contracts
{
    /// <summary>
    /// Generic interface that defines methods GET
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericGetRepository<T> where T : class
    {
        /// <summary>
        /// Gets all items
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        
        /// <summary>
        /// Gets item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);
    }
}