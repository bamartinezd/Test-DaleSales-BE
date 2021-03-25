using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestDaleSalesBE.Domain.Contracts;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Data.DataAccess.Repositories
{
    public class SaleRepository : ISaleRepository
    {

        #region Attributes
        private readonly Test_Dale_SalesContext _context;
        private DbSet<Sale> _dbSet;
        #endregion

        #region Constructor
        public SaleRepository(Test_Dale_SalesContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<Sale>();
        }

        #endregion

        #region Methods
        public async Task<Sale> AddAsync(Sale entity)
        {
            entity.SaleDate = DateTime.Now;
            try
            {
                await _context.Sales.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new Sale();
            }
            return entity;
        }
        #endregion
    }
}