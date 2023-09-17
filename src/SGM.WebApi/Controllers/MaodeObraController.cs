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
    public class MaodeObraController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IMaodeObraServices _maodeObraServices;

        public MaodeObraController(Serilog.ILogger logger,
            IMaodeObraServices maoDeObra)

        {
            _logger = logger;
            _maodeObraServices = maoDeObra;
        }

        [HttpGet]
        [Route("mao-de-obra")]
        public IActionResult GetMaodeObraForAll()
        {
            try
            {
                _logger.Information($"[MaodeObra.GetFormaPagamentoForAll] - Solicitação para buscar forma mao de obra");
               
                var maoDeObra = _maodeObraServices.GetMaodeObraByAll();
                
                return Ok(maoDeObra);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[MaodeObraController.GetMaodeObraForAll] - Erro ao buscar forma de mão de obra Erro: {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("mao-de-obra/paginado/{page}")]
        public IActionResult GetMaodeObrasForAllPaginado(int page)
        {
            try
            {
                _logger.Information($"[MaodeObraController.GetMaodeObrasForAllPaginado] - Solicitação para buscar maodeobrapaginado:{page}");

                var count = _maodeObraServices.GetMaodeObraCount();

                HttpContext.Response.Headers.Add("X-Total-Count", count.Contagem.ToString());

                var pagina = page;
                var maoDeObra = _maodeObraServices.GetMaodeObraByAllPaginado(page);
                return Ok(maoDeObra);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[MaodeObraController.GetMaodeObrasForAllPaginado] - Erro ao buscar forma de maodeobrapaginado Erro: {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("mao-de-obra/{maoDeObraId}")]
        public IActionResult GetMaodeObraById(int maoDeObraId)
        {
            try
            {
                _logger.Information($"[MaodeObraController.GetMaodeObraById] - Solicitação para buscar maodeobraById {maoDeObraId}");

                var maoDeObra = _maodeObraServices.GetMaodeObraById(maoDeObraId);

                return Ok(maoDeObra);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[MaodeObraController.GetMaodeObraById] - Erro ao buscar maodeobraById Erro: {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("mao-de-obra/descricao")]
        public IActionResult GetMaodeObraByDescricao(string descricaoMaodeObra)
        {
            try
            {
                _logger.Information($"[MaodeObraController.GetMaodeObraByDescricao] - Solicitação para buscar maodeObraByDescricao {descricaoMaodeObra}");

                var maoDeObra = _maodeObraServices.GetMaodeObraByDescricao(descricaoMaodeObra);

                return Ok(maoDeObra);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[MaodeObraController.GetMaodeObraByDescricao] - Erro ao buscar maodeObraByDescricao {ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("mao-de-obra")]
        public IActionResult Salvar(MaodeObraViewModel model)
        {
            try
            {
                _logger.Information($"[MaodeObraController.Salvar] - Solicitação para Salvar maodeObraViewModel: {JsonSerializer.Serialize(model)}");

                _maodeObraServices.AtualizarOrSalvar(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[MaodeObraController.Salvar] - Erro ao salvar maodeObraViewModel Erro: {ex.Message} Com o objeto {JsonSerializer.Serialize(model)}");

                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("mao-de-obra/{maoDeObraId}")]
        public IActionResult Atualizar(int maoDeObraId, MaodeObraViewModel model)
        {
            try
            {
                _logger.Information($"[MaodeObraController.Atualizar] - Solicitação para atualizar maoDeObraId:{JsonSerializer.Serialize(model)}");

                model.MaodeObraId = maoDeObraId;
                _maodeObraServices.AtualizarOrSalvar(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[MaodeObraController.Atualizar] - Erro ao atualizar maoDeObraId Erro: {ex.Message} com o objeto {JsonSerializer.Serialize(model)}");

                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("mao-de-obra/inativar/{maoDeObraId}")]
        public IActionResult InativarmaoDeObra(int maoDeObraId)
        {
            try
            {
               _logger.Information($"[MaodeObraController.InativarmaoDeObra] - Solicitação para InativarmaoDeObra: {maoDeObraId}");

                _maodeObraServices.InativarMaodeObra(maoDeObraId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex,$"[MaodeObraController.inativarCiente] - Erro ao InativarmaoDeObra: {ex.Message}");

                return StatusCode(500, ex);
            }
        }
    }
}