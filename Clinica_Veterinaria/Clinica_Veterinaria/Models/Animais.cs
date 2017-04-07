using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_Veterinaria.Models
{
    public class Animais
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
    }
}