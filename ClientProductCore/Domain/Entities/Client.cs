using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProductCore.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
    }
}
