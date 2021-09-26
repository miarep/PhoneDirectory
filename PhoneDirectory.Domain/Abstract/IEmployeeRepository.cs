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
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        public Employee Get(int id);

        /// <summary>
        /// Получить сотрудника по логину и паролю
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        public Employee Get(string email, string password);
    }
}
