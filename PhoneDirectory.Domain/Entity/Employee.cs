using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PhoneDirectory.Domain.Entity
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }

        /// <summary>
        /// Фамилия Имя Отчество
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Табельный номер
        /// </summary>
        public int TabelNumber { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Сотовый телефон
        /// </summary>
        public string MobilePhone{ get; set; }

        /// <summary>
        /// Путь к фотографии
        /// </summary>
        public string PhotoPath{ get; set; }


        /// <summary>
        /// Должность
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public int PositionId { get; set; }        

    }
}
