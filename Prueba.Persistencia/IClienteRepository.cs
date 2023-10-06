using Prueba.Dominio;
using System.Collections;
using System.Threading.Tasks;

namespace Prueba.Persistencia
{
    public interface IClienteRepository
    {
        Task<IEnumerable> GetAllAsync();
        Task<int> MaxIdAsync();
        Task CreateAsync(Cliente entity);
        Task UpdateAsync(Cliente entity);
        Task<Cliente> GetByIdAsync(int id);
    }
}
