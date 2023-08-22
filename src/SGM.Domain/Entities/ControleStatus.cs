using System;

namespace SGM.Domain.Entities
{
    public class ControleStatus
    {
        public int StatusId { get; set; }
        public string TipoStatus { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}