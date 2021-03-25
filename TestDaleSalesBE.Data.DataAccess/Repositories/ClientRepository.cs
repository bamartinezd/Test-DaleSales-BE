using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestDaleSalesBE.Domain.Contracts;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Data.DataAccess.Repositories
{
    public class ClientRepository : IGenericRepository<Client>
    {

        #region Attributes
        private readonly Test_Dale_SalesContext _context;
        private DbSet<Client> _dbSet;
        #endregion

        #region Constructor
        public ClientRepository(Test_Dale_SalesContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<Client>();
        }
        #endregion

        #region Methods
        public async Task<Client> AddAsync(Client entity)
        {
            try
            {
                _context.Clients.Add(entity);
                return await _context.SaveChangesAsync() > 0 ? entity : new Client();
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

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<Client> GetById(int id)
        {
            var result = await _dbSet.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(Client entity)
        {
            var result = _dbSet.FirstOrDefault(pro => pro.Id == entity.Id);
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.Phone = entity.Phone;
            result.Email = entity.Email;
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