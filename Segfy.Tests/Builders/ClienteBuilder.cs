using Segfy.Domain.Entities;

namespace Segfy.Tests.Builders
{
    public class ClienteBuilder
    {
        private string nome;
        private string telefone;
        private string email;
        private string documento;
        private Endereco endereco;

        public ClienteBuilder()
        {
            nome = "Carlos Antonio";
            telefone = "415563256";
            email = "carlos_antonio_figueiredo@gmail.com";
            documento = "07546522539";
            endereco = new EnderecoBuilder().Builder();
        }

        public Cliente Builder() => new Cliente(nome, telefone, email, documento, endereco);

        public ClienteBuilder ComNome(string nome)
        {
            this.nome = nome;
            return this;
        }

        public ClienteBuilder ComTelefone(string telefone)
        {
            this.telefone = telefone;
            return this;
        }
        public ClienteBuilder ComEmail(string email)
        {
            this.email = email;
            return this;
        }
        public ClienteBuilder ComDocumento(string documento)
        {
            this.documento = documento;
            return this;
        }
        public ClienteBuilder ComEndereco(Endereco endereco)
        {
            this.endereco = endereco;
            return this;
        }
    }
}
