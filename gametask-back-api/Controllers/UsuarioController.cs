using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using gametask_back_api;

namespace gametask_back_api.Controllers
{
    public class UsuarioController : ApiController
    {
        private gametaskEntities db = new gametaskEntities();

        // GET: api/Usuario
        public IQueryable<gm_usuario> Get_Usuarios()
        {
            return db.gm_usuario;
        }

        // GET: api/Usuario/5
        [ResponseType(typeof(gm_usuario))]
        public IHttpActionResult Getgm_usuario(int id)
        {
            gm_usuario gm_usuario = db.gm_usuario.Find(id);
            if (gm_usuario == null)
            {
                return NotFound();
            }

            return Ok(gm_usuario);
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgm_usuario(int id, gm_usuario gm_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gm_usuario.userId)
            {
                return BadRequest();
            }

            db.Entry(gm_usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_usuarioExists(id))
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

        // POST: api/Usuario
        [ResponseType(typeof(gm_usuario))]
        public IHttpActionResult Postgm_usuario(gm_usuario gm_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gm_usuario.Add(gm_usuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gm_usuario.userId }, gm_usuario);
        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(gm_usuario))]
        public IHttpActionResult Deletegm_usuario(int id)
        {
            gm_usuario gm_usuario = db.gm_usuario.Find(id);
            if (gm_usuario == null)
            {
                return NotFound();
            }

            db.gm_usuario.Remove(gm_usuario);
            db.SaveChanges();

            return Ok(gm_usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gm_usuarioExists(int id)
        {
            return db.gm_usuario.Count(e => e.userId == id) > 0;
        }
    }
}