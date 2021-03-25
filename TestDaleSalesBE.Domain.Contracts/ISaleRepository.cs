using System.Threading.Tasks;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Domain.Contracts
{
    public interface ISaleRepository
    {
        Task<Sale> AddAsync(Sale entity);
    }
}
