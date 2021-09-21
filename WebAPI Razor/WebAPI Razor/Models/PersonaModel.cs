using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Razor.Models
{
    [Table("Personas")]
    public class PersonaModel
    {
        [Key]
        public int PersonaId { get; private set; }
        public string Nombre { get; set; }
        public int Puntaje { get; set; }
        [ForeignKey("Comida")]
        public int ComidaId { get; set; }
        //Navigation property
        public ComidaModel Comida { get; set; }
    }
}
