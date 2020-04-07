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
        public void Add(TEntity entity);
        public void Update(int id, TEntity entity);
        public void Remove(TEntity entity);
    }

   
}
