using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Razor.Models
{
    public class ComidaDBContext : DbContext
    {
        ComidaDBContext(DbContextOptions<ComidaDBContext> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<TipoComidaModel> TipoComidas { get; set; } 
        public DbSet<PersonaModel> Personas { get; set; }
        public DbSet<ComidaModel> Comidas { get; set; }
    }
}
