using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackEnd.Entity_Framework;

namespace BackEnd.Repo
{
    public class Repository
    {
        private MerchantsDbContext context;
        public Repository()
        {
            context = new MerchantsDbContext();
        }
        public IQueryable<Merchant> GetAll()
        {
            var merchants = context.Set<Merchant>();
            return merchants;
        }
        public IQueryable<Merchant> Query(System.Linq.Expressions.Expression<Func<Merchant, bool>> filter)
        {
            return context.Set<Merchant>().Where(filter);
        }
        public Merchant FindById(int id)
        {
            return context.Set<Merchant>().Find(id);
        }
        public void Add(Merchant entity)
        {
            context.Set<Merchant>().Add(entity);
        }

        public void Update(Merchant entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Merchant entity)
        {
            context.Set<Merchant>().Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return context.Merchants.Count(e => e.Id == id) > 0;
        }
    }
}