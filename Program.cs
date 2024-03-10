using estrutura2trabalho2;
public class Program
{
    private static void Main(string[] args)
    {
        Lista<int> list = new Lista<int>();

        list.AddNodo(1);

        list.AddNodo(2);
        list.AddNodo(3);
        list.AddNodo(4);
        list.AddNodo(5);
        Console.WriteLine(list.ToString());
        list.RemoveNodo(2);
        list.RemoveNodo(1);
        Console.WriteLine(list.ToString());
    }
}