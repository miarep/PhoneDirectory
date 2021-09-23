using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Domain.Entity;
using PhoneDirectory.Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace PhoneDirectory.Domain.DAL.EF
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private DatabaseContext db = new DatabaseContext();

        public IEnumerable<Department> GetAll()
        {
            var departments = db.Departments.Include(d => d.Employees).ThenInclude(e => e.Position);
            return departments;
        }
        public Department GetById(int id)
        {
            var department = db.Departments.Find(id);
            return department;
        }
    }
}
