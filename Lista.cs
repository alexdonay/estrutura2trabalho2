using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estrutura2trabalho2
{
    public class Lista<T>
    {
        public Lista() { }
        private Nodo<T>? Root { get; set; }
        public override string ToString()
        {
            string str = string.Empty;
            try
            {
                if (Root == null)
                {
                    throw new Exception("a lista está vazia");
                }
                str = Root.ToString();
                Nodo<T> actNodo = Root;
                while(actNodo.NextNodo != null)
                    {
                        actNodo = actNodo.NextNodo;
                        str = $"{str},  {actNodo.ToString()}";
                    }
           
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return str;
        }
        public void AddNodo(T value)
        {
            Nodo<T> NewNodo = new(value);
            if (this.Root == null)
            {
                this.Root = NewNodo;
            }
            else
            {
                Nodo<T>? auxNodo = this.Root;
                while (auxNodo?.NextNodo != null)  auxNodo = auxNodo.NextNodo;
                auxNodo.NextNodo = NewNodo;
                NewNodo.LastNodo = auxNodo;
            }
        }
        public Nodo<T> FindIndex(int index)
        {
            try
            {
            Nodo<T>? auxNodo = this.Root;
                for (int i = 0; i < index; i++)
                {
                    if (auxNodo == null)
                    {
                        throw new Exception("nodo não encontrado");
                    }
                auxNodo = auxNodo.NextNodo;
            }
                return auxNodo;

            
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new Nodo<T>();
            }
        }
        public void RemoveNodo(int value)
        {
            try
            {
                if (this.Root == null)
                {
                    throw new Exception("A lista está vazia");
                }
               
               if (this.Root.Comparer(value))
                    {
                    this.Root = this.Root.NextNodo;
                    return;
               }
               Nodo<T> auxNodo = this.Root;
                while(auxNodo != null)
                {
                    Console.WriteLine("loop");
                    
                    if (auxNodo.Comparer(value))
                    {
                        if(auxNodo.NextNodo == null)
                        {
                            auxNodo.LastNodo.NextNodo = null;
                            return;
                        }
                        else
                        {
                            auxNodo.LastNodo.NextNodo = auxNodo.NextNodo;
                            auxNodo.NextNodo.LastNodo = auxNodo.LastNodo;
                            return;
                        }
                    }
                    auxNodo = auxNodo.NextNodo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
         public  int ContarElementos()
 {
     int numNodos = 0;
     if(this.Root == null)
     {
         return 0;
     }
     
     if(this.Root.NextNodo == null)
     {
         return 1;
     }
     Nodo<T>? nextNodo = this.Root;
     while (nextNodo != null)
     {
         nextNodo = nextNodo?.NextNodo;
         numNodos = numNodos+1;
     }
     return numNodos;
       }
       public void InserirNoInicio(T Value)
{
    if(this.Root == null)
    {
        this.Root = new Nodo<T>(Value);
    }
    else
    {
        Nodo<T> auxNodo = this.Root;
        auxNodo.NextNodo = this.Root;
        this.Root = auxNodo;
    }
}
    }
}
