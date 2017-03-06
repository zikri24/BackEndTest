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
using BackEnd.Entity_Framework;
using BackEnd.Repo;

namespace BackEnd.Controllers
{
    [Route("api/[conroller]")]
    public class MerchantsController : ApiController
    {
        private Repository repo = new Repository();

        public MerchantsController()
        {
            repo = new Repository();
        }       

        // GET: api/Merchants
        [HttpGet]
        public IQueryable<Merchant> GetMerchants()
        {
            return repo.GetAll();
        }

        // GET: api/Merchants/5
        
        [ResponseType(typeof(Merchant))]
        public IHttpActionResult GetMerchant(int id)
        {
           
            Merchant merchant = repo.FindById(id);
            if (merchant == null)
            {
                return NotFound();
            }

            return Ok(merchant);
        }

        // PUT: api/Merchants/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMerchant(int id, Merchant merchant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != merchant.Id)
            {
                return BadRequest();
            }

            repo.Update(merchant);

            try
            {
                repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantExists(id))
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

        // POST: api/Merchants
        [HttpPost]
        [ResponseType(typeof(Merchant))]
        public IHttpActionResult PostMerchant(Merchant merchant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.Add(merchant);
            repo.Save();
            return CreatedAtRoute("DefaultApi", new { id = merchant.Id }, merchant);
        }

        // DELETE: api/Merchants/5
        [ResponseType(typeof(Merchant))]
        [HttpDelete]
        public IHttpActionResult DeleteMerchant(int id)
        {
            Merchant merchant = repo.FindById(id);
            if (merchant == null)
            {
                return NotFound();
            }

            repo.Delete(merchant);
            repo.Save();

            return Ok(merchant);
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
        private bool MerchantExists(int id)
        {
            return repo.IsExists(id);
        }
    }
}