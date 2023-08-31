﻿using Microsoft.AspNetCore.Mvc;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using System;

namespace SGM.WebApi.Controllers
{
    [ApiController]
    [Route("SGM")]
    [Produces("application/json")]
    public class ClienteVeiculoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger; 
        private readonly IClienteVeiculoServices _clienteVeiculoServices;

        public ClienteVeiculoController(Serilog.ILogger logger,
            IClienteVeiculoServices clienteVeiculoServices)
        {
           _logger = logger;
            _clienteVeiculoServices = clienteVeiculoServices;
        }

        [HttpGet]
        [Route("cliente-veiculo/{clienteId}")]
        public IActionResult GetVeiculoClienteByClienteId(int clienteId)
        {
            try
            {
                _logger.Information("[ClienteVeiculoController.GetVeiculoClienteByClienteId] Solicitação para buscar todos os Clienteveiculo");

                var clienteVeiculos = _clienteVeiculoServices.GetClienteVeiculoByClienteId(clienteId);

                return Ok(clienteVeiculos);
            }
            catch (Exception ex)
            {
                _logger.Error("[ClienteVeiculoController.GetVeiculoClienteByClienteId] - Erro ao efetuar a chamada para buscar todos os Clienteveiculo: ", ex);
                
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("cliente-veiculo/placa/{placa}")]
        public IActionResult GetVeiculoClienteByPlaca(string placa)
        {
            try
            {
                _logger.Information($"[GetVeiculoClienteByPlaca] - Buscar Placa do veiculo: {placa} ");
                var clienteVeiculo = _clienteVeiculoServices.GetVeiculoClienteByPlaca(placa);
                return Ok(clienteVeiculo);
            }
            catch (Exception ex)
            {
                _logger.Error($"[GetVeiculoClienteByPlaca] - Erro ao buscar placa do veiculo:  {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("cliente-veiculo/id/{clienteVeiculoId}")]
        public IActionResult GetClienteVeiculoByClienteVeiculoId(int clienteVeiculoId)
        {
            try
            {
                _logger.Information($"[GetClienteVeiculoByClienteVeiculoId] -  Buscar clienteveiculoID: {clienteVeiculoId}");
                var clienteVeiculo = _clienteVeiculoServices.GetVeiculoClienteByClienteVeiculoId(clienteVeiculoId);
                return Ok(clienteVeiculo);
            }
            catch (Exception ex)
            {
                _logger.Error($"GetClienteVeiculoByClienteVeiculoId - Erro ao buscar clienteveiculoID: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("cliente-veiculo")]
        public IActionResult Salvar(ClienteVeiculoViewModel model)
        {
            try
            {
                _logger.Information($"[ClienteveiculoController.Salvar] - Solicitação para salvar o clienteveiculo: {JsonSerializer.Serialize(model)}"); 
                var clienteVeiculoId = _clienteVeiculoServices.SalvarClienteVeiculo(model);
                return Created("", clienteVeiculoId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[ClienteveiculoController.Salvar] - Erro ao tentar salvar o cliente: {JsonSerializer.Serialize(model)} Erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("cliente-veiculo/{clienteVeiculoId}")]
        public IActionResult Atualizar(int clienteVeiculoId, ClienteVeiculoViewModel model)
        {
            try
            {
                model.ClienteVeiculoId = clienteVeiculoId;
                _clienteVeiculoServices.AtualizarClienteVeiculo(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("cliente-veiculo/inativar/{clienteVeiculoId}")]
        public IActionResult InativarClienteVeiculo(int clienteVeiculoId)
        {
            try
            {
                _clienteVeiculoServices.InativarClienteVeiculo(clienteVeiculoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /*
        [HttpGet]
        [Route("cliente/veiculo/paginado/{page}")]
        public IActionResult GetOrcamentosForAllPaginado(int page)
        {
            try
            {
                var count = _clienteVeiculoServices.GetCount();
        
                HttpContext.Response.Headers.Add("X-Total-Count", count.Contagem.ToString());
        
                var pagina = page;
                var clienteVeiculos = _clienteVeiculoServices.GetByAllPaginado(page);
                return Ok(clienteVeiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        */
    }
}
