using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public TEntity GetById(int id);
        public IEnumerable<TEntity> GetAll();
        public bool Add(TEntity entity);
        public bool Update(int id, TEntity entity);
        public bool Remove(TEntity entity);
    }

   
}
