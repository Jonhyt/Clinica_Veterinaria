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
        [RegularExpression("[A-ZÍÂÓ][a-záéíóúàèìòùâêîôûäëïöüãõç']+((de|do|da|dos|das)?(-| )[A-ZÍÂÓ][a-záéíóúàèìòùâêîôûäëïöüãõç']+)*",ErrorMessage ="Por favor insira um nome valido")]
        public string Nome { set; get; }

        [Required(ErrorMessage = "{0} é de reenchimento obrigatorio")]
        [Display(Name = "NIF do Dono")]
        [RegularExpression("[0-9]{9}",ErrorMessage ="Por favor insira 9 carateres numéricos")]
        public string NIF { get; set; }

        // especificar que um DONO tem muitos ANIMAIS
        public ICollection<Animais> ListaDeAnimais { get; set; }

        // Ligar um Dono a uma conta
        public string UserName { get; set; }
        
    }
}