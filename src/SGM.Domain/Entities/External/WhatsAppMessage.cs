using System;

namespace SGM.Domain.Entities.External
{
    public class WhatsAppMessage
    {
        public int IdentificadorMensagem { get; set; }
        public string NumeroPais { get; set; }
        public string NumeroDDD { get; set; }
        public string NumeroTelefone { get; set; }
        public string MensagemTexto { get; set; }
        public DateTime DataPropostaParaEnvioMensagem { get; set; }
        public bool EnvioAutomatico { get; set; }
        public bool MensagemFoiEnviada { get; set; }
        public DateTime DataEnvioMensagem { get; set; }
    }
}