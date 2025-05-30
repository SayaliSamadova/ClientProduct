using ClientProduct.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.Models
{
    public class ClientModel : IModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ClientModel Clone()
        {
            var clientModel = new ClientModel();
            clientModel.No = No;
            clientModel.Name = Name;
            clientModel.Surname = Surname;
            clientModel.Email = Email;
            clientModel.Phone = Phone;
            clientModel.Username = Username;
            clientModel.Password = Password;

            return clientModel;
        }
        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                message = "Заполните имя";
                return false;
            }
            message = null;
            return true;
        }

    }
}
