using System;
using System.ComponentModel;
using System.Linq;

namespace SGM.Domain.Enumeration
{
    public enum EnumFormaPagamento
    {
        [Description("Dinheiro à vista")]
        DinheiroAVista = 1,
        [Description("Dinheiro Parcelado")]
        DinheiroParcelado = 2,
        [Description("Transferência via PIX")]
        PIX = 3,
        [Description("Cartão de Débito")]
        CartaoDebito = 4,
        [Description("Cartão de Crédito")]
        CartaoCredito = 5,
        [Description("Outras")]
        Outras = 6
    }

    public static class FormaPagamentoEnumeration
    {
        public static string[] GetDescriptionFormasPagamento()
        {
            string[] formasPagamentos;
            formasPagamentos = new string[7];
            var listFormas = Enum.GetValues(typeof(EnumFormaPagamento)).Cast<EnumFormaPagamento>();

            foreach (var item in listFormas)
            {
                formasPagamentos[((byte)item)] = EnumBase.ObterDescricao(item);
            }

            return formasPagamentos;
        }
    }
}