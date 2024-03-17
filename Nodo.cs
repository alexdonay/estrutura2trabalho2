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
        public Boolean EqualsValue<T>(T value) 
        {
            return EqualityComparer<T>.Equals(value, this.Value);
        }
        public bool Equals(Nodo<T> nodo)
        {
            bool valueEquals = EqualityComparer<T>.Default.Equals(this.Value, nodo.Value);
            bool nextNodoEquals = (this.NextNodo == null && nodo.NextNodo == null) || (this.NextNodo != null && nodo.NextNodo != null && EqualityComparer<T>.Default.Equals(this.NextNodo.Value, nodo.NextNodo.Value));
            bool lastNodoEquals = (this.LastNodo == null && nodo.LastNodo == null) || (this.LastNodo != null && nodo.LastNodo != null && EqualityComparer<T>.Default.Equals(this.LastNodo.Value, nodo.LastNodo.Value));

            return valueEquals && nextNodoEquals && lastNodoEquals;
        }
        public bool Greater<T>(T value)
        {
            if (value is IComparable<T>)
            {
                return ((IComparable<T>)this.Value).CompareTo(value) > 0;
            }
            else
            {
                throw new ArgumentException("Tipo T não implementa a interface IComparable<T>");
            }
        }
        public Nodo() { }
        public Nodo(T value)
        {
            Value = value;
        }
    }
}
