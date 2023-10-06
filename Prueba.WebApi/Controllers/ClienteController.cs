using Prueba.Dominio;
using Prueba.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Prueba.WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return (IEnumerable<Cliente>)await _clienteService.GetAllAsync();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Crear(Cliente cliente)
        {
            try
            {
                await _clienteService.CreateAsync(cliente);
                return Ok();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(Cliente cliente)
        {
            try
            {
                await _clienteService.UpdateAsync(cliente);
                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<Cliente> Get(int id)
        {
            try
            {
                return await _clienteService.GetByIdAsync(id);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
