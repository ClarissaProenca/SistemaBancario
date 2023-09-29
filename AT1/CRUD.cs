using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AT1 {
    public static class CRUD {
        public static void IncluirConta(List<Conta> contas) {
            int id;
            Console.WriteLine("Inclusão de conta");
            Console.WriteLine("Informe o id da conta: ");
            if (!int.TryParse(Console.ReadLine(), out id)) {
                Console.WriteLine("Entre com um número inteiro válido.");
                return;
            }

            if (Util.VerificaContaExiste(contas, id)) {
                Console.WriteLine("Conta já registrada.");
                return;
            }

            Console.WriteLine("Informe o nome do dono da conta: ");
            string nome = Console.ReadLine();
            bool nomeOk = Regex.IsMatch(nome, @"^[\p{L}\p{M}']+ [\p{L}\p{M}']+$");
            //bool nomeOk = Regex.IsMatch(nome, @"^[a-zA-Z]+ [a-zA-Z]+$");
            if (!nomeOk) {
                Console.WriteLine("Nome precisa ser no formato 'Nome' 'Sobrenome'");
                return;
            }
            Console.WriteLine("Informe o saldo da conta: ");
            double saldo = double.Parse(Console.ReadLine());
            if (saldo >= 0)
            {
                contas.Add(new Conta(id, nome, saldo));
            }
            else
            {
                Console.WriteLine("Saldo inicial não pode ser menor ou igual a 0.");
            }
        }

        public static void AlterarSaldo(List<Conta> contas) {
            Console.WriteLine("Alterar Saldo");
            if (Util.ListaVazia(contas)) {
                Console.WriteLine("Não há contas cadastradas");
                return;
            }

            Console.WriteLine("Qual id da conta que deseja atualizar o saldo? ");
            int id = Int32.Parse(Console.ReadLine());
            if (!Util.VerificaContaExiste(contas, id))
            {
                Console.WriteLine("Essa conta não existe.");
                return;
            }
            Console.WriteLine("Qual transação deseja fazer? [1]Deposito [2]Saque");
            int opcao = Int32.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                Util.Deposito(contas, id);
            }
            else if (opcao == 2)
            {
                Util.Saque(contas, id);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        public static void ExcluirConta(List<Conta> contas) {
            Console.WriteLine("Exclusão de conta");
            if (Util.ListaVazia(contas)) {
                Console.WriteLine("Não há contas cadastradas");
                return;
            }
            Console.WriteLine("Qual id da conta que deseja excluir? ");
            if (int.TryParse(Console.ReadLine(), out int id)) {
                Conta contaExclusao = Util.RetornaConta(contas, id);
                if (!Util.VerificaContaExiste(contas, id)) {
                    Console.WriteLine("Essa conta não existe.");
                    return;
                }

                if (contaExclusao.Saldo != 0) {
                    Console.WriteLine("Ainda há saldo nessa conta, não é possível excluí-la");
                    return;
                } 

                contas.Remove(contaExclusao);
                Console.WriteLine("Conta excluída com sucesso");

            } else {
                Console.WriteLine("Insira apenas números reais");
            }
        }
        public static void GerarRelatorio(List<Conta> contas)
        {
            Console.WriteLine("Gerar Relatório");
            if (Util.ListaVazia(contas))
            {
                Console.WriteLine("Não há contas cadastradas");
            }
            else
            {
                Console.WriteLine("Qual relatório deseja gerar? \n[1]Listar Clientes com saldo negativo\n[2]Listar contas acima de valor especificado\n[3]Listar todas as contas");
                int relatorio = Int32.Parse(Console.ReadLine());
                switch (relatorio)
                {
                    case 1:
                        Util.ListarSaldosNegativos(contas);
                        break;
                    case 2:
                        Util.ListarSaldosAcima(contas);
                        break;
                    case 3:
                        Util.ListarContas(contas);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
            }
        }
    }
}
