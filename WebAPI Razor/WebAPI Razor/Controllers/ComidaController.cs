using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Razor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComidaController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Models.ComidaModel> lista;
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                lista = (from p in db.Comidas select p).ToList();
            }
            return View(lista);
        }

        [HttpGet("json")]
        public ActionResult Get()
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                var lista = (from p in db.Comidas select p).ToList();
                return Ok(lista);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.Comida.ComidaRequest comidaRequest)
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.ComidaModel oComidaModel = new Models.ComidaModel();
                oComidaModel.Nombre = comidaRequest.Nombre;
                oComidaModel.Calorias = comidaRequest.Calorias;
                oComidaModel.TipoComidaId = comidaRequest.TipoComidaId;
                db.Add(oComidaModel);
                db.SaveChanges();
            }
                return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.Comida.ComidaEditRequest comidaRequest)
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.ComidaModel oComidaModel = db.Comidas.Find(comidaRequest.ComidaId);
                oComidaModel.Nombre = comidaRequest.Nombre;
                oComidaModel.Calorias = comidaRequest.Calorias;
                oComidaModel.TipoComidaId = comidaRequest.TipoComidaId;
                db.Entry(oComidaModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.Comida.ComidaDeleteRequest comidaRequest)
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.ComidaModel oComidaModel = db.Comidas.Find(comidaRequest.ComidaId);
                db.Comidas.Remove(oComidaModel);
                db.SaveChanges();
            }
            return Ok();
        }

    }
}
