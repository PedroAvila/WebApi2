using Prueba.Dominio;
using Prueba.Persistencia;
using System.Collections;
using System.Threading.Tasks;

namespace Prueba.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<IEnumerable> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task CreateAsync(Cliente entity)
        {
            await _clienteRepository.CreateAsync(entity);
        }

    }
}
