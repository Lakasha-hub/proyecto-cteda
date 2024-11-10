using System;

namespace tpfinal
{
    public abstract class Heap
    {
        protected List<Proceso> heap;

        public Heap()
        {
            heap = new List<Proceso>();
        }

        //Devuelve el indice del Padre de un Proceso
        protected int GetIndexPadre(int index) { return (index - 1) / 2; }

        //Devuelve el indice del Hijo Izquierdo de un Proceso
        protected int GetIndexHijoIzq(int index) { return index * 2 + 1; }

        //Devuelve el indice del Hijo Derecho de un Proceso
        protected int GetIndexHijoDer(int index) { return index * 2 + 2; }

        //Devuelve el tamaño de la heap
        public int Size() => heap.Count;

        //Verifica si la heap está vacía
        public bool EsVacia() => heap.Count == 0;

        //Verifica si el proceso es Hoja
        public bool EsHoja(int index) { return GetIndexHijoIzq(index) >= heap.Count; }

        //Calcula altura de la heap
        public int Altura() { return (int)Math.Floor(Math.Log2(heap.Count)); }

        //Intercambia la posicion entre dos nodos
        private void Intercambiar(int i, int j)
        {
            Proceso aux = heap[i];
            heap[i] = heap[j];
            heap[j] = aux;
        }

        //Aplica criterio de comparación segun estructura(MinHeap, MaxHeap)
        protected abstract bool Comparar(Proceso a, Proceso b);

        //Inserta un Proceso a la Heap
        public void Agregar(Proceso p)
        {
            heap.Add(p);
            FiltradoHaciaArriba(heap.Count - 1);
        }

        //Realiza el filtrado hacia arriba de un nodo, manteniendo la Propiedad Estructural
        private void FiltradoHaciaArriba(int index)
        {
            //Mientras el indice no este en la raiz y el criterio sea valido
            while (index != 0 && Comparar(heap[index], heap[GetIndexPadre(index)]))
            {
                //Si el criterio aplica, se realiza el intercambio con el Padre
                Intercambiar(index, GetIndexPadre(index));
                //Y se actualiza el indice para reevaluar
                index = GetIndexPadre(index);
            }
        }

        //Extrae el nodo raiz
        public Proceso Extraer()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap vacío");

            if (heap.Count == 1)
            {
                Proceso p = heap[0];
                heap.RemoveAt(0);
                return p;
            }

            //Si la heap tiene mas de un proceso:
            //Se extrae el proceso raiz
            Proceso raiz = heap[0];
            //Se coloca el ultimo Proceso como Raiz
            heap[0] = heap[heap.Count - 1];
            //Se elimina el duplicado
            heap.RemoveAt(heap.Count - 1);
            //Y se Realiza un filtrado hacia abajo de la nueva raiz
            FiltradoHaciaAbajo(0);

            return raiz;
        }

        //Realiza el filtrado hacia abajo de un nodo, manteniendo la Propiedad Estructural
        private void FiltradoHaciaAbajo(int index)
        {
            int sizeHeap = heap.Count;
            while (true)
            {
                int actual = index;
                int iHijoIzq = GetIndexHijoIzq(index);
                int iHijoDer = GetIndexHijoDer(index);

                //Compara el hijo Izq con el nodo actual utilizando criterio
                if (iHijoIzq < sizeHeap && Comparar(heap[iHijoIzq], heap[actual]))
                {
                    actual = iHijoIzq;
                }

                //Compara el hijo Der con el nodo actual utilizando criterio
                if (iHijoDer < sizeHeap && Comparar(heap[iHijoDer], heap[actual]))
                {
                    actual = iHijoDer;
                }

                //Si no hubo cambios, se termina el bucle, el arbol está ordenado
                if (actual == index)
                    break;

                //Si hubo cambios, se intercambia el nodo actual con uno de sus hijos
                Intercambiar(index, actual);
                //Y luego se actualiza el indice
                index = actual;
            }
        }

        //Retorna el nivel del Proceso en la heap
        public int NivelProceso(int index)
        {
            if(index < 0 || index >= heap.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "indice fuera de rango");

            return (int)Math.Floor(Math.Log2(index + 1));
        }

        //Devuelve los Procesos Hojas en una lista
        public List<Proceso> ListaHojas()
        {
            List<Proceso> listaHojas = new List<Proceso>();

            for(int i = 0; i < heap.Count; i++)
            {
                if (EsHoja(i))
                    listaHojas.Add(heap[i]);
            }
            return listaHojas;
        }

        //Imprimir procesos de la heap
        public string ToStr()
        {
            string result = "";

            for(int i = 0; i < heap.Count; i++)
            {
                Proceso p = heap[i];
                result += p.ToString() + " Nivel: " + NivelProceso(i) + "\n";
            }
            return result;
        }
    }
}
