using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Encuesta
    {
        public bool UsaBicicleta { get; set; }
        public bool UsaAuto {  get; set; }
        public bool UsaTransPub { get; set; }
        public string Email { get; set; }
        public double DistanciaASuDestino { get; set; }
    }
}
