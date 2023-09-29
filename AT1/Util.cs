using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AT1 {
    public static class Util {
        public static int Menu() {
            int entrada = 0;
            try {
                Console.WriteLine("Informe a operação que deseja realizar: ");
                Console.WriteLine("[1] Inclusão de conta" +
                    "\n[2] Alteração de saldo" +
                    "\n[3] Exclusão de conta" +
                    "\n[4] Relatórios gerenciais" +
                    "\n[5] Encerrar programa");
                entrada = Int32.Parse(Console.ReadLine());
                //rotina de entrada de int
            } catch (System.FormatException f) {
                Console.WriteLine("Por favor insira um número inteiro" + "\n\nErro: " + f.Message);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return entrada;
        }

        public static bool ListaVazia(List<Conta> contas) {
            if (contas.Count == 0) {
                return true; //se estiver vazia retorna true
            }
            return false; // se houver algo retorna false
        }

        public static Conta RetornaConta(List<Conta> contas, int id) {
            foreach (Conta conta in contas) {
                if (conta.Id == id) {
                    return conta;
                }
            }
            return null;
        }
        
        public static bool VerificaContaExiste(List<Conta> contas, int id) {
            for (int i = 0; i < contas.Count; i++) {
                if (contas[i].Id == id) {
                    return true;
                }
            }
            return false;
        }

        public static bool VerificaValor(double valor) {
            if (valor >= 0) {
                return true;
            }
            return false;   
        }

        public static void Deposito(List<Conta> contas, int id) {
            Console.WriteLine("[1] Depósito");
            Console.WriteLine("Qual valor deseja depositar? ");
            double deposito = double.Parse(Console.ReadLine());
            if (!VerificaValor(deposito)) {
                Console.WriteLine("Informe valor maior que zero");
                return;
            }
            Conta contaDeposito = RetornaConta(contas, id);
            contaDeposito.Saldo += deposito;
            /*
            for (int i = 0; i < contas.Count; i++) {
                if (contas[i].Id == id) {
                    contas[i].Saldo += deposito;
                }
            }*/
        }

        public static void Saque(List<Conta> contas, int id) {
            Console.WriteLine("[2] Saque");
            Console.WriteLine("Qual valor deseja sacar? ");
            double saque = double.Parse(Console.ReadLine());//metodo
            if (!VerificaValor(saque)) {
                Console.WriteLine("Informe valor maior que zero");
                return;
            }
            Conta contaSaque = RetornaConta(contas, id);
            contaSaque.Saldo -= saque;
            /*
            for (int i = 0; i < contas.Count; i++) {
                if (contas[i].Id == id) {
                    contas[i].Saldo -= saque;
                }
            }*/
        }

        public static void ListarSaldosNegativos(List<Conta> contas) {
            for (int i = 0; i < contas.Count; i++) {
                if (contas[i].Saldo < 0) { 
                    Console.WriteLine("\n" + contas[i].ToString() + "\n");
                }
            }
        }

        public static void ListarSaldosAcima(List<Conta> contas) {
            Console.WriteLine("Qual valor deseja consultar?");
            double valor = double.Parse(Console.ReadLine());
            bool encontrouConta = false;
            foreach (Conta conta in contas) {
                if (conta.Saldo > valor) { 
                    Console.WriteLine("\n" + conta.ToString() + "\n");
                }
            }
            if (!encontrouConta) {
                Console.WriteLine("Nenhuma conta com saldo acima do valor especificado foi encontrada.");
            }
        }

        public static void ListarContas(List<Conta> contas) {
            foreach (Conta conta in contas) {
                Console.WriteLine("\n" + conta.ToString() + "\n");
            }
        }
    }
}
