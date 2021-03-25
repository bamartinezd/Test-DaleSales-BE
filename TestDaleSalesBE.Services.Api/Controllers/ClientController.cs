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
    public class ClientController : ControllerBase
    {
        #region Attributes
        private readonly IGenericRepository<Client> _ClientRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClientController(IGenericRepository<Client> ClientRepository, IMapper mapper)
        {
            _ClientRepository = ClientRepository;
            _mapper = mapper;
        }
        #endregion

        #region End Points
        /// <summary>
        /// Gets all the Clients
        /// </summary>
        /// <returns>The collection of the Clients.</returns>
        [HttpGet]
        [Route("Clients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAll()
        {
            try
            {
                var result = await _ClientRepository.GetAllAsync();

                List<ClientDTO> Clients = new List<ClientDTO>();

                foreach (var item in result)
                {
                    ClientDTO Client = new ClientDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Phone = item.Phone,
                        Email = item.Email
                    };
                    Clients.Add(Client);
                }

                return Clients;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets a specific Client by ID
        /// </summary>
        /// <returns>The collection of the Clients.</returns>
        [HttpGet]
        [Route("Client/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientDTO>> GetById(int id)
        {
            try
            {
                var result = await _ClientRepository.GetById(id);

                ClientDTO Client = new ClientDTO
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Phone = result.Phone,
                    Email = result.Email
                };
                
                return Client;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method that inserts a new Client.
        /// </summary>
        /// <param name="ClientDTO"></param>
        /// <returns>The created Client.</returns>
        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientDTO>> PostClient(ClientDTO ClientDTO){
            try
            {
                var newClient = await _ClientRepository.AddAsync(_mapper.Map<Client>(ClientDTO));
                if (newClient==null)
                {
                    return BadRequest();
                }
                var newClientDTO = _mapper.Map<ClientDTO>(newClient);
                return CreatedAtAction(nameof(PostClient), new {id = newClientDTO.Id, newClientDTO});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that updates an Client.
        /// </summary>
        /// <param name="ClientDTO"></param>
        /// <returns>The Client updated.</returns>
        [HttpPut()]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientDTO>> UpdateClient(ClientDTO ClientDTO) {
            try {
                if (ClientDTO == null) {
                    return NotFound();
                }

                var result = await _ClientRepository.UpdateAsync(_mapper.Map<Client>(ClientDTO));

                if (!result) {
                    return BadRequest();
                }
                return ClientDTO;
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method that deletes an Client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted status.</returns>
        [HttpDelete()]
        [Route("Remove/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteClient(int id) {
            try {
                var result = await _ClientRepository.DeleteAsync(id);

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