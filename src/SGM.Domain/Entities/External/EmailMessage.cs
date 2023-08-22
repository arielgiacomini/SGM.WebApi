using System;

namespace SGM.Domain.Entities.External
{
    public class EmailMessage
    {
        public int EmailId { get; set; }
        public int IdentificadorDisparo { get; set; }
        public int EnderecoEmail { get; set; }
        public string ConteudoAssuntoEmail { get; set; }
        public string ConteudoCorpoEmail { get; set; }
        public DateTime DataParaEnvio { get; set; }
    }
}