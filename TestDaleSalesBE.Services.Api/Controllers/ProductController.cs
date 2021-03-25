using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDaleSalesBE.Domain.Contracts;
using TestDaleSalesBE.Domain.Entities;
using TestDaleSalesBE.Services.Dto;

namespace TestDaleSalesBE.Services.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Attributes
        private readonly IGenericRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductController(IGenericRepository<Product> ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }
        #endregion

        #region End Points
        /// <summary>
        /// Gets all the Products
        /// </summary>
        /// <returns>The collection of the Products.</returns>
        [HttpGet]
        [Route("Products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            try
            {
                var result = await _ProductRepository.GetAllAsync();

                List<ProductDTO> Products = new List<ProductDTO>();

                foreach (var item in result)
                {
                    ProductDTO Product = new ProductDTO
                    {
                        Id = item.Id,
                        ProductName = item.ProductName,
                        UnitValue = item.UnitValue,
                    };
                    Products.Add(Product);
                }

                return Products;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets a specific Product by ID
        /// </summary>
        /// <returns>The collection of the Products.</returns>
        [HttpGet]
        [Route("Product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            try
            {
                var result = await _ProductRepository.GetById(id);

                ProductDTO product = new ProductDTO
                {
                    Id = result.Id,
                    ProductName = result.ProductName,
                    UnitValue = result.UnitValue,
                };
                
                return product;
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method that inserts a new Product.
        /// </summary>
        /// <param name="ProductDTO"></param>
        /// <returns>The created Product.</returns>
        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDTO>> PostProduct(ProductDTO ProductDTO){
            try
            {
                var newProduct = await _ProductRepository.AddAsync(_mapper.Map<Product>(ProductDTO));
                if (newProduct==null)
                {
                    return BadRequest();
                }
                var newProductDTO = _mapper.Map<ProductDTO>(newProduct);
                return CreatedAtAction(nameof(PostProduct), new {id = newProductDTO.Id, newProductDTO});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that updates an Product.
        /// </summary>
        /// <param name="ProductDTO"></param>
        /// <returns>The Product updated.</returns>
        [HttpPut()]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(ProductDTO ProductDTO) {
            try {
                if (ProductDTO == null) {
                    return NotFound();
                }

                var result = await _ProductRepository.UpdateAsync(_mapper.Map<Product>(ProductDTO));

                if (!result) {
                    return BadRequest();
                }
                return ProductDTO;
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that deletes an Product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted status.</returns>
        [HttpDelete()]
        [Route("Remove/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteProduct(int id) {
            try {
                var result = await _ProductRepository.DeleteAsync(id);

                if (!result) {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}