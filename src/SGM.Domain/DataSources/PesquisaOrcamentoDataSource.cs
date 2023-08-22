using System;

namespace SGM.Domain.DataSources
{
    public class PesquisaOrcamentoDataSource
    {
        public int OrcamentoId { get; set; }
        public string Status { get; set; }
        public string NomeCliente { get; set; }
        public string MarcaModeloVeiculo { get; set; }
        public string Placa { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorAdicional { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal ValorDesconto { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int ClienteId { get; set; }
    }
}