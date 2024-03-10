using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estrutura2trabalho2
{
    public class Nodo<T>
    {
        public T Value { get; set;}
        public Nodo<T>? LastNodo { get; set; }
        public Nodo<T>? NextNodo { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
        public Boolean Comparer<T>(T value) 
        {
            return EqualityComparer<T>.Equals(value, this.Value);
        }
        public Nodo() { }
        public Nodo(T value)
        {
            Value = value;
        }
    }
}
