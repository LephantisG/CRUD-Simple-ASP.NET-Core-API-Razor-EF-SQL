﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Razor.Models.Request.Persona
{
    public class PersonaEditRequest
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public int Puntaje { get; set; }
        public int ComidaId { get; set; }
    }
}
