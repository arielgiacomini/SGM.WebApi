using System;

namespace SGM.ApplicationServices.ViewModels
{
    public class FormaPagamentoParcelaViewModel
    {
        public int FormaPagamentoParcelaId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int NumeroParcela { get; set; }
        public string TextoParcela { get; set; }
        public DateTime DataCadastro { get; set; }
        public int ColaboradorCadastroId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? ColaboradorAlteracaoId { get; set; }
    }
}