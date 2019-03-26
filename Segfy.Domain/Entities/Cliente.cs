using Flunt.Notifications;
using Flunt.Validations;
using SegFy.Shared.Entities;
using System.Collections.Generic;

namespace Segfy.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Documento { get; private set; }
        public Endereco Endereco { get; private set; }
        public IEnumerable<Seguro> Seguros { get; private set; }
        
        public Cliente(string nome, string telefone, string email, string documento, Endereco endereco)
        {
            Alterar(nome, telefone, email, documento);
            Endereco = endereco;
            AddNotifications(new Contract()
               .IsNotNull(Endereco, "Endereco", "Deve ser informado o endereço"));
        }

        public void Alterar(string nome, string telefone, string email, string documento)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Documento = documento;

            AddNotifications(new Contract()
                .HasMinLen(Nome, 3, "Nome", "O nome deve possuir mais que 3 caracteres")
                .HasMaxLen(Nome, 50, "Nome", "O nome deve conter até 50 caracteres")
                .IsNotNullOrEmpty(Nome, "Nome", "O nome não pode ser nulo")
                .IsNotNullOrEmpty(Telefone, "Telefone", "O telefone não pode ser nulo")
                .HasMaxLen(Telefone, 20, "Telefone", "O telefone deve conter até 20 caracteres")
                .IsNotNullOrEmpty(Email, "Email", "Deve ser informado o email")
                .IsEmail(Email, "Email", "Email invalido")                
                .HasMinLen(Documento, 10, "Documento", "O documento deve possuir mais que 10 caracteres")
                .HasMaxLen(Documento, 20, "Documento", "O documento deve conter até 20 caracteres")
                .IsNotNullOrEmpty(Documento, "Documento", "O nome não pode ser nulo"));
        }
    }
}
