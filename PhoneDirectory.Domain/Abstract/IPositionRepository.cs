using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Domain.Entity;

namespace PhoneDirectory.Domain.Abstract
{
    public interface IPositionRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Position> GetAll();

        /// <summary>
        /// Получить должность по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Position GetById(int id);
    }
}
