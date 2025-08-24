using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio1.Models
{
    public class ProcesoEncuestas
    {
        ArrayList contactables = new ArrayList();

        int cantBicleta;
        int cantAuto;
        int cantTranspPub;
        int cantEncuestas;

        public int CantContactables { get { return contactables.Count; } }
        public double PorcBicicleta 
        { 
            get 
            {
                double porc = 0;
                if (cantEncuestas > 0)
                {
                    porc = 100 * cantBicleta / cantEncuestas;
                }
                return porc;
            } 
        }
        public double PorcAuto 
        {
            get
            {
                double porc = 0;
                if (cantEncuestas > 0)
                {
                    porc = 100 * cantAuto / cantEncuestas;
                }
                return porc;
            }
        }
        public double PorcTransPub 
        {
            get
            {
                double porc = 0;
                if (cantEncuestas > 0)
                {
                    porc = 100 * cantTranspPub / cantEncuestas;
                }
                return porc;
            }
        }

        public ProcesoEncuestas()
        {
            contactables = new ArrayList();
        }

        public void RegistrarEncuesta (Encuesta encuesta, bool puedeSerContactado) 
        {
            cantEncuestas++;

            if (encuesta.UsaBicicleta) 
            {
                cantBicleta++;
            }
            else if (encuesta.UsaTransPub) 
            {
                cantTranspPub++;
            }
            else 
            {
                cantAuto++;
            }

            if (puedeSerContactado == true)
            {
                contactables.Add(encuesta);
            }
        }

        public Encuesta VerContactable (int idx) 
        {
            Encuesta buscado = null;
            if (idx >= 0 && idx < CantContactables)
            {
                buscado = contactables[idx] as Encuesta;
            }
            return buscado;
        }

        public void OrdenarEncuestables()
        {
            QuickSort(contactables, 0, CantContactables - 1);
        }

        void QuickSort(ArrayList lista, int inicio, int fin)
        {
            if (fin >= inicio)
            {
                Encuesta p = lista[inicio] as Encuesta;
                int m = inicio + 1;
                int n = fin;

                while (m <= n)
                {
                    while (m <= fin && p.DistanciaASuDestino >= (lista[m] as Encuesta).DistanciaASuDestino) m++;
                    while (n > inicio && p.DistanciaASuDestino <= (lista[n] as Encuesta).DistanciaASuDestino) n--;

                    if (m < n)
                    {
                        object aux = lista[m];
                        lista[m] = lista[n];
                        lista[n] = aux;
                    }
                }
                lista[inicio] = lista[n];
                lista[n] = p;

                if (inicio < n - 1)
                    QuickSort(lista, inicio, n - 1);
                if (n + 1 < fin)
                    QuickSort(lista, n + 1, fin);
            }
        }
    }
}
