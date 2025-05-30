using ClientProduct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProduct.ViewModels;
using System.Windows.Input;

namespace ClientProduct.Commands.ProductCommand
{
    public class AddCommand : ICommand
    {
        private readonly ProductsViewModel _viewModel;
        public AddCommand(ProductsViewModel viewModel)
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
            _viewModel.CurrentSituation = Situation.CREATE;
        }
    }
}
