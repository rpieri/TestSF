using Segfy.Tests.Builders;
using Xunit;

namespace Segfy.Tests.Entities
{
    public class SeguroDeVidaUnitTest
    {
        [Fact]
        public void SeguroDeVidaDeveEstarInvalido()
        {
            var seguro = new SeguroDeVidaBuilder()
                .ComCliente(null)
                .ComCpf(string.Empty)
                .ComValor(0)
                .Builder();
            Assert.True(seguro.Invalid);
        }

        [Fact]
        public void SeguroDeVidaDeveEstarValido()
        {
            var seguro = new SeguroDeVidaBuilder().Builder();
            Assert.True(seguro.Invalid);
        }
    }
}
