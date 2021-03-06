﻿using Flunt.Notifications;
using Flunt.Validations;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Input.Clientes
{
    public class CriarClienteCommand : Notifiable, ICommand 
    {
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Documento { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; set; }
        public string Pais { get; private set; }

        bool ICommand.Valid()
        {
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
                .IsNotNullOrEmpty(Documento, "Documento", "O nome não pode ser nulo")
                .HasMinLen(Rua, 10, "Rua", "O nome da rua deve possuir mais que 3 caracteres")
                .HasMaxLen(Rua, 50, "Rua", "Nome da rua deve conter até 50 caracteres")
                .IsNotNullOrEmpty(Rua, "Rua", "Nome da rua deve ser informada")
                .HasMinLen(Numero, 1, "Numero", "Numero deve possuir mais que 1 caracteres")
                .HasMaxLen(Numero, 20, "Numero", "Numero deve conter até 20 caracteres")
                .IsNotNullOrEmpty(Numero, "Numero", "Numero deve ser informado")
                .HasMaxLen(Complemento, 30, "Complemento", "Complemento deve conter até 20 caracteres")
                .HasMaxLen(Cep, 15, "Cep", "Cep deve conter até 15 caracteres")
                .IsNotNullOrEmpty(Cep, "Cep", "Cep deve ser informado")
                .HasMinLen(Bairro, 5, "Bairro", "Bairro deve possuir mais que 5 caracteres")
                .HasMaxLen(Bairro, 40, "Bairro", "Bairro deve conter até 40 caracteres")
                .IsNotNullOrEmpty(Bairro, "Bairro", "Bairro deve ser informado")
                .HasMinLen(Cidade, 5, "Cidade", "Cidade deve possuir mais que 5 caracteres")
                .HasMaxLen(Cidade, 40, "Cidade", "Cidade deve conter até 40 caracteres")
                .IsNotNullOrEmpty(Cidade, "Cidade", "Cidade deve ser informado")
                .HasMaxLen(Estado, 2, "Estado", "Estado deve conter até 2 caracteres")
                .IsNotNullOrEmpty(Estado, "Estado", "Estado deve ser informado")
                .HasMinLen(Pais, 5, "Pais", "Pais deve possuir mais que 5 caracteres")
                .HasMaxLen(Pais, 40, "Pais", "Pais deve conter até 40 caracteres")
                .IsNotNullOrEmpty(Pais, "Pais", "Pais deve ser informado")
                );

            return Valid;
        }
    }
}
