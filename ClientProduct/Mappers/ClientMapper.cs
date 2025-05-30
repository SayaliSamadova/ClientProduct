using ClientProduct.Models;
using ClientProductCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.Mappers
{
    public class ClientMapper : IMapper<ClientModel, Client>
    {
        public ClientModel Map(Client entity)
        {
            var clientModel = new ClientModel();
            clientModel.Name = entity.Name;
            clientModel.Surname = entity.Surname;
            clientModel.Username = entity.Username;
            clientModel.Phone = entity.Phone;
            clientModel.Email = entity.Email;
            clientModel.Password = entity.Password;
            return clientModel;
        }

        public Client Map(ClientModel model)
        {
            var client = new Client();
            client.Name = model.Name;
            client.Surname= model.Surname;
            client.Username= model.Username;
            client.Phone = model.Phone;
            client.Email = model.Email;
            client.Password = model.Password;

            return client;


        }
    }
}
