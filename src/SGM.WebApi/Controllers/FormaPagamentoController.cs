using Microsoft.AspNetCore.Mvc;
using SGM.ApplicationServices.Interfaces;
using System;

namespace SGM.WebApi.Controllers
{
    [ApiController]
    [Route("SGM")]
    [Produces("application/json")]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IFormaPagamentoServices _formaPagamentoServices;


        public FormaPagamentoController(Serilog.ILogger logger,
            IFormaPagamentoServices formaPagamentoServices)
        {
            _logger = logger;
            _formaPagamentoServices = formaPagamentoServices;
        }

        [HttpGet]
        [Route("forma-pagamento")]
        public IActionResult GetFormaPagamentoForAll()
        {
            try
            {
                _logger.Information($"[FormaPagamentoController.GetFormaPagamentoForAll] - Solicitação para buscar forma de pagamento");

                var formaPagamento = _formaPagamentoServices.GetFormaPagamentoByAll();

                return Ok(formaPagamento);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[GetFormaPagamentoForAll] - Erro ao buscar forma de pagamento Erro: {ex.Message} ");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("forma-pagamento/{formaPagamentoId}")]
        public IActionResult GetFormaPagamentoForById(int formaPagamentoId)
        {
            try
            {
                _logger.Information($"[FormaPagamentoController.GetFormaPagamentoForById] - Solicitação para buscar a forma de pagamento ID: {formaPagamentoId}");

                var formaPagamento = _formaPagamentoServices.GetFormaPagamentoById(formaPagamentoId);
                return Ok(formaPagamento);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[formaPagamentoId] - Erro ao solicitar a forma de pagamento ID : {formaPagamentoId} Erro: {ex.Message}");
                return StatusCode(500, ex);
            }
        }
    }
}