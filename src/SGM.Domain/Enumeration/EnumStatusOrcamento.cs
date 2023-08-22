using System.ComponentModel;

namespace SGM.Domain.Enumeration
{
    public enum EnumStatusOrcamento
    {
        [Description("Iniciado - Pendente de Término")]
        IniciadoPendente = 1,
        [Description("Expirado")]
        Expirado = 2,
        [Description("Desistido pelo Cliente")]
        Desistido = 3,
        [Description("Concluido - Gerado mas ainda não houve serviço")]
        ConcluidoSemGerarServico = 4,
        [Description("Concluido e Gerou Ordem de Serviço")]
        GerouServico = 5
    }
}