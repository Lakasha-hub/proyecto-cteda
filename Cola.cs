using System;
using System.Collections.Generic;

namespace tpfinal
{
    public class Cola<T>
    {


        private List<T> datos = new List<T>();

        public void encolar(T elem)
        {
            datos.Add(elem);
        }

        public T desencolar()
        {
            T temp = datos[0];
            datos.RemoveAt(0);
            return temp;
        }

        public T tope()
        {
            return datos[0];
        }

        public bool esVacia()
        {
            return datos.Count == 0;
        }

        public int cantidadElementos()
        {
            return datos.Count;
        }
    }
}
