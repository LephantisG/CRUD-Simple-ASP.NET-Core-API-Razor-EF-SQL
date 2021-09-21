using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Razor.Models
{
    [Table("Comidas")]
    public class ComidaModel
    {
        [Key]
        public int ComidaId { get; private set; }
        public string Nombre { get; set; }
        public int Calorias { get; set; }
        [ForeignKey("TipoComida")]
        public int TipoComidaId { get; set; }
        //Navigation property
        public TipoComidaModel TipoComida { get; set; }
    }
}
