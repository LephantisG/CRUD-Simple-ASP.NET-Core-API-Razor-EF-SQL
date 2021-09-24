using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Razor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoComidaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                var lista = (from p in db.TipoComidas select p).ToList();
                return Ok(lista);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.TipoComida.TipoComidaRequest tipoComidaRequest)
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.TipoComidaModel oTipoComidaModel = new Models.TipoComidaModel();
                oTipoComidaModel.Tipo = tipoComidaRequest.Tipo;
                oTipoComidaModel.Color = tipoComidaRequest.Color;
                db.TipoComidas.Add(oTipoComidaModel);
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.TipoComida.TipoComidaEditRequest tipoComidaRequest)
        {
            using (Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.TipoComidaModel oTipoComidaModel = db.TipoComidas.Find(tipoComidaRequest.TipoComidaId);
                oTipoComidaModel.Tipo = tipoComidaRequest.Tipo;
                oTipoComidaModel.Color = tipoComidaRequest.Color;
                db.Entry(oTipoComidaModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.TipoComida.TipoComidaDeleteRequest tipoComidaRequest)
        {
            using(Models.ComidaDBContext db = new Models.ComidaDBContext())
            {
                Models.TipoComidaModel oTipoComidaModel = db.TipoComidas.Find(tipoComidaRequest.TipoComidaId);
                db.TipoComidas.Remove(oTipoComidaModel);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
