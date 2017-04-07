using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica_Veterinaria.Models
{
    public class Donos
    {   
        //Definir um construtor para carregar o atributo ListaDeAnimais
        public Donos()
        {
            ListaDeAnimais = new HashSet<Animais>();
        }

        public int DonosID { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }

        //indica o relacionamento entre donos e Animais
        //Um dono tem muitos animais
        public virtual ICollection<Animais> ListaDeAnimais { get; set; }
    }
}