using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
