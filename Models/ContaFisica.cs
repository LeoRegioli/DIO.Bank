using DIO.Bank.Enums;

namespace DIO.Bank.Models
{
    public class ContaFisica : Conta
    {
        public string CPF { get; set; }
        public ContaFisica(TipoConta tipoConta, double saldo, double credito, string nome, string cpf) : base(tipoConta, saldo, credito, nome)
        {
            CPF = cpf;
        }
    }
}