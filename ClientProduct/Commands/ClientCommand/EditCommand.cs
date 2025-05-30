using ClientProduct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientProduct.ViewModels;

namespace ClientProduct.Commands.ClientCommand
{
    public class EditCommand : ICommand
    {
        private readonly ClientsViewModel _viewModel;
        
        public EditCommand(ClientsViewModel viewModel)
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
            _viewModel.CurrentSituation = Situation.EDIT;
        }
    }
}
