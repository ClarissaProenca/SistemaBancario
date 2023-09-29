namespace AT1 {
    public class Conta {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }

        public Conta() { }

        public Conta(int id, string nome, double saldo) {
            Id = id;
            Nome = nome;
            Saldo = saldo;
        }

        public override string ToString() { 
            return "Id conta: " + Id + "\nNome: " + Nome + "\nSaldo dispónível: " + Saldo;
        }
    }
}
