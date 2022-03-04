using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CV_Udemy.Models.Entity;

namespace CV_Udemy.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        CV_SiteEntities entities = new CV_SiteEntities();

        public List<T> List()
        {
            return entities.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            entities.Set<T>().Add(p);
            entities.SaveChanges();
        }

        public void TDelete(T p)
        {
            entities.Set<T>().Remove(p);
            entities.SaveChanges();
        }

        public T TGet(int id)
        {
            return entities.Set<T>().Find(id);
        }

        public void TUpdate(T p)
        {
            entities.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where) // bul 
        {
            return entities.Set<T>().FirstOrDefault(where);
        }
       
    }
}