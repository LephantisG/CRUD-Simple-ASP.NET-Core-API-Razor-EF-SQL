using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Razor.Models
{
    public class ComidaDBContext : DbContext
    {
        public DbSet<TipoComidaModel> TipoComidas { get; set; }
        public DbSet<PersonaModel> Personas { get; set; }
        public DbSet<ComidaModel> Comidas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4CF079O\sqlexpress;Initial Catalog=CrudComidaDB;Integrated Security=True");
        }
    }
}
