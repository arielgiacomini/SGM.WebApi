using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using SGM.Domain.Entities;
using System;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SGM.WebApi.Controllers
{
    [ApiController]
    [Route("SGM")]
    [Produces("application/json")]
    public class PecaController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IPecaServices _pecaServices;

        public PecaController(IPecaServices pecaServices)
        {
            _pecaServices = pecaServices;
        }

        [HttpGet]
        [Route("peca")]
        public IActionResult GetOrcamentosForAll()
        {
            try
            {
                _logger.Information($"[PecaController.GetOrcamentosForAll] - Orçamento de peças");

                var peca = _pecaServices.GetPecaByAll();

                return Ok(peca);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[PecaController.GetOrcamentosForAll] - Erro ao efetuar orçamento de peças erro:{ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("peca/paginado/{page}")]
        public IActionResult GetPecaForAllPaginado(int page)
        {
            try
            {
                _logger.Information($"[PecaController.GetPecaForAllPaginado] - Busca de peças por pagina {page}");

                var count = _pecaServices.GetPecaCount();

                HttpContext.Response.Headers.Add("X-Total-Count", count.Contagem.ToString());

                var pagina = page;

                var peca = _pecaServices.GetPecaByAllPaginado(page);

                return Ok(peca);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[PecaController.GetPecaForAllPaginado] - Erro ao buscar peça por pagina {page} erro:{ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("peca/{pecaId}")]
        public IActionResult GetPecaById(int pecaId)
        {
            try
            {
                _logger.Information($"[peca.GetPecaById] - Busca de peças pelo id: {pecaId}");

                var peca = _pecaServices.GetPecaById(pecaId);
                return Ok(peca);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[pecaId.GetPecaById] - Erro ao buscar uma peça pelo id: {pecaId} Erro: {ex.Message}");

                return StatusCode(500, ex);

            }
        }

        [HttpGet]
        [Route("peca/descricao")]
        public IActionResult GetPecaByDescricao(string descricaoPeca)
        {
            try
            {
                _logger.Information($"[PecaController.GetPecaByDescricao] - Busca de peça com uma descrição {descricaoPeca}");

                var peca = _pecaServices.GetPecaByDescricao(descricaoPeca);

                return Ok(peca);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[PecaController.GetPecaByDescricao] - Erro ao Buscar uma peça com uma descrição {descricaoPeca} Erro: {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("peca")]
        public IActionResult Salvar(PecaViewModel model)
        {
            try
            {
                _logger.Information($"[PecaController.Salvar] - Solicitação para salvar uma peça: {JsonSerializer.Serialize(model)}");

                _pecaServices.AtualizarOrSalvar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[PecaController.Salvar]- Erro ao salvaruma peça Erro:{ex.Message} com o objeto:{JsonSerializer.Serialize(model)}");

                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("peca/{pecaId}")]
        public IActionResult Atualizar(int pecaId, PecaViewModel model)
        {
            try
            {
                model.PecaId = pecaId;
                _pecaServices.AtualizarOrSalvar(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("peca/inativar/{pecaId}")]
        public IActionResult InativarPeca(int pecaId)
        {
            try
            {
                _pecaServices.InativarPeca(pecaId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}