using Business.Models;
using Business.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepository
{
    public interface IClientesRepository
    {
        Task<List<Clientes>> getAllCostumers();
        Task<Clientes> getCostumerById(int  idCliente);
        Task<List<Clientes>> getCostumersByName(string data);
        Task<bool> insertCostumers(InsertClienteDTO cliente);
        Task<bool> updateCostumers(Clientes cliente);
        Task<bool> deleteCostumers(int idCliente);

    }
}
