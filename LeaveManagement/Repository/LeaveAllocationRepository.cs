using LeaveManagement.Contracts;
using LeaveManagement.Data;
using System.Collections.Generic;
using System.Linq;

namespace LeaveManagement.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveAllocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Add(entity);
            return Save();
        }

        public IEnumerable<LeaveAllocation> GetAll()
        {
            return _context.LeaveAllocations.ToList();
        }

        public LeaveAllocation GetById(int id)
        {
            return _context.LeaveAllocations.Find(id);
        }

        public bool IsExist(int id)
        {
            return GetById(id)!=null;
        }

        public bool Remove(LeaveAllocation entity)
        {
            _context.LeaveAllocations.Remove(entity);
            return Save();
        }

        public bool Update(int id, LeaveAllocation entity)
        {
            _context.LeaveAllocations.Update(entity);
            return Save();
        }
        private bool Save()
        {
            var res = _context.SaveChanges();
            return res > 0;
        }
    }

}

