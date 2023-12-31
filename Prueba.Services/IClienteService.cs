﻿using Prueba.Dominio;
using System.Collections;
using System.Threading.Tasks;

namespace Prueba.Services
{
    public interface IClienteService
    {
        Task<IEnumerable> GetAllAsync();
        Task CreateAsync(Cliente entity);
        Task UpdateAsync(Cliente entity);
        Task<Cliente> GetByIdAsync(int id);
    }
}
