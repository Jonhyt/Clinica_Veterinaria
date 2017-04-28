using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica_Veterinaria.Models
{
    public class Donos
    {
        // vai representar os dados da tabela dos DONOS

        // criar o construtor desta classe
        // e carregar a lista de Animais
        public Donos()
        {
            ListaDeAnimais = new HashSet<Animais>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //O pk não será auto-increment
        public int DonoID { get; set; }

        [Required(ErrorMessage = "{0} é de reenchimento obrigatorio")]
        [Display(Name = "Nome do Dono")]
        public string Nome { set; get; }

        [Required(ErrorMessage = "{0} é de reenchimento obrigatorio")]
        [Display(Name = "NIF do Dono")]
        public string NIF { get; set; }

        // especificar que um DONO tem muitos ANIMAIS
        public ICollection<Animais> ListaDeAnimais { get; set; }

    }
}