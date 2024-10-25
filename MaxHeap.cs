using System;

namespace tpfinal
{
    public class MaxHeap : Heap
    {
        protected override bool Comparar(Proceso a, Proceso b)
        {
            return a.prioridad > b.prioridad;
        }
    }
}
