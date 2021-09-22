using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Domain.Entity
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class Department
    {
        public int Id { get; set; }

        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Короткое имя
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public List<Employee> Employees { get; set; }
    }
}
