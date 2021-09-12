using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using gametask_back_api;

namespace gametask_back_api.Controllers
{
    public class TarefaController : ApiController
    {
        private gametaskEntities db = new gametaskEntities();

        // GET: api/Tarefa
        public IQueryable<gm_tarefa> Getgm_tarefa()
        {
            return db.gm_tarefa;
        }

        // GET: api/Tarefa/5
        [ResponseType(typeof(gm_tarefa))]
        public IHttpActionResult Getgm_tarefa(int id)
        {
            gm_tarefa gm_tarefa = db.gm_tarefa.Find(id);
            if (gm_tarefa == null)
            {
                return NotFound();
            }

            return Ok(gm_tarefa);
        }

        // PUT: api/Tarefa/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgm_tarefa(int id, gm_tarefa gm_tarefa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gm_tarefa.id)
            {
                return BadRequest();
            }

            db.Entry(gm_tarefa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_tarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tarefa
        //[HttpPost]
        //[Route("tarefa/create")]
        [ResponseType(typeof(gm_tarefa))]
        public IHttpActionResult Postgm_tarefa(gm_tarefa gm_tarefa)
            {
                
                db.gm_tarefa.Add(gm_tarefa);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = gm_tarefa.id }, gm_tarefa);
            }
        //{
        //    List<Object> result = new List<object>();
        //    gm_tarefa tarefa = new gm_tarefa();

        //    tarefa.titulo = HttpContext.Current.Request.Params["titulo"];
        //    tarefa.descricao = HttpContext.Current.Request.Params["descricao"];
        //    tarefa.dataInicio = DateTime.Now;
        //    tarefa.dataFim = Convert.ToDateTime(HttpContext.Current.Request.Params["dataFim"]);
        //    tarefa.nivelDificuldade = HttpContext.Current.Request.Params["nivelDificuldade"];

        //    db.gm_tarefa.Add(tarefa);
        //    _ = db.SaveChanges();

        //    result.Add(new
        //    {
        //        resp = "salvo com sucesso"
        //    });

        //    return result;
        //}

        // DELETE: api/Tarefa/5
        [ResponseType(typeof(gm_tarefa))]
        public IHttpActionResult Deletegm_tarefa(int id)
        {
            gm_tarefa gm_tarefa = db.gm_tarefa.Find(id);
            if (gm_tarefa == null)
            {
                return NotFound();
            }

            db.gm_tarefa.Remove(gm_tarefa);
            db.SaveChanges();

            return Ok(gm_tarefa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gm_tarefaExists(int id)
        {
            return db.gm_tarefa.Count(e => e.id == id) > 0;
        }
    }
}