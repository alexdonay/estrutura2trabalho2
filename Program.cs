using estrutura2trabalho2;
public class Program
{
    private static void Main(string[] args)
    {
        Lista<int> list = new Lista<int>();
        list.InserirItens(4, 3, 2, 5, 6, 1);

        Console.WriteLine(list.ToString());
        list.Ordenar(list);
        Console.WriteLine(list.ToString());
        Lista<int>[] divida = list.Dividir();
        Console.WriteLine(divida[0].ToString());




    }
}