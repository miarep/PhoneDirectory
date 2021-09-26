using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Domain.Entity;
using PhoneDirectory.Domain.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PhoneDirectory.Domain.DAL.EF
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private DatabaseContext db = new DatabaseContext();
        public IEnumerable<Employee> GetAll()
        {
            var employees = db.Employees;
            return employees;
        }
        public Employee Get(int id)
        {
            var employees = db.Employees.Include(e => e.Position).ThenInclude(p => p.Department).Where( x => x.Id == id);
            if (employees.Count() == 1)
            {
                return employees.FirstOrDefault();
            }
            return null;
        }

        public Employee Get(string email, string password)
        {
            var employees = db.Employees.Where(x=> x.Email.ToLower() == email.ToLower() && x.Password == password);
            if (employees.Count() == 1)
            {
                return employees.FirstOrDefault();
            }
            return null;
        }
    }
}
