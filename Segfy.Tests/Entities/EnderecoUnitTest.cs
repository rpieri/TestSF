using Segfy.Tests.Builders;
using Xunit;

namespace Segfy.Tests.Entities
{
    public class EnderecoUnitTest
    {
        [Fact]
        public void EnderecoDeveRetornaInvalido()
        {
            var endereco = new EnderecoBuilder()
                .ComRua(string.Empty)
                .ComNumero(string.Empty)
                .ComComplemento(string.Empty)
                .ComCep(string.Empty)
                .ComBairro(string.Empty)
                .ComCidade(string.Empty)
                .ComEstado(string.Empty)
                .ComPais(string.Empty)
                .Builder();
            Assert.True(endereco.Invalid);
        }

        [Fact]
        public void EnderecoCompletoDeveEstarValido()
        {
            var endereco = new EnderecoBuilder().Builder();
            Assert.True(endereco.Invalid);
        }
    }
}
