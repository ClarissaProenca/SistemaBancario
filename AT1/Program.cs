using System;
using System.Collections.Generic;


namespace AT1 {
    public class Program {
        static int entrada = 0;
        static List<Conta> contas = new List<Conta>();

        static void Main(string[] args) {
            Persistencia.LerArquivo(contas);
            do {
                entrada = Util.Menu();
                switch (entrada) {
                    case 1:
                        CRUD.IncluirConta(contas);
                        break;
                    case 2:
                        CRUD.AlterarSaldo(contas);
                        break;
                    case 3:
                        CRUD.ExcluirConta(contas);
                        break;
                    case 4:
                        CRUD.GerarRelatorio(contas);
                        break;
                    default:
                        Console.WriteLine("Volte sempre");
                     break;
                }
            } while (entrada != 5);
            Persistencia.SalvaArquivo(contas);
        }
    }
}
