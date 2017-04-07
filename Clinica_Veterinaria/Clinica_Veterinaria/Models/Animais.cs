using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        //Criação da chave forasteira
        [ForeignKey("DonoFK")]
        public Donos Dono { get; set; } //relacionar, pelo C#, com a tabela Dono
        public int DonoFK { get; set; } //relacionar, pelo SQL, com a tabela Dono
        
    }
}