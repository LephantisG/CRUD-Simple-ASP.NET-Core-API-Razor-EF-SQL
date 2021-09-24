using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Razor.Models.Request.Comida
{
    public class ComidaEditRequest
    {
        public int ComidaId { get; set; }
        public string Nombre { get; set; }
        public int Calorias { get; set; }
        public int TipoComidaId { get; set; }
    }
}
