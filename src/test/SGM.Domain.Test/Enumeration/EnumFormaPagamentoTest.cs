using FluentAssertions;
using NUnit.Framework;
using SGM.Domain.Enumeration;

namespace SGM.Domain.Test.Enumeration
{
    public class EnumFormaPagamentoTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetDescriptionFormasPagamento_VerificaTodasFormas()
        {
            var formasPagamento = FormaPagamentoEnumeration.GetDescriptionFormasPagamento();

            formasPagamento.Should();
        }
    }
}