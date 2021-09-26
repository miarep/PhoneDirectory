using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Domain.Entity;

namespace PhoneDirectory.Domain.Abstract
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Получить все подразделения
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetAll();

        /// <summary>
        /// Получить подразделение по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetById(int id);

        /// <summary>
        /// Получить "корневые" подразделения (Без родителя)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetRootDepartments();
    }
}
