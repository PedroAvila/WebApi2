using Oracle.ManagedDataAccess.Client;
using Prueba.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Prueba.Persistencia
{
    public class ClienteRepository : IClienteRepository
    {
        public async Task<IEnumerable> GetAllAsync()
        {
            string sql = "SELECT * FROM Clientes";
            using (var conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                conexion.Open();
                using (OracleCommand cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = sql;
                    var cliente = new List<Cliente>();
                    using (OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var c = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]),
                                Direccion = Convert.ToString(reader["Direccion"])
                            };
                            cliente.Add(c);
                        }
                    }
                    return cliente;
                }
            }
        }

        public async Task CreateAsync(Cliente entity)
        {
            string sql = "INSERT INTO Clientes(IdCliente, Nombre, NumeroDocumento, Direccion) VALUES(:IdCliente, :Nombre, :NumeroDocumento, :Direccion)";
            using (var conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString.ToString()))
            {
                conexion.Open();
                int NextId = await MaxIdAsync() + 1;

                OracleCommand cmd = new OracleCommand(sql, conexion);

                cmd.Parameters.Add(new OracleParameter(":IdCliente", OracleDbType.Int32)).Value = NextId;
                cmd.Parameters.Add(new OracleParameter(":Nombre", OracleDbType.Varchar2)).Value = entity.Nombre;
                cmd.Parameters.Add(new OracleParameter(":NumeroDocumento", OracleDbType.Varchar2)).Value = entity.NumeroDocumento;
                cmd.Parameters.Add(new OracleParameter(":Direccion", OracleDbType.Varchar2)).Value = entity.Direccion;

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> MaxIdAsync()
        {
            string sql = "SELECT MAX(IdCliente) FROM Clientes";
            using (var conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                conexion.Open();
                OracleCommand cmd = new OracleCommand( sql, conexion);
 
                var result = await cmd.ExecuteScalarAsync();
                if(result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
                else return 0;
            }
        }

        public Task UpdateAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
