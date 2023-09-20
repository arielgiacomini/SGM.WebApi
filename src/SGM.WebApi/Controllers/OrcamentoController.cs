using Microsoft.AspNetCore.Mvc;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using System;
using System.Text.Json;

namespace SGM.WebApi.Controllers
{
    [ApiController]
    [Route("SGM")]
    [Produces("application/json")]
    public class OrcamentoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IOrcamentoServices _orcamentoServices;

        public OrcamentoController(Serilog.ILogger logger,
            IOrcamentoServices orcamentoServices)
        {
            _logger = logger;
            _orcamentoServices = orcamentoServices;
        }

        [HttpGet]
        [Route("orcamento")]
        public IActionResult GetOrcamentosForAll()
        {
            try
            {
                _logger.Information($"[OrcamentoController.GetOrcamentosForAll] - Solicitação para buscar orcamento");

                var orcamento = _orcamentoServices.GetOrcamentoByAll();

                return Ok(orcamento);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[OrcamentoController.GetOrcamentosForAll] - Erro ao efetuar o orcamento {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("orcamento/ultimos-gerados")]
        public IActionResult GetUltimosOrcamentos(int quantidade)
        {
            try
            {
                _logger.Error($"[OrcamentoController.GetUltimosOrcamentos] - Solicitação para buscar orcamentoultimosgerados: {quantidade}");
                var count = _orcamentoServices.GetOrcamentoCount();

                HttpContext.Response.Headers.Add("X-Total-Count", count.Contagem.ToString());

                var ultimosOrcamentos = _orcamentoServices.GetUltimosOrcamentos(quantidade);

                return Ok(ultimosOrcamentos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[OrcamentoController.GetUltimosOrcamentos] - Erro ao buscar orcamentoultimosgerados: {quantidade} Erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("orcamento/{orcamentoId}")]
        public IActionResult GetOrcamentosById(int orcamentoId)
        {
            try
            {
                _logger.Information($"[OrcamentoController.GetOrcamentosById] - Solicitação para buscar orcamentoID: {orcamentoId}");

                var orcamento = _orcamentoServices.GetOrcamentoById(orcamentoId);
                return Ok(orcamento);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[OrcamentoController.GetOrcamentosById] - Erro ao buscar orcamentoID: {orcamentoId} Erro: {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("orcamento/veiculo-cliente/")]
        public IActionResult GetOrcamentoClienteVeiculoId(int clienteVeiculoId)
        {
            try
            {
                _logger.Information($"[OrcamentoController.GetOrcamentoClienteVeiculoId] - Solicitação para buscar clienteVeiculoID: {clienteVeiculoId}");

                var orcamento = _orcamentoServices.GetOrcamentoByClienteVeiculoId(clienteVeiculoId);
                return Ok(orcamento);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[OrcamentoController.GetOrcamentoClienteVeiculoId] -  Erro ao buscar orcamentoClienteVeiculoID {clienteVeiculoId} Erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("orcamento")]
        public IActionResult Salvar(OrcamentoViewModel model)
        {
            try
            {
                _logger.Information($"[OrcamentoController.Salvar] - Solicitação para Salvar orcamento:  {JsonSerializer.Serialize(model)}");
                var Id = _orcamentoServices.AtualizarOrSalvarOrcamento(model);

                if (Id == 0)
                {
                    return Ok();
                }

                return Created("", Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[OrcamentoController.Salvar] -  Erro ao salvar orcamento Erro: {ex.Message} Com o objeto {JsonSerializer.Serialize(model)}");
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("orcamento/{orcamentoId}")]
        public IActionResult Atualizar(int orcamentoId, OrcamentoViewModel model)
        {
            try
            {
                _logger.Information($"[OrcamentoController.Atualizar] - Solicitação para atualizar orcamentoID: {orcamentoId} Com o objeto {JsonSerializer.Serialize(model)}");

                model.OrcamentoId = orcamentoId;
                _orcamentoServices.AtualizarOrSalvarOrcamento(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[OrcamentoController.Atualizar] - Erro ao atualizar orcamentoID Erro:{orcamentoId} Com o objeto {JsonSerializer.Serialize(model)}");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("orcamento/mao-de-obra")]
        public IActionResult SalvarOrcamentoMaodeObra(OrcamentoMaodeObraViewModel model)
        {
            try
            {
                var Id = _orcamentoServices.SalvarOrcamentoMaodeObra(model);
                return Created("", Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("orcamento/peca")]
        public IActionResult SalvarOrcamentoPeca(OrcamentoPecaViewModel model)
        {
            try
            {
                var Id = _orcamentoServices.SalvarOrcamentoPeca(model);
                return Created("", Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("orcamento/mao-de-obra")]
        public IActionResult DeletarOrcamentoMaodeObra(OrcamentoMaodeObraViewModel model)
        {
            try
            {
                _orcamentoServices.DeletarOrcamentoMaodeObra(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("orcamento/peca")]
        public IActionResult DeletarOrcamentoPeca(OrcamentoPecaViewModel model)
        {
            try
            {
                _orcamentoServices.DeletarOrcamentoPeca(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("orcamento/mao-de-obra/{orcamentoId}")]
        public IActionResult GetOrcamentoMaodeObraByOrcamentoId(int orcamentoId)
        {
            try
            {
                var orcamentoMaodeObra = _orcamentoServices.GetOrcamentoMaodeObraByOrcamentoId(orcamentoId);
                return Ok(orcamentoMaodeObra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("orcamento/peca/{orcamentoId}")]
        public IActionResult GetOrcamentoPecaByOrcamentoId(int orcamentoId)
        {
            try
            {
                var orcamentoMaodeObra = _orcamentoServices.GetOrcamentoPecaByOrcamentoId(orcamentoId);
                return Ok(orcamentoMaodeObra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}