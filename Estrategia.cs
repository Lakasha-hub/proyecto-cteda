
using System;
using System.Collections.Generic;
using System.Numerics;

namespace tpfinal
{

    public class Estrategia
    {

        public String Consulta1(List<Proceso> datos)
        {
            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();

            foreach(Proceso p in datos)
            {
                minHeap.Agregar(p);
                maxHeap.Agregar(p);
            }

            List<Proceso> listaSJF = minHeap.ListaHojas();
            List<Proceso> listaPPCSA = maxHeap.ListaHojas();

            string resutl = "------------------------ Procesos Hojas (SJF): ------------------------\n";
            foreach (Proceso p in listaSJF)
            {
                resutl += p.ToString() + "\n";
            }

            resutl += "------------------------ Procesos Hojas (PPCSA): ------------------------\n";
            foreach (Proceso p in listaPPCSA)
            {
                resutl += p.ToString() + "\n";
            }

            return resutl;
        }

        public String Consulta2(List<Proceso> datos)
        {
            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();

            foreach (Proceso p in datos)
            {
                minHeap.Agregar(p);
                maxHeap.Agregar(p);
            }

            string resutl = "Altura de Heap ordenada por (SJF): ";
            resutl += minHeap.Altura() + "\n";


            resutl += "Altura de Heap ordenada por (PPCSA): ";
            resutl += maxHeap.Altura();

            return resutl;
        }



        public String Consulta3(List<Proceso> datos)
        {
            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();

            foreach (Proceso p in datos)
            {
                minHeap.Agregar(p);
                maxHeap.Agregar(p);
            }

            string resutl = "------------------------ Procesos (SJF): ------------------------\n";
            resutl += minHeap.ToStr();

            resutl += "------------------------ Procesos (PPCSA): ------------------------\n";
            resutl += maxHeap.ToStr();

            return resutl;
        }


        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {
            MinHeap minHeap = new MinHeap();

            foreach(Proceso p in datos)
            {
                minHeap.Agregar(p);
            }

            for(int i = 0;  i < datos.Count; i++)
            {
                Proceso p = minHeap.Extraer();
                collected.Add(p);
            }
            
        }


        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
            MaxHeap maxHeap = new MaxHeap();

            foreach (Proceso p in datos)
            {
                maxHeap.Agregar(p);
            }

            for (int i = 0; i < datos.Count; i++)
            {
                Proceso p = maxHeap.Extraer();
                collected.Add(p);
            }
        }
        
    }
}