using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestDaleSalesBE.Domain.Contracts;
using TestDaleSalesBE.Domain.Entities;
using TestDaleSalesBE.Services.Dto;

namespace TestDaleSalesBE.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        #region Attributes
        private readonly ISaleRepository _sale;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SaleController(ISaleRepository sale, IMapper mapper)
        {
            this._sale = sale;
            this._mapper = mapper;
        }
        #endregion

        #region EndPoints
        [HttpPost]
        [Route("save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> AddAsync(SaleDTO sale) {
            try
            {
                var result = await _sale.AddAsync(_mapper.Map<Sale>(CalculateTotalValue(sale)));
                if (result == null)
                {
                    return BadRequest();
                }

                return true;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        #region PrivateMethods
        private SaleDTO CalculateTotalValue(SaleDTO sale) {
            sale.TotalValue = sale.SaleDetails.Sum(x => x.ProductValue);
            return sale;
        }
        #endregion
    }
}
