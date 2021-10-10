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

        [HttpGet]
        public ActionResult Index(Models.ComidaDBContext db)
        {
            IEnumerable<Models.TipoComidaModel> lista;
            lista = (from p in db.TipoComidas select p).ToList();
            return View(lista);
        }

        [HttpGet("json")]
        public ActionResult GetJson(Models.ComidaDBContext db)
        {
            var lista = (from p in db.TipoComidas select p).ToList();
            return Ok(lista);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Models.Request.TipoComida.TipoComidaRequest tipoComidaRequest, Models.ComidaDBContext db)
        {
            Models.TipoComidaModel oTipoComidaModel = new Models.TipoComidaModel();
            oTipoComidaModel.Tipo = tipoComidaRequest.Tipo;
            oTipoComidaModel.Color = tipoComidaRequest.Color;
            db.TipoComidas.Add(oTipoComidaModel);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost("json")]
        public ActionResult Post([FromBody] Models.Request.TipoComida.TipoComidaRequest tipoComidaRequest, Models.ComidaDBContext db)
        {
            Models.TipoComidaModel oTipoComidaModel = new Models.TipoComidaModel();
            oTipoComidaModel.Tipo = tipoComidaRequest.Tipo;
            oTipoComidaModel.Color = tipoComidaRequest.Color;
            db.TipoComidas.Add(oTipoComidaModel);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet("Edit/{id}")]
        public ActionResult Edit([FromRoute]int id, Models.ComidaDBContext db)
        {
            Models.TipoComidaModel oTipoComidaModel = db.TipoComidas.Find(id);
            return View(oTipoComidaModel);
        }

        [HttpPut("Edit")]
        public ActionResult Put(Models.TipoComidaModel oModel, Models.ComidaDBContext db)
        {
            //Models.Request.TipoComida.TipoComidaDeleteRequest tempTipoComidaModel = new Models.Request.TipoComida.TipoComidaDeleteRequest();
            //tempTipoComidaModel.TipoComidaId = (int)TempData["tempTipoComidaId"];
            Models.TipoComidaModel oTipoComidaModel = db.TipoComidas.Find(oModel.TipoComidaId);
            oTipoComidaModel.Tipo = oModel.Tipo;
            oTipoComidaModel.Color = oModel.Color;
            db.Entry(oTipoComidaModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.TipoComida.TipoComidaDeleteRequest tipoComidaRequest, Models.ComidaDBContext db)
        {
            Models.TipoComidaModel oTipoComidaModel = db.TipoComidas.Find(tipoComidaRequest.TipoComidaId);
            db.TipoComidas.Remove(oTipoComidaModel);
            db.SaveChanges();
            return Ok();
        }
    }
}
