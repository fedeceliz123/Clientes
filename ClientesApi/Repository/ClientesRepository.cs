using Business.IRepository;
using Business.Models;
using Business.Models.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly string _connection;
        public ClientesRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<bool> deleteCostumers(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("deleteCostumer", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idCliente);
                   


                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();


                        return true;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<List<Clientes>> getAllCostumers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connection))
                {
                    using (SqlCommand cmd = new SqlCommand("getAllCostumer", con))
                    {
                        List<Clientes> clientes = new List<Clientes>();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;


                        await con.OpenAsync();

                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                Clientes cliente = await MapCostumerReader(dr);
                                clientes.Add(cliente);
                            }
                        }
                        return clientes;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }
    

        public async Task<Clientes> getCostumerById(int idCliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connection))
                {
                    using (SqlCommand cmd = new SqlCommand("getCostumerById", con))
                    {
                        Clientes cliente = new Clientes();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCliente",idCliente);

                        await con.OpenAsync();

                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                 cliente = await MapCostumerReader(dr);
                                
                            }
                        }
                        return cliente;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Clientes>> getCostumersByName(string data)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connection))
                {
                    using (SqlCommand cmd = new SqlCommand("getCostumerByName", con))
                    {
                        List<Clientes> clientes = new List<Clientes>();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@data", data);

                        await con.OpenAsync();

                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                Clientes cliente = await MapCostumerReader(dr);
                                clientes.Add(cliente);
                            }
                        }
                        return clientes;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> insertCostumers(InsertClienteDTO cliente)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("createCostumer", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", cliente.Nombres);
                        cmd.Parameters.AddWithValue("@apellido", cliente.Apellidos);
                        cmd.Parameters.AddWithValue("@fechaN", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@cuit", cliente.CUIT);
                        cmd.Parameters.AddWithValue("@domicilio", cliente.Domicilio);
                        cmd.Parameters.AddWithValue("@telefono", cliente.telefonoCelular);
                        cmd.Parameters.AddWithValue("@email", cliente.email);


                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();


                        return true;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<bool> updateCostumers(Clientes cliente)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("updateCostumer", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", cliente.idCliente);
                        cmd.Parameters.AddWithValue("@nombre", cliente.Nombres);
                        cmd.Parameters.AddWithValue("@apellido", cliente.Apellidos);
                        cmd.Parameters.AddWithValue("@fechaN", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@cuit", cliente.CUIT);
                        cmd.Parameters.AddWithValue("@domicilio", cliente.Domicilio);
                        cmd.Parameters.AddWithValue("@telefono", cliente.telefonoCelular);
                        cmd.Parameters.AddWithValue("@email", cliente.email);


                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();


                        return true;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    private async Task<Clientes> MapCostumerReader(SqlDataReader dr)
    {
        Clientes clientes = new Clientes();
            clientes.idCliente = int.Parse(dr["idCliente"].ToString());
            clientes.Nombres= (dr["Nombres"].ToString());
            clientes.Apellidos= (dr["Apellidos"].ToString());
            clientes.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
            clientes.CUIT = (dr["CUIT"].ToString());
            clientes.Domicilio = (dr["Domicilio"].ToString());
            clientes.telefonoCelular = (dr["telefonoCelular"].ToString());
            clientes.email = (dr["email"].ToString());
            return await Task.FromResult(clientes);
    }


}
}
