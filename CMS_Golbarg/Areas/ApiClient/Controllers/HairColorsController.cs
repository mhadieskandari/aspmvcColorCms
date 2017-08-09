using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CMS_Golbarg.Areas.Admin.Models;
using CMS_Golbarg.Dtos;

namespace CMS_Golbarg.Areas.ApiClient.Controllers
{
    public class HairColorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/HairColors
        public IEnumerable<HairColorDto> GetHairColors()
        {

            return db.HairColors.ToList().Select(AutoMapper.Mapper.Map<HairColor, HairColorDto>);
        }

        // GET: api/HairColors/5
        [ResponseType(typeof(HairColor))]
        public async Task<IHttpActionResult> GetHairColor(int id)
        {
            HairColor hairColor = await db.HairColors.FindAsync(id);
            if (hairColor == null)
            {
                return NotFound();
            }

            return Ok(hairColor);
        }

        // PUT: api/HairColors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHairColor(int id, HairColor hairColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairColor.Id)
            {
                return BadRequest();
            }

            db.Entry(hairColor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairColorExists(id))
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

        // POST: api/HairColors
        [ResponseType(typeof(HairColor))]
        public async Task<IHttpActionResult> PostHairColor(HairColor hairColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HairColors.Add(hairColor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hairColor.Id }, hairColor);
        }

        // DELETE: api/HairColors/5
        [ResponseType(typeof(HairColor))]
        public async Task<IHttpActionResult> DeleteHairColor(int id)
        {
            HairColor hairColor = await db.HairColors.FindAsync(id);
            if (hairColor == null)
            {
                return NotFound();
            }

            db.HairColors.Remove(hairColor);
            await db.SaveChangesAsync();

            return Ok(hairColor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HairColorExists(int id)
        {
            return db.HairColors.Count(e => e.Id == id) > 0;
        }
    }
}