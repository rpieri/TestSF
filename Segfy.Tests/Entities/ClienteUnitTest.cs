using Segfy.Tests.Builders;
using Xunit;

namespace Segfy.Tests.Entities
{
    public class ClienteUnitTest
    {
        [Fact]
        public void AoAdicionarUmClienteComDadosInvalidosDeveEstarInvalido()
        {
            var cliente = new ClienteBuilder()
                .ComNome(string.Empty)
                .ComEndereco(null)
                .ComEmail(string.Empty)
                .ComDocumento(string.Empty)
                .ComTelefone(string.Empty)
                .Builder();

            Assert.True(cliente.Invalid);
            Assert.Equal(8, cliente.Notifications.Count);
        }

        [Fact]
        public void AoAdicionarUmClienteComNomeClienteEstaraValido()
        {
            var cliente = new ClienteBuilder().ComNome("Raphael").Builder();
            Assert.True(cliente.Valid);
        }

    }
}
