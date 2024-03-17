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
                while (actNodo.NextNodo != null)
                {
                    actNodo = actNodo.NextNodo;
                    str = $"{str},  {actNodo.ToString()}";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return str;
        }
        public void Inserir(T value)
        {
            Nodo<T> NewNodo = new(value);
            if (this.Root == null)
            {
                this.Root = NewNodo;
            }
            else
            {
                Nodo<T>? auxNodo = this.Root;
                while (auxNodo?.NextNodo != null) auxNodo = auxNodo.NextNodo;
                auxNodo.NextNodo = NewNodo;
                NewNodo.LastNodo = auxNodo;
            }
        }
        public int ContarElementos()
        {
            int numNodos = 0;
            if (this.Root == null)
            {
                return 0;
            }

            if (this.Root.NextNodo == null)
            {
                return 1;
            }
            Nodo<T>? nextNodo = this.Root;
            while (nextNodo != null)
            {
                nextNodo = nextNodo?.NextNodo;
                numNodos = numNodos + 1;
            }
            return numNodos;
        }
        public bool Buscar(T value)
        {
            Nodo<T>? actNodo = this.Root;
            while (actNodo != null)
            {
                if (actNodo.EqualsValue(value))
                {
                    return true;
                }
                actNodo = actNodo.NextNodo;
            }
            return false;
        }
        public void InserirNoInicio(T Value)
        {
            if (this.Root == null)
            {
                this.Root = new Nodo<T>(Value);
            }
            else
            {
                Nodo<T> auxNodo = this.Root;
                this.Root = new Nodo<T>(Value);
                this.Root.NextNodo = auxNodo;
                auxNodo.LastNodo = this.Root;
            }
        }
        public void Inverter()
        {
            try
            {
                if (this.Root == null)
                {
                    throw new Exception("A lista está vazia");
                }

                Nodo<T> actNodo = this.Root;
                Nodo<T> lastNodo = null;

                while (actNodo != null)
                {
                    Nodo<T> nextNodo = actNodo.NextNodo;
                    actNodo.NextNodo = lastNodo;
                    lastNodo = actNodo;
                    actNodo = nextNodo;
                }

                this.Root = lastNodo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Concatenar(Lista<T> lista)
        {
            Nodo<T>? lastNodo = this.Root;
            if (lista.Count() > 0)
            {

                while (lastNodo.NextNodo != null)
                {
                    lastNodo = lastNodo.NextNodo;
                }
                lastNodo.NextNodo = lista.Root;
                lastNodo.NextNodo.LastNodo = lastNodo.NextNodo;

            }
        }
        public void RemoverDuplicadas()
        {
            Nodo<T> actnodo = this.Root;
            while (actnodo != null)
            {

                if (this.ContarIguais(actnodo.Value) > 1)
                {
                    this.RemoveNodo(actnodo.Value);
                }
                actnodo = actnodo.NextNodo;
            }

        }
        public Lista<T> Intersecao(Lista<T> comparableList)
        {
            Lista<T> novaLista = new Lista<T>();
            Nodo<T> actNodo = comparableList.Root;
            while (actNodo != null)
            {

                if (this.ContarIguais(actNodo.Value) > 0)
                {
                    novaLista.Inserir(actNodo.Value);
                }
                actNodo = actNodo.NextNodo;
            }
            novaLista.RemoverDuplicadas();
            return (novaLista);
        }
        public void RemoveNodo(T value)
        {
            try
            {
                if (this.Root == null)
                {
                    throw new Exception("A lista está vazia");
                }

                if (this.Root.EqualsValue(value))
                {
                    this.Root = this.Root.NextNodo;
                    return;
                }
                Nodo<T> auxNodo = this.Root;
                while (auxNodo != null)
                {
                    if (auxNodo.EqualsValue(value))
                    {
                        if (auxNodo.NextNodo == null)
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
        public int ContarIguais(T value)
        {
            Nodo<T> comparerNodo = new Nodo<T>(value);
            Nodo<T> actnodo = this.Root;
            int counter = 0;
            while (actnodo != null)
            {
                if (comparerNodo != actnodo)
                {
                    if (actnodo.EqualsValue(value))
                    {
                        counter++;
                    }
                }

                actnodo = actnodo.NextNodo;
            }
            return counter;
        }
        public Nodo<T> GetNodoByIndex(int index)
        {
            Nodo<T> actNodo = this.Root;
            for (int i = 1; i <= index; i++)
            {
                actNodo = actNodo.NextNodo;
            }
            return actNodo;
        }
        public void Ordenar(Lista<T> unorderList)
        {
            if (unorderList.Count() <= 1)
            {
                return;
            }

            double contarElementos = unorderList.Count() / 2;
            int pivoIndex = (int)Math.Round(contarElementos);
            Nodo<T> pivoNodo = unorderList.GetNodoByIndex(pivoIndex);

            Lista<T> leftList = new Lista<T>();
            Lista<T> rightList = new Lista<T>();

            Nodo<T> actNodo = unorderList.Root;
            while (actNodo != null)
            {
                Nodo<T> nextNodo = actNodo.NextNodo;
                if (!actNodo.Equals(pivoNodo))
                {
                    if (actNodo.Greater(pivoNodo.Value))
                    {
                        leftList.Inserir(actNodo.Value);
                    }
                    else
                    {
                        rightList.Inserir(actNodo.Value);
                    }
                }
                actNodo = nextNodo;
            }


            leftList.Ordenar(leftList);
            rightList.Ordenar(rightList);
            unorderList = rightList;
            unorderList.Inserir(pivoNodo.Value);
            unorderList.Concatenar(leftList);
            this.Root = unorderList.Root;

        }
        public int Count()
        {
            int count = 0;
            Nodo<T> actNodo = this.Root;
            while (actNodo != null)
            {
                count++;
                actNodo = actNodo.NextNodo;
            }
            return count;
        }
        public Lista<T>[] Dividir()
        {
            if (this.Root == null || this.Root.NextNodo == null)
            {
                return new Lista<T>[] { this, new Lista<T>() };
            }

            var lista1 = new Lista<T>();
            var lista2 = new Lista<T>();

            Nodo<T> rapido = this.Root;
            Nodo<T> lento = this.Root;

            while (rapido != null && rapido.NextNodo != null)
            {
                rapido = rapido.NextNodo.NextNodo;
                lento = lento.NextNodo;
            }

            lista2.Root  = lento.NextNodo;
            lista2.Root.LastNodo = null;

            lista1.Root = this.Root;
            lento.LastNodo.NextNodo = null;

            this.Root = null;

            return new Lista<T>[] { lista1, lista2 };
        }
        public void InserirItens(params T[] args)
        {
            foreach(T item in args)
            {
                this.Inserir(item);
            }
        }
    }
}

