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
using PracticaP1.Models;

namespace PracticaP1.Controllers
{
    public class EidsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Eids
        [Authorize]
        public IQueryable<Eid> GetEids()
        {
            return db.Eids;
        }

        // GET: api/Eids/5
        [Authorize]
        [ResponseType(typeof(Eid))]
        public IHttpActionResult GetEid(int id)
        {
            Eid eid = db.Eids.Find(id);
            if (eid == null)
            {
                return NotFound();
            }

            return Ok(eid);
        }

        // PUT: api/Eids/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEid(int id, Eid eid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eid.eidID)
            {
                return BadRequest();
            }

            db.Entry(eid).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EidExists(id))
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

        // POST: api/Eids
        [Authorize]
        [ResponseType(typeof(Eid))]
        public IHttpActionResult PostEid(Eid eid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Eids.Add(eid);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eid.eidID }, eid);
        }

        // DELETE: api/Eids/5
        [Authorize]
        [ResponseType(typeof(Eid))]
        public IHttpActionResult DeleteEid(int id)
        {
            Eid eid = db.Eids.Find(id);
            if (eid == null)
            {
                return NotFound();
            }

            db.Eids.Remove(eid);
            db.SaveChanges();

            return Ok(eid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EidExists(int id)
        {
            return db.Eids.Count(e => e.eidID == id) > 0;
        }
    }
}