using System;
using DIO.Bank.Models.Interface;
using DIO.Bank.Enums;

namespace DIO.Bank.Models
{
    public abstract class Conta : IConta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public double Depositar(double valorDeposito)
        {
            if (valorDeposito <= 0)
            {
                Console.WriteLine("Valor do depósito inválido.\n");
                return 0.0;
            }

            this.Saldo += valorDeposito;
            Console.WriteLine($"{this.Nome}, deposito realizado com sucesso. O saldo atualizado é de R${this.Saldo}\n");
            return this.Saldo;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine($"{this.Nome} não possui saldo suficiente para realizar o saque.\n");
                return false;
            }

            this.Saldo -= valorSaque;
            return true;
        }

        public void Transferir(double valor, Conta c)
        {
            if (this.Sacar(valor))
                c.Depositar(valor);
        }

        public override string ToString()
        {
            return "Nome: " + this.Nome + " | " +
                "Tipo Conta: " + this.TipoConta + " | " +
                "Saldo: " + this.Saldo + " | " +
                "Crédito: " + this.Credito;
        }

    }
}