using System;
using System.Collections.Generic;
using System.Text;
using PhoneDirectory.Domain.Entity;
using PhoneDirectory.Domain.Abstract;

namespace PhoneDirectory.Domain.DAL.EF
{
    public class EFPositionRepository : IPositionRepository
    {
        private DatabaseContext db = new DatabaseContext();
        public IEnumerable<Position> GetAll()
        {
            var positions = db.Positions;
            return positions;
        }
        public Position GetById(int id)
        {
            var position = db.Positions.Find(id); 
            return position;
        }
    }
}
