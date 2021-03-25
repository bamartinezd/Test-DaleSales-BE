using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestDaleSalesBE.Domain.Contracts;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Data.DataAccess.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {

        #region Attributes
        private readonly Test_Dale_SalesContext _context;
        private DbSet<Product> _dbSet;
        #endregion

        #region Constructor
        public ProductRepository(Test_Dale_SalesContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<Product>();
        }
        #endregion

        #region Methods
        public async Task<Product> AddAsync(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                return await _context.SaveChangesAsync() > 0 ? entity : new Product();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = _dbSet.FirstOrDefault(pro => pro.Id == id);
            _context.Remove(result);
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _dbSet.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            var result = _dbSet.FirstOrDefault(pro => pro.Id == entity.Id);
            result.ProductName = entity.ProductName;
            result.UnitValue = entity.UnitValue;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}