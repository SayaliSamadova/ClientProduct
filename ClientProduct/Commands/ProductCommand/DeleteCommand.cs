using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientProduct.ViewModels;
using System.Windows;

namespace ClientProduct.Commands.ProductCommand
{
    public class DeleteCommand : ICommand
    {
       
        private readonly ProductsViewModel _viewModel;
        public DeleteCommand(ProductsViewModel viewModel)
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

        }
    }
}
