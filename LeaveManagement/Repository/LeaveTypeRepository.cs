using LeaveManagement.Data;
using LeaveManagement.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LeaveManagement.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(LeaveType entity)
        {
            _context.Add(entity);
            return Save();
        }

        public IEnumerable<LeaveType> GetAll()
        {
            return _context.LeaveTypes.ToList();
        }

        public LeaveType GetById(int id)
        {
            var entity = _context.LeaveTypes.Find(id);
            if (entity!=null)
            {
                _context.Entry<LeaveType>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            return entity;
        }

        public bool IsExist(int id)
        {
            return GetById(id) != null;
        }
        public bool Remove(LeaveType entity)
        {
            if (_context.Entry<LeaveType>(entity).State!=Microsoft.EntityFrameworkCore.EntityState.Deleted)
            {
                _context.Entry<LeaveType>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            _context.Remove(entity);
            return Save();
        }

        public bool Update(int id, LeaveType entity)
        {
            _context.LeaveTypes.Update(entity);
            return Save();
        }

        private bool Save()
        {
            var res = _context.SaveChanges();
            return res > 0;
        }

    }
}
