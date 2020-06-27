using Microsoft.EntityFrameworkCore;
using Poulina.GestionMs.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poulina.GestionMs.Data.Repository
{
  public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> table = null;
        private readonly Context _context;

        public Repository(Context context)
        {

            _context = context;
            table = _context.Set<T>();
        }




        public T GetById(Guid id)
        {
            IQueryable<T> query = _context.Set<T>();
            return table.Find(id);
        }

        public string Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return "Added done";
        }





        public string Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return "Update Done";
        }

        public string Delete(Guid id)
        {
            T existing = table.Find(id);
            table.Remove(existing);

            _context.SaveChanges();
            return "Delete Done";
            //   return "objet supprimé avec succés";
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }


    }
}