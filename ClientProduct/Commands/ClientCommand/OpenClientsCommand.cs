using ClientProduct.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ClientProduct.Views;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ClientProduct.ViewModels;
using ClientProductCore.Domain;
using ClientProductCore.Domain.Interfaces;
using ClientProduct.Models;
using ClientProduct.Mappers;

namespace ClientProduct.Commands.ClientCommand
{
    internal class OpenClientsCommand : ICommand

    {
        private readonly IUnitOfWork _db;
        
        public OpenClientsCommand(IUnitOfWork db)
        {
            _db = db;
        }

      
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var grid = parameter as Grid;
            if (grid == null)
                return;
            grid.Children.Clear();

            var control = new ClientsControl();
            var viewModel= new ClientsViewModel(_db);

            var clients = _db.ClientRepository.GetAll();

            var clientModels = new List<ClientModel>();

            var clientMapper = new ClientMapper();
            var no = 1;

            foreach ( var client in clients) 
            {
                var clientModel = clientMapper.Map(client);
                
                clientModel.No = no++;
                clientModels.Add(clientModel);
            }

            viewModel.Clients =  new ObservableCollection<ClientModel> (clientModels);

            control.DataContext = viewModel;

            grid.Children.Add(control);
        }
    }
}
