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
        private readonly IFormaPagamentoServices _formaPagamentoServices;

        public FormaPagamentoController(IFormaPagamentoServices formaPagamentoServices)
        {
            _formaPagamentoServices = formaPagamentoServices;
        }

        [HttpGet]
        [Route("forma-pagamento")]
        public IActionResult GetFormaPagamentoForAll()
        {
            try
            {
                var formaPagamento = _formaPagamentoServices.GetFormaPagamentoByAll();
                return Ok(formaPagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("forma-pagamento/{formaPagamentoId}")]
        public IActionResult GetFormaPagamentoForById(int formaPagamentoId)
        {
            try
            {
                var formaPagamento = _formaPagamentoServices.GetFormaPagamentoById(formaPagamentoId);
                return Ok(formaPagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}