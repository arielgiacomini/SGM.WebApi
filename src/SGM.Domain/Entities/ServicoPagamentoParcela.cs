using System;

namespace SGM.Domain.Entities
{
    public class ServicoPagamentoParcela
    {
        public int ServicoPagamentoParcelaId { get; set; }
        public int ServicoPagamentoId { get; set; }
        public int Parcela { get; set; }
        public decimal ValorOriginalParcela { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string Descricao { get; set; }
        public bool ParcelaGeradaAutomaticamente { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}