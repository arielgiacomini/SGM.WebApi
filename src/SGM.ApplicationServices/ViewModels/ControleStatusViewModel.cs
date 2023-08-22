using System;

namespace SGM.ApplicationServices.ViewModels
{
    public class ControleStatusViewModel
    {
        public int StatusId { get; set; }
        public string TipoStatus { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}