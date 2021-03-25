namespace DIO.Bank.Models.Interface
{
    public interface IConta
    {
        bool Sacar(double valorSaque);
        double Depositar(double valorDeposito);
        void Transferir(double valor, Conta c);
    }
}