using System;
using System.Collections.Generic;

namespace SGM.ApplicationServices.ViewModels
{
    public class ServicoPagamentoViewModel
    {
        public int ServicoPagamentoId { get; set; }
        public int ServicoId { get; set; }
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamentoViewModel FormaPagamento { get; set; }
        public decimal ValorTotalOriginal { get; set; }
        public decimal ValorTotalPago { get; set; }
        public decimal SaldoDevedorTotal { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool EhPagamentoParcelado { get; set; }
        public bool EhPagamentoEmDuasFormaPagamento { get; set; }
        public decimal ValorPagoNaSegundaFormaPagamento { get; set; }
        public int? ColaboradorCadastroId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? ColaboradorAlteracaoId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public virtual IList<ServicoPagamentoParcelaViewModel> ServicoPagamentoParcela { get; set; }
    }
}