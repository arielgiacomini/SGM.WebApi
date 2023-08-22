using Microsoft.AspNetCore.Mvc;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;

namespace SGM.WebApi.Controllers
{
    [Route("SGM")]
    [ApiController]
    [Produces("application/json")]
    public class ServicoPagamentoController : ControllerBase
    {
        private readonly IServicoPagamentoServices _servicoPagamentoServices;

        public ServicoPagamentoController(IServicoPagamentoServices servicoPagamentoServices)
        {
            _servicoPagamentoServices = servicoPagamentoServices;
        }

        [HttpGet]
        [Route("servico-pagamento")]
        public IActionResult GetServicoPagamentoForAll()
        {
            try
            {
                var servicoPagamento = _servicoPagamentoServices.GetServicoPagamentoByAll();

                return Ok(servicoPagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("servico-pagamento/{servicoId}")]
        public IActionResult GetServicoPagamentoByServicoId(int servicoId)
        {
            try
            {
                var servicoPagamento = _servicoPagamentoServices.GetServicoPagamentoByServicoId(servicoId);

                return Ok(servicoPagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("servico-pagamento")]
        public IActionResult SalvarServicoPagamento(ServicoPagamentoViewModel model)
        {
            try
            {
                _servicoPagamentoServices.SalvarServicoPagamento(model);

                return Created("", "");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("servico-pagamento")]
        public IActionResult AtualizarServicoPagamento(ServicoPagamentoViewModel model)
        {
            try
            {
                _servicoPagamentoServices.AtualizarServicoPagamento(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("servico-pagamento-parcela")]
        public IActionResult SalvarServicoPagamentoParcela(IList<ServicoPagamentoParcelaViewModel> model)
        {
            try
            {
                _servicoPagamentoServices.SalvarServicoPagamentoParcelas(model);

                return Created("", "");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("servico-pagamento-parcela/deletar/{servicoId}")]
        public IActionResult SalvarServicoPagamentoParcela(int servicoId, int? parcela)
        {
            try
            {
                _servicoPagamentoServices.DeletarServicoPagamentoParcelaByServicoIdAndParcela(servicoId, parcela);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}