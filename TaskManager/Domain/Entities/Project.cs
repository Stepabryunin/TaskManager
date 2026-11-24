using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Domain.Entities
{
    internal class Project :IEntity
    {
        private string name="";
        public string Name { get { return name; } private set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Имя не может быть пустым", nameof(value)); name = value; } }
        public DateTime CreatedAt { get;  }
        public Project(int id, string name):base(id)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void ChangeName(string name_) { Name = name_; }
    }
}
