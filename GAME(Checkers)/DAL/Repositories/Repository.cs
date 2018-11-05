using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepos<T> where T : class
    {
        

        private readonly Context db = new Context();
        private readonly DbSet<T> Set;

        public Repository()
        {
            Set = db.Set<T>();
        }

        public void Create(T Entity)
        {
            Set.Add(Entity);
            db.SaveChanges();
        }


        public void Delete(T Entity)
        {
            Set.Attach(Entity);
            Set.Remove(Entity);
            db.SaveChanges();

        }


        public IEnumerable<T> GetAll()
        {
            return Set.AsNoTracking<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            return Set.Find(id);
        }

        public void Update(T Entity)
        {
            db.Entry<T>(Entity).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
