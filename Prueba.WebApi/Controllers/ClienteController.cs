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
    }
}
