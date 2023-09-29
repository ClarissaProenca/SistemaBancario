using System;
using System.Collections.Generic;
using System.IO;

namespace AT1 {
    public static class Persistencia {
        const String NOME_ARQUIVO = "contas.csv";
        static string diretorio = @"C:\Users\clari\source\repos\AT1";
        public static void SalvaArquivo(List<Conta> contas)
        {
            string caminho = Path.Combine(diretorio, NOME_ARQUIVO);
            try
            {
                using (StreamWriter arquivoContas = new StreamWriter(caminho))
                {
                    foreach (Conta conta in contas)
                    {
                        arquivoContas.WriteLine($"{conta.Id};{conta.Nome};{conta.Saldo}");
                    }
                    Console.WriteLine("Contas salvas com sucesso.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public static List<Conta> LerArquivo(List<Conta> contas)
        {
            string caminho = Path.Combine(diretorio, NOME_ARQUIVO);

            if (!File.Exists(caminho))
            {
                Console.WriteLine("Arquivo " + NOME_ARQUIVO + " não existe.");
            }

            try
            {
                using (var arquivo = new StreamReader(caminho))
                {
                    string linha = arquivo.ReadLine();

                    while (linha != null)
                    {
                        string[] campos = linha.Split(';');
                        Conta conta = new Conta(int.Parse(campos[0]), campos[1], double.Parse(campos[2]));
                        contas.Add(conta);
                        linha = arquivo.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return contas;
        }
    }
}
