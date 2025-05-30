using ClientProduct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientProduct.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientProduct.Models;

namespace ClientProduct.Commands.ClientCommand
{
    public class RejectCommand : ICommand
    {
        
        
        private readonly ClientsViewModel _viewModel;
        public RejectCommand(ClientsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.SelectedClient = null;
            _viewModel.CurrentClient = new ClientModel();
             _viewModel.CurrentSituation = Situation.NORMAL;
        }
    }
}
