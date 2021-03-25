using DIO.Bank.Enums;

namespace DIO.Bank.Models
{
    public class ContaJuridica : Conta
    {
        public string CNPJ { get; set; }
        public ContaJuridica(TipoConta tipoConta, double saldo, double credito, string nome, string cnpj) : base(tipoConta, saldo, credito, nome)
        {
            CNPJ = cnpj;
        }
    }
}