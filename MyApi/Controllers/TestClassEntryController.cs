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
using MyApi.Models;

namespace MyApi.Controllers
{
    public class TestClassEntryController : ApiController
    {
        private TestEntities db = new TestEntities();

        // GET: api/TestClassEntry
        public IQueryable<TestClassEntry> GetTestClassEntries()
        {
            return db.TestClassEntries;
        }

        // GET: api/TestClassEntry/5
        [ResponseType(typeof(TestClassEntry))]
        public IHttpActionResult GetTestClassEntry(int id)
        {
            TestClassEntry testClassEntry = db.TestClassEntries.Find(id);
            if (testClassEntry == null)
            {
                return NotFound();
            }

            return Ok(testClassEntry);
        }

        // PUT: api/TestClassEntry/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestClassEntry(int id, TestClassEntry testClassEntry)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != testClassEntry.id)
            {
                return BadRequest();
            }

            db.Entry(testClassEntry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestClassEntryExists(id))
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

        // POST: api/TestClassEntry
        [ResponseType(typeof(TestClassEntry))]
        public IHttpActionResult PostTestClassEntry(TestClassEntry testClassEntry)
        {
           

            db.TestClassEntries.Add(testClassEntry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testClassEntry.id }, testClassEntry);
        }

        // DELETE: api/TestClassEntry/5
        [ResponseType(typeof(TestClassEntry))]
        public IHttpActionResult DeleteTestClassEntry(int id)
        {
            TestClassEntry testClassEntry = db.TestClassEntries.Find(id);
            if (testClassEntry == null)
            {
                return NotFound();
            }

            db.TestClassEntries.Remove(testClassEntry);
            db.SaveChanges();

            return Ok(testClassEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestClassEntryExists(int id)
        {
            return db.TestClassEntries.Count(e => e.id == id) > 0;
        }
    }
}