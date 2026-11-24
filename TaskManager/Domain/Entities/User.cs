using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Domain.Entities
{
    internal class User :IEntity
    {
        private string name="";
        public string Name { get { return name; } private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Имя не может быть пусты");
                name = value;
            } }
        private string email="";
        public string Email { get { return email; } private set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Email не может быть пустым");
                bool isEmail = false;
                foreach (var item in value)
                    if (item == '@')
                        isEmail = !isEmail;
                if (!isEmail)
                    throw new ArgumentException("Email имеет неверный формат");
                email = value;
            } }   

        public User(int id, string name, string email):base(id) 
        {

            Name = name;
            Email = email;
        }
        public void ChangeName(string name_) { Name=name_; }
        public void ChangeEmail(string email_) { Email=email_; }
    }
}
