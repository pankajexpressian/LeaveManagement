using LeaveManagement.Contracts;
using LeaveManagement.Data;
using System.Collections.Generic;
using System.Linq;

namespace LeaveManagement.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(LeaveHistory entity)
        {
            _context.LeaveHistories.Add(entity);
            return Save();
        }

        public IEnumerable<LeaveHistory> GetAll()
        {
            return _context.LeaveHistories.ToList();
           
        }

        public LeaveHistory GetById(int id)
        {
            return _context.LeaveHistories.Find(id);
        }

        public bool IsExist(int id)
        {
            return GetById(id) != null;
        }
        public bool Remove(LeaveHistory entity)
        {
            _context.LeaveHistories.Remove(entity);
            return Save();
        }

        public bool Update(int id, LeaveHistory entity)
        {
            _context.LeaveHistories.Update(entity);
            return Save();
        }

        private bool Save()
        {
            var res = _context.SaveChanges();
            return res > 0;
        }
    }
}
