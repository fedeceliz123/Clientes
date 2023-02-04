using Business.IRepository;
using Business.Models;
using Business.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository _clientesRepository;
        public ClientesController(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        [HttpGet("GetAllClientes")]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
               List<Clientes> clientes= await _clientesRepository.getAllCostumers();
                
                return Ok(clientes);               

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            try
            {
                Clientes cliente = await _clientesRepository.getCostumerById(id);
                if (!string.IsNullOrEmpty(cliente.Nombres))
                {

                return Ok(cliente);
                }
                else
                {
                    return BadRequest("El identificador del cliente no existe");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetClientesByName")]
        public async Task<IActionResult> GetClientesByName(string data)
        {
            try
            {
                List<Clientes> clientes = await _clientesRepository.getCostumersByName(data);

                return Ok(clientes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("InsertCliente")]
        public async Task<IActionResult> InsertCliente([FromBody]InsertClienteDTO cliente)
        {
            try
            {
                List<Validaciones> validacion = Business.Business.validaciones(cliente);

                if (validacion.Count > 0)
                {
                    return Ok(validacion);
                }

                bool insert = await _clientesRepository.insertCostumers(cliente);

                return Ok(insert);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> UpdateCliente([FromBody] Clientes cliente)
        {
            try
            {
                List<Validaciones> validacion = Business.Business.validaciones(insertClienteDTO(cliente));

                if (validacion.Count > 0)
                {
                    return Ok(validacion);
                }

                Clientes clientes = await _clientesRepository.getCostumerById(cliente.idCliente);
                if (!string.IsNullOrEmpty(clientes.Nombres))
                {

                bool update = await _clientesRepository.updateCostumers(cliente);

                return Ok(update);
                }
                else
                {
                    return BadRequest("El identificador del cliente no existe");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private InsertClienteDTO insertClienteDTO(Clientes clientes)
        {
            InsertClienteDTO clienteDTO = new InsertClienteDTO();
            clienteDTO.Nombres = clientes.Nombres;
            clienteDTO.Apellidos = clientes.Apellidos;
            clienteDTO.CUIT = clientes.CUIT;
            clienteDTO.Domicilio = clientes.Domicilio;
            clienteDTO.FechaNacimiento = clientes.FechaNacimiento;
            clienteDTO.email = clientes.email;
            clienteDTO.telefonoCelular = clientes.telefonoCelular;

            return clienteDTO;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteById(int id)
        {
            try
            {
                Clientes cliente = await _clientesRepository.getCostumerById(id);
                if (!string.IsNullOrEmpty(cliente.Nombres))
                {
                    bool borrado =await _clientesRepository.deleteCostumers(id);
                    return Ok(borrado);
                }
                else
                {
                    return BadRequest("El identificador del cliente no existe");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
