using System;
using System.Collections.Generic;
using System.Linq;
using DIO.Bank.Enums;
using DIO.Bank.Models;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> lc = new List<Conta>();
        static ContaFisica cf = new ContaFisica((TipoConta)1, 2000, 100, "Leonardo", "123211231321");
        static ContaJuridica cf2 = new ContaJuridica((TipoConta)2, 2000, 100, "Henrique", "1111122233333");
        static Dictionary<string, Action> dic = new Dictionary<string, Action>
            {
                {"1", ListarContas},
                {"2", CriarContas},
                {"3", Transferir},
                {"4", Sacar},
                {"5", Depositar},
                {"C", ConsoleClear},
                {"X", Sair}
            };

        static void Main(string[] args)
        {
            lc.Add(cf);
            lc.Add(cf2);

            string optionUser = Menu(limpaTela: true);
            while (optionUser.ToUpper() != "X")
            {
                dic[optionUser].Invoke();
                optionUser = Menu();
            }
        }

        public static void ConsoleClear()
        {
            Console.Clear();
        }
        private static void Sair()
        {
            Environment.Exit(-1);
        }

        private static void Transferir()
        {
            ListarContas();
            Console.Write("Digite o número da conta de origem: ");
            int origem = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor para ser transferido: ");
            double valor = double.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int destino = int.Parse(Console.ReadLine());

            lc[origem].Transferir(valor, lc[destino]);
        }

        private static void Sacar()
        {
            ListarContas();
            Console.Write("Informe o número da conta: ");
            int conta = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine("\nAntes do saque");
            Console.WriteLine(lc[conta] + "\n");
            if (lc[conta].Sacar(valor))
            {
                Console.WriteLine("Depois do saque");
                Console.WriteLine(lc[conta]);
            }

            Console.WriteLine();
        }

        public static string Menu(bool limpaTela = false, bool opcInvalido = false)
        {
            if (limpaTela) ConsoleClear();
            if (opcInvalido) Console.Error.WriteLine("Opção inválido.");

            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.Write("> ");

            return Console.ReadLine().ToUpper();
        }

        public static void ListarContas()
        {
            var count = 0;
            ConsoleClear();

            if (lc.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas.\n");
                return;
            }

            foreach (var item in lc)
            {
                Console.WriteLine($"{count} - {item}");
                count++;
            }
            Console.WriteLine();
        }

        public static void CriarContas()
        {
            ConsoleClear();
            Console.WriteLine("Tipo de pessoa.");
            Console.WriteLine("1 - Pessoa Física");
            Console.WriteLine("2 - Pessoa Jurídica");
            Console.Write("> ");
            int tipo = Int16.Parse(Console.ReadLine());

            while (tipo != 1 && tipo != 2)
            {
                ConsoleClear();
                Console.WriteLine("Opção inválida, favor verificar as opções válidas!");
                Console.WriteLine("1 - Pessoa Física");
                Console.WriteLine("2 - Pessoa Jurídica");
                Console.Write("> ");
                tipo = Int16.Parse(Console.ReadLine());
            }

            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Saldo: ");
            double saldo = Double.Parse(Console.ReadLine());

            Console.Write("Crédito: ");
            double credito = Double.Parse(Console.ReadLine());

            Conta cf;
            string registro;
            if (tipo == 1)
            {
                Console.Write("CPF: ");
                registro = Console.ReadLine();
                cf = new ContaFisica((TipoConta)tipo, saldo, credito, nome, registro);
            }
            else
            {
                Console.Write("CNPJ: ");
                registro = Console.ReadLine();
                cf = new ContaJuridica((TipoConta)tipo, saldo, credito, nome, registro);
            }

            lc.Add(cf);
            ConsoleClear();
        }

        public static void Depositar()
        {
            ListarContas();
            Console.Write("Informe o número da conta: ");
            int conta = int.Parse(Console.ReadLine());

            Console.Write("Valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            Console.WriteLine("\nAntes do depósito");
            Console.WriteLine(lc[conta] + "\n");
            lc[conta].Depositar(valor);
            Console.WriteLine("\nDepois do depósito");
            Console.WriteLine(lc[conta]);

            Console.WriteLine();
        }
    }
}
