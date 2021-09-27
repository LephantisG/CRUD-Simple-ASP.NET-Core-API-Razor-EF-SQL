using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Razor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Models.PersonaModel> lista;
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                lista = (from p in db.Personas select p).ToList();
            }
            return View(lista);
        }

        [HttpGet("json")]
        public ActionResult Get()
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                var lista = (from p in db.Personas select p).ToList();
                return Ok(lista);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.Persona.PersonaRequest personaRequest)
        {
            using(Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.PersonaModel oPersonaModel = new Models.PersonaModel();
                oPersonaModel.Nombre = personaRequest.Nombre;
                oPersonaModel.Puntaje = personaRequest.Puntaje;
                oPersonaModel.ComidaId = personaRequest.ComidaId;
                db.Add(oPersonaModel);
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.Persona.PersonaEditRequest personaRequest)
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.PersonaModel oPersonaModel = db.Personas.Find(personaRequest.PersonaId);
                oPersonaModel.Nombre = personaRequest.Nombre;
                oPersonaModel.Puntaje = personaRequest.Puntaje;
                oPersonaModel.ComidaId = personaRequest.ComidaId;
                db.Entry(oPersonaModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.Persona.PersonaDeleteRequest personaRequest)
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.PersonaModel oPersonaModel = db.Personas.Find(personaRequest.PersonaId);
                db.Personas.Remove(oPersonaModel);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
