using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Domain.Entity;
using PhoneDirectory.Domain.Abstract;

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
        public Employee GetById(int id)
        {
            var employee = db.Employees.Find(id);
            return employee;
        }
    }
}
