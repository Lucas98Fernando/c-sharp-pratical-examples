class Exercicios
{
    public void Exercicio1()
    {
        Console.WriteLine("Exercício 1" + "\n");
        Console.WriteLine("Informe vários números em sequência: ");

        string? numbers = Console.ReadLine();
        string reverseNumbers = new string(numbers?.Reverse().ToArray());

        Console.WriteLine("Resultado:");
        Console.WriteLine(numbers + " => " + reverseNumbers);
    }

    public void Exercicio2()
    {
        Console.WriteLine("Exercício 2" + "\n");
        Console.WriteLine("Informe uma sequência de números separados por um espaço: ");

        string? numbers = Console.ReadLine();
        string[]? splitNumbers = numbers?.Split(" ");
        int higherNumber = 0;
        int sumAll = 0;

        if (splitNumbers != null)
        {
            foreach (var num in splitNumbers)
            {
                int currentNumber = int.Parse(num);

                if (currentNumber > higherNumber)
                {
                    higherNumber = currentNumber;
                }
                sumAll += currentNumber;
            }
        }

        Console.WriteLine("O maior número é " + higherNumber);
        Console.WriteLine("A soma dos valores é " + sumAll);
    }
}

class Leitor
{
    public string nome;
    public Livro livroFavorito;
    public List<Livro> estanteLivros;

    public Leitor(string nome, Livro livroFavorito, List<Livro> estanteLivros)
    {
        this.nome = nome;
        this.livroFavorito = livroFavorito;
        this.estanteLivros = estanteLivros;
    }

    public void adicionarLivro(Livro livro)
    {
        this.estanteLivros.Add(new Livro(livro.titulo, livro.qtdPaginas, livro.paginasLidas));
    }

    public void removerLivro(Livro livro)
    {
        var livroParaRemover = this.estanteLivros.SingleOrDefault(l => l.id == livro.id);
        if (livroParaRemover != null)
        {
            this.estanteLivros.Remove(livroParaRemover);
        }
        else
        {
            Console.WriteLine("Livro não encontrado");
        }
    }
}

class Livro
{
    public string id;
    public string titulo;
    public int qtdPaginas;
    public int paginasLidas;

    public Livro(string titulo, int qtdPaginas, int paginasLidas)
    {
        this.id = Guid.NewGuid().ToString("N");
        this.titulo = titulo;
        this.qtdPaginas = qtdPaginas;
        this.paginasLidas = paginasLidas;
    }

    public double verificarProgresso()
    {
        return this.paginasLidas * 100 / this.qtdPaginas;
    }

    public int adicionarPaginasLidas()
    {
        return this.paginasLidas;
    }
}

// class Ex1Ex2
// {
//     public static void Main()
//     {
//         Exercicios ex = new Exercicios();
//         ex.Exercicio1();
//         ex.Exercicio2();
//     }
// }

// class Biblioteca
// {
//     public static void Main()
//     {
//         Livro livro1 = new Livro("Clean Code", 60, 10);
//         Livro livro2 = new Livro("Design Patterns", 50, 25);
//         Livro livro3 = new Livro("SCRUM", 100, 20);
//         Livro livro4 = new Livro("C# Guia Prático", 70, 60);
//         Livro livro5 = new Livro("Clean Architecture", 220, 70);

//         Livro[] livrosLeitor1 = { livro1, livro4 };
//         Livro[] livrosLeitor2 = { livro2, livro3, livro5 };

//         Leitor leitor1 = new Leitor("Lucas", livro1, new List<Livro>(livrosLeitor1));
//         Leitor leitor2 = new Leitor("Maria", livro1, new List<Livro>(livrosLeitor2));

//         // Aqui será criada uma nova intância de Livro
//         leitor1.adicionarLivro(livro2);
//         leitor2.removerLivro(livro1);

//         Console.WriteLine("Dados do Leitor " + leitor1.nome + "\n");
//         foreach (var item in leitor1.estanteLivros.Select((value, i) => new { i, value }))
//         {
//             Console.WriteLine(item.i + 1 + "º " + "Livro na estante: " + item.value.titulo + " ( " + "Leitura " + item.value.verificarProgresso() + "% concluída)");
//         }

//         Console.WriteLine("\n");
//         Console.WriteLine("Dados do Leitor " + leitor2.nome + "\n");
//         foreach (var item in leitor2.estanteLivros.Select((value, i) => new { i, value }))
//         {
//             Console.WriteLine(item.i + 1 + "º " + "Livro na estante: " + item.value.titulo + " ( " + "Leitura " + item.value.verificarProgresso() + "% concluída)");
//         }
//     }
// }


public interface IBonificacao
{

    float calcularBonificacao();
}

abstract class Funcionario
{
    string? nome { get; set; }
    int idade { get; set; }
    float salario { get; set; }

    public abstract IBonificacao gerarBonificacao(float salario);

    public IBonificacao calculo()
    {
        return this.gerarBonificacao(this.salario);
    }
}

class FuncionarioGerente : Funcionario
{
    float salario;
    public FuncionarioGerente(float salario)
    {
        this.salario = salario;
    }
    public override IBonificacao gerarBonificacao(float salario)
    {
        return new Gerente(this.salario);
    }
}

class Gerente : IBonificacao
{
    float salario;
    public Gerente(float salario)
    {
        this.salario = salario;
    }
    public float calcularBonificacao()
    {
        Console.Write("O Gerente irá receber: R$ ");
        return this.salario + 10000.00F;
    }
}

class FuncionarioSupervisor : Funcionario
{
    float salario;
    public FuncionarioSupervisor(float salario)
    {
        this.salario = salario;
    }
    public override IBonificacao gerarBonificacao(float salario)
    {
        return new Supervisor(this.salario);
    }
}

class Supervisor : IBonificacao
{
    float salario;
    public Supervisor(float salario)
    {
        this.salario = salario;
    }
    public float calcularBonificacao()
    {
        Console.Write("O Supervisor irá receber: R$ ");
        return this.salario + 5000.00F;
    }
}

class FuncionarioVendedor : Funcionario
{

    float salario;
    public FuncionarioVendedor(float salario)
    {
        this.salario = salario;
    }
    public override IBonificacao gerarBonificacao(float salario)
    {
        return new Vendedor(this.salario);
    }
}

class Vendedor : IBonificacao
{
    float salario;
    public Vendedor(float salario)
    {
        this.salario = salario;
    }
    public float calcularBonificacao()
    {
        Console.Write("O Vendedor irá receber: R$ ");
        return this.salario + 3000.00F;
    }
}

class Client
{
    public void Main()
    {
        ClientCode(new FuncionarioGerente(3000));
        ClientCode(new FuncionarioSupervisor(2000));
        ClientCode(new FuncionarioVendedor(1000));
    }

    public void ClientCode(Funcionario funcionario)
    {
        Console.WriteLine(funcionario.calculo().calcularBonificacao());
    }
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
    }
}
