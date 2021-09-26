using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using PhoneDirectory.Domain.Entity;

namespace PhoneDirectory.Domain.Entity
{
    /// <summary>
    /// Должность
    /// </summary>
    public class Position
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Подразделение
        /// </summary>
        public Department Department{ get; set; }

        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public List<Employee> Employees { get; set; }
    }
}
