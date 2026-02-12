
namespace Exercício3
{
    public class Pessoa
    {
    public string Nome="";

    public int Idade;

    public void DefinirIdade(int valor)
    {
        if (valor > 0)
        {
            Idade = valor;
        }
        else
        {
            Console.WriteLine("Idade inválida! A idade deve ser maior que zero.");
        }
    }

    public void ExibirDados()
    {
    Console.WriteLine($"Nome: {Nome}");
    Console.WriteLine($"Idade: {Idade}");
    }
    }
}