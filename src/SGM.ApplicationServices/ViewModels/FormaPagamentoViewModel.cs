using System;
using System.Collections.Generic;

namespace SGM.ApplicationServices.ViewModels
{
    public class FormaPagamentoViewModel
    {
        public int FormaPagamentoId { get; set; }
        public string Descricao { get; set; }
        public bool TemTaxaAdicional { get; set; }
        public decimal PercentualTaxaAdicional { get; set; }
        public int QuantidadeMaximaParcela { get; set; }
        public bool FormaPagamentoAtiva { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public virtual IList<FormaPagamentoParcelaViewModel> ParcelaDisponivel { get; set; }
    }
}