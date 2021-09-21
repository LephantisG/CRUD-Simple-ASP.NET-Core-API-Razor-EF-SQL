using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Razor.Models
{
    [Table("TipoComidas")]
    public class TipoComidaModel
    {
        [Key]
        public int TipoComidaId { get; private set; }
        public string Tipo { get; set; }
        public string Color { get; set; }
    }
}
