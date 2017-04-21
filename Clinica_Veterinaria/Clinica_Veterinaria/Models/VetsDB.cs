using System.Data.Entity;

namespace Clinica_Veterinaria.Models
{
    public class VetsDB : DbContext
    {
        //representar as tabelas a criar na BD
        public virtual DbSet<Donos> Donos { get; set; }
        public virtual DbSet<Animais> Animais { get; set; }
        public virtual DbSet<Veterinarios> Veterinarios { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }

        //especificar o local de criacao da BD
        public VetsDB() : base("LocalizacaoDaBD") { }

    }
}