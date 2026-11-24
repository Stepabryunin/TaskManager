using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Имя не может быть пустым");
                name = value;
            } }
        private string email="";
        public string Email { get { return email; } private set {
                if (string.IsNullOrWhiteSpace(value) || !MailAddress.TryCreate(value, out var address) || address.Address != value)
                    throw new ArgumentNullException("Неверный Email адрес");
                
                email = address.Address;
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
