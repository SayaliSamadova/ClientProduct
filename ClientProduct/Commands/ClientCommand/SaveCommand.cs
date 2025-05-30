using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProduct.ViewModels;
using System.Windows.Input;
using System.Windows;
using ClientProduct.Enums;
using ClientProduct.Models;
using ClientProduct.Mappers;
using ClientProductCore.Domain.Interfaces;

namespace ClientProduct.Commands.ClientCommand
{
    public class SaveCommand : ICommand
    {

        private readonly ClientsViewModel _viewModel;
        private readonly IUnitOfWork _db;
        public SaveCommand( IUnitOfWork db,ClientsViewModel viewModel)
        {
            _db = db;
            _viewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(_viewModel.CurrentClient.IsValid(out string message) == false)
            {
                MessageBox.Show(message, "Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var mapper = new ClientMapper();
            var client =mapper.Map(_viewModel.CurrentClient);
            client.RegistrationDate= DateTime.Now;
            
            //client.Modifier = new User {id=1};

            _db.ClientRepository.Add(client);
            var lastElementNo = _viewModel.Clients.LastOrDefault()?.No ?? 0;
            _viewModel.CurrentClient.No = lastElementNo + 1;
            _viewModel.Clients.Add(_viewModel.CurrentClient);
            _viewModel.CurrentClient = new ClientModel();
            _viewModel.CurrentSituation = Situation.NORMAL;
        }

      
    }
}

