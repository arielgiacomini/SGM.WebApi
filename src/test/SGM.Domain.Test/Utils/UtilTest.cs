using FluentAssertions;
using NUnit.Framework;
using SGM.Domain.Utils;

namespace SGM.Domain.Test.Utils
{
    public class UtilTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("100,00")]
        [TestCase("100.00")]
        [TestCase("100")]
        [TestCase("1")]
        [TestCase("R$ 100,00")]
        public void VerificaSeEhNumero_VerificaSeEhNumeroDecimal(string valorTestCase)
        {
            var formasPagamento = Util.VerificaSeEhNumero(valorTestCase);

            formasPagamento.Should().Be(true);
        }

        [TestCase("100,00", 100.00)]
        [TestCase("100.59", 100.59)]
        [TestCase("100", 100)]
        [TestCase("1", 1)]
        [TestCase("R$ 100,00", 100.00)]
        [TestCase("0,00%", 0)]
        public void TranslateStringEmDecimal_VerificaSeTodosNumericosSaoNumeros(string valorTestCase, decimal validador)
        {
            var dados = Util.TranslateStringEmDecimal(valorTestCase);

            dados.Should().Be(validador);
        }
    }
}