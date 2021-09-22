using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Domain.Entity;

namespace PhoneDirectory.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Получить всех сотрудников
        /// </summary>
        /// <returns></returns>
        
        public IEnumerable<Employee> GetAll();

        /// <summary>
        /// Получить сотрудника по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetById(int id);
    }
}
