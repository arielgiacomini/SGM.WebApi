using Microsoft.AspNetCore.Mvc;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using SGM.Domain.Entities;
using System;
using System.Text.Json;

namespace SGM.WebApi.Controllers
{
    [ApiController]
    [Route("SGM")]
    [Produces("application/json")]
    public class VeiculoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IVeiculoServices _veiculoServices;

        public VeiculoController(Serilog.ILogger logger, IVeiculoServices veiculoServices)
        {
            _logger = logger;
            _veiculoServices = veiculoServices;
        }

        [HttpGet]
        [Route("veiculo")]
        public IActionResult GetVeiculoForAll()
        {
            try
            {
                _logger.Information("[VeiculoController.GetVeiculoForAll] - Solicitação para buscar Todos os Veiculos");

                var veiculo = _veiculoServices.GetByAll();
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.GetVeiculoForAll] - Erro ao efetuar a chamada para Buscar todos os veiculos: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("veiculo/{veiculoId}")]
        public IActionResult GetVeiculoById(int veiculoId)
        {
            try
            {
                _logger.Information($"[VeiculoController.GetVeiculoById] - Solicitação para buscar o veiculo de Id: {veiculoId}");

                var veiculo = _veiculoServices.GetById(veiculoId);

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.GetVeiculoById] - Erro ao efetuar a chamada para Buscar o veiculo de Id: {veiculoId} com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("veiculo/descricao-modelo/")]
        public IActionResult GetVeiculoByModeloDescricao(string descricaoModelo)
        {
            try
            {
                _logger.Information($"[VeiculoController.GetVeiculoByModeloDescricao] - Solicitação para buscar o veiculo pela Descrição e/ou Modelo: {descricaoModelo}");

                var veiculo = _veiculoServices.GetVeiculoByDescricaoModelo(descricaoModelo);

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.GetVeiculoById] - Erro ao efetuar a chamada para Buscar o veiculo pela Descrição e/ou Modelo: {descricaoModelo} com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("veiculo")]
        public IActionResult Salvar(VeiculoViewModel model)
        {
            try
            {
                _logger.Information($"[VeiculoController.Salvar] - Solicitação para salvar o veiculo: {JsonSerializer.Serialize(model)}");

                var veiculoId = _veiculoServices.AtualizarOrSalvar(model);

                return Created("", veiculoId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.Salvar] - Erro ao salvar o veiculo: {JsonSerializer.Serialize(model)} com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("veiculo/{veiculoId}")]
        public IActionResult Atualizar(int veiculoId, VeiculoViewModel model)
        {
            try
            {
                _logger.Information($"[VeiculoController.Atualizar] - Solicitação para Atualizar o veiculoId: {veiculoId} com o seguinte objeto: {JsonSerializer.Serialize(model)}");

                model.VeiculoId = veiculoId;
                _veiculoServices.AtualizarOrSalvar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.Atualizar] - Erro ao atualizar o veiculoId: {veiculoId} com o seguinte objeto: {JsonSerializer.Serialize(model)} com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("veiculo/inativar/{veiculoId}")]
        public IActionResult InativarVeiculo(int veiculoId)
        {
            try
            {
                _logger.Information($"[VeiculoController.InativarVeiculo] - Solicitação para InativarVeiculo o veiculoId: {veiculoId}");

                _veiculoServices.InativarVeiculo(veiculoId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.InativarVeiculo] - Erro ao InativarVeiculo o veiculoId: {veiculoId} com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("veiculo/marca/{marcaId}")]
        public IActionResult GetVeiculosByMarcaId(int marcaId)
        {
            try
            {
                _logger.Information($"[VeiculoController.GetVeiculosByMarcaId] - Solicitação para Buscar o Veiculo pela MarcaId: {marcaId}");

                var veiculos = _veiculoServices.GetVeiculosByMarcaId(marcaId);

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.GetVeiculosByMarcaId] - Erro ao solicitar a busca dos Veiculos pela MarcaId {marcaId} com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("marca/{marcaId}")]
        public IActionResult GetMarcaId(int marcaId)
        {
            try
            {
                _logger.Information($"[VeiculoController.GetMarcaId] - Solicitação para Buscar a Marca pelo Id: {marcaId}");

                var marca = _veiculoServices.GetMarcaByMarcaId(marcaId);

                return Ok(marca);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.GetMarcaId] - Erro ao solicitar a busca de marca pela MarcaId {marcaId} com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("marcas")]
        public IActionResult GetMarcasByAll()
        {
            try
            {
                _logger.Information($"[VeiculoController.GetMarcasByAll] - Solicitação para Buscar todas as marcas");

                var marcas = _veiculoServices.GetMarcasByAll();

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[VeiculoController.GetMarcasByAll] - Erro ao solicitar a busca de todas as marcas com a seguinte mensagem de erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }
    }
}