using System;
using System.Threading.Tasks;

namespace TestDaleSalesBE.Domain.Contracts
{
    /// <summary>
    /// Generic interface that defines methods CUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericCUDRepository<T> where T : class
    {
        /// <summary>
        /// Method Add, that inserts an element to collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Method Update thad modify the data of an item/object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Method that removes the specified element from collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
    }
}