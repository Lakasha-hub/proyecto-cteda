using System;

namespace tpfinal
{
    public class MinHeap : Heap
    {
        protected override bool Comparar(Proceso a, Proceso b)
        {
            return a.tiempo < b.tiempo;
        }
    }
}
