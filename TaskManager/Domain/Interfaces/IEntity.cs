using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Interfaces
{
    internal class IEntity
    {
       public int Id { get; }
        public IEntity(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id не может быть отрицательным", nameof(id));
            Id = id;
        }
    }
}
