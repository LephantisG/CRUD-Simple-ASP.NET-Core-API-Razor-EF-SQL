using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Razor.Models.Request.TipoComida
{
    public class TipoComidaEditRequest
    {
        public int TipoComidaId { get; set; }
        public string Tipo { get; set; }
        public string Color { get; set; }
    }
}
