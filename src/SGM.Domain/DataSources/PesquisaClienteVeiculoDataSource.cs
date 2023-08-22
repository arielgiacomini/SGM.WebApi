using System;

namespace SGM.Domain.DataSources
{
    public class PesquisaClienteVeiculoDataSource
    {
        public int ClienteVeiculoId { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string Modelo { get; set; }
        public string PlacaVeiculo { get; set; }
        public string CorVeiculo { get; set; }
        public int KmRodados { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}