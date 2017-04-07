using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clinica_Veterinaria.Models
{
    public class VetsDB : DbContext
    {
        //representar as tabelas a criar na BD
        public virtual DbSet<Donos> Donos { get; set; }
        public virtual DbSet<Animais> Animais { get; set; }

        //especificar o local de criacao da BD
        public VetsDB() : base("LocalizacaoDaBD") { }

    }
}