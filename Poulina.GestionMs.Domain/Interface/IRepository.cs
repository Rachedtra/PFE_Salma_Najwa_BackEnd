using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Interface
{
   public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        string Add(T entity);
        string Update(T entity);

        string Delete(Guid id);
    }

}
