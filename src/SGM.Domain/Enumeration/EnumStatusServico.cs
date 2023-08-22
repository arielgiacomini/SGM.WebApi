using System;
using System.ComponentModel;
using System.Linq;

namespace SGM.Domain.Enumeration
{
    public enum EnumStatusServico
    {
        [Description("Iniciado - Pendente de Término")]
        IniciadoPendente = 6,
        [Description("Expirado")]
        Expirado = 7,
        [Description("Desistido pelo Cliente")]
        DesistidoPeloCliente = 8,
        [Description("Concluido - Serviço executado SEM Pagamento")]
        ConcluidoServicoSemPagamento = 9,
        [Description("Concluido - Serviço executado com Pagamento efetuado")]
        ConcluidoServicoComPagamento = 10
    }

    public static class StatusServico
    {
        public static string TranslateStatusServico(int statusServico)
        {
            string DescricaoEnum = "";

            var tranformEnumInList = Enum.GetValues(typeof(EnumStatusServico)).Cast<EnumStatusServico>();

            foreach (var item in tranformEnumInList)
            {
                if (((int)item) == statusServico)
                {
                    DescricaoEnum = EnumBase.ObterDescricao(item);
                }
            }

            return DescricaoEnum;
        }
    }
}