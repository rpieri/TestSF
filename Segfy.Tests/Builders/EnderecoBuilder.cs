using Segfy.Domain.Entities;

namespace Segfy.Tests.Builders
{
    public class EnderecoBuilder
    {
        private string rua;
        private string numero;
        private string complemento;
        private string cep;
        private string bairro;
        private string cidade;
        private string estado;
        private string pais;

        public EnderecoBuilder()
        {
            rua = "Rua 01";
            numero = "Numero 01";
            complemento = "Complemento 01";
            cep = "9599959";
            bairro = "Bairro 01";
            cidade = "Cidade 01";
            estado = "UF";
            pais = "Brasil";
        }

        public Endereco Builder() => new Endereco(rua, numero, complemento, cep, bairro, cidade, estado, pais);

        public EnderecoBuilder ComRua(string rua)
        {
            this.rua = rua;
            return this;
        }

        public EnderecoBuilder ComNumero(string numero)
        {
            this.numero = numero;
            return this;
        }

        public EnderecoBuilder ComComplemento(string complemento)
        {
            this.complemento = complemento;
            return this;
        }

        public EnderecoBuilder ComCep(string cep)
        {
            this.cep = cep;
            return this;
        }

        public EnderecoBuilder ComBairro(string bairro)
        {
            this.bairro = bairro;
            return this;
        }

        public EnderecoBuilder ComCidade(string cidade)
        {
            this.cidade = cidade;
            return this;
        }

        public EnderecoBuilder ComEstado(string estado)
        {
            this.estado = estado;
            return this;
        }

        public EnderecoBuilder ComPais(string pais)
        {
            this.pais = pais;
            return this;
        }
    }
}
