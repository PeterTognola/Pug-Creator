using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PugCreatorServer.Models;

namespace PugCreatorServer.Controllers
{
    public class PugsController : ApiController
    {
        private readonly PugDbContext _db = new PugDbContext();

        // GET: Pugs
        public IEnumerable<Pug> GetPugs()
        {
            return _db.Pugs.Include(x => x.Coat).ToList();
        }

        // GET: Pugs/5
        [ResponseType(typeof(Pug))]
        public async Task<IHttpActionResult> GetPug(Guid id)
        {
            var pug = await _db.Pugs.FindAsync(id);

            if (pug == null)
            {
                return NotFound();
            }

            return Ok(pug);
        }

        // PUT: Pugs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPug(Guid id, Pug pug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pug.Id)
            {
                return BadRequest();
            }

            _db.Entry(pug).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PugExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Pugs
        [ResponseType(typeof(Pug))]
        public async Task<IHttpActionResult> PostPug(Pug pug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Pugs.Add(pug);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PugExists(pug.Id))
                {
                    return Conflict();
                }

                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = pug.Id }, pug);
        }

        // DELETE: Pugs/5
        [ResponseType(typeof(Pug))]
        public async Task<IHttpActionResult> DeletePug(Guid id)
        {
            var pug = await _db.Pugs.FindAsync(id);

            if (pug == null)
            {
                return NotFound();
            }

            _db.Pugs.Remove(pug);
            await _db.SaveChangesAsync();

            return Ok(pug);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PugExists(Guid id)
        {
            return _db.Pugs.Count(e => e.Id == id) > 0;
        }
    }
}