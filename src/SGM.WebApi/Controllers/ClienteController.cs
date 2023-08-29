using Microsoft.AspNetCore.Mvc;
using Serilog.Core;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using System;
using System.Text.Json;

namespace SGM.WebApi.Controllers
{
    [ApiController]
    [Route("SGM")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IClienteServices _clienteServices;

        public ClienteController(Serilog.ILogger logger, 
            IClienteServices clienteServices)
        {
            _logger = logger;
            _clienteServices = clienteServices;
        }

        [HttpGet]
        [Route("cliente")]
        public IActionResult GetClientesForAll()
        {
            try
            {
                _logger.Information("[GetClientesForAll] - Solicitação de Todos os Clientes");
                var clientes = _clienteServices.GetByAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                _logger.Error("[GetClientesForAll]", ex);
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("cliente/{clienteId}")]
        public IActionResult GetClientesById(int clienteId)
        {
            try
            {
                _logger.Information($"[GetClientesById] - Solicitação de um cliente: {clienteId} ");
                var clientes = _clienteServices.GetById(clienteId);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[GetClientesById] - Erro ao efetuar o Get para o cliente {clienteId} error:{ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("cliente")]
        public IActionResult Salvar(ClienteViewModel model)
        {
            try
            {
                var clienteId = _clienteServices.Salvar(model);

                _logger.Information($"[Salvar] - Cliente Salvo: {JsonSerializer.Serialize(model)}");
                
                return Created("", clienteId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[Salvar] - Erro ao Salvar Cliente: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("cliente/{clienteId}")]
        public IActionResult Atualizar(int clienteId, ClienteViewModel model)
        {
            try
            {
                _logger.Information($"[ Atualizar]  - Atualizar cliente ID {clienteId} com o objeto:{JsonSerializer.Serialize(model)}");
                model.ClienteId = clienteId;
                _clienteServices.Atualizar(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[Atualizar] - Erro ao atualizar: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("cliente/documento-cliente")]
        public IActionResult GetClienteByDocumentoCliente(string documentoCliente)
        {
            try
            {
                _logger.Information($"[GetClienteByDocumentoCliente] - Buscar um cliente a partir do documento:{documentoCliente}");

                var cliente = _clienteServices.GetClienteByDocumentoCliente(documentoCliente);

                
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[GetClienteByDocumentoCliente] - Erro ao buscar documento: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("cliente/inativar/{clienteId}")]
        public IActionResult InativarCliente(int clienteId)
        {
            try
            {
                _logger.Information($"[inativar cliente] -  Salvar ao inativar cliente {clienteId}");
                _clienteServices.InativarCliente(clienteId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[Inativar cliente] - Erro ao inativar o cliente: {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("cliente/placa-veiculo")]
        public IActionResult GetClienteByPlaca(string placaVeiculo)
        {
            try
            {
                _logger.Information($"[GetClienteByPlaca] - Buscar Placa do veiculo {placaVeiculo}");
                var cliente = _clienteServices.GetClienteByPlacaVeiculo(placaVeiculo);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[GetClienteByPlaca] - Erro a buscar placa do veiculo: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("cliente/placa-or-nome-or-apelido")]
        public IActionResult GetClienteByLikePlacaOrNomeOrApelido(string valor)
        {
            try
            {
                _logger.Information($"[GetClienteByLikePlacaOrNomeOrApelido] -  Buscar Cliente, Nome, Placa, Apelido {valor} ");
                var cliente = _clienteServices.GetClienteByLikePlacaOrNomeOrApelido(valor);

                if (cliente.ClienteId == 0)
                {
                    return NoContent();
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[GetClienteByLikePlacaOrNomeOrApelido] - Erro ao buscar Cliente, Nome, Placa, Apelido {ex.Message}");
                return StatusCode(500, ex);
            }
        }
    }
}