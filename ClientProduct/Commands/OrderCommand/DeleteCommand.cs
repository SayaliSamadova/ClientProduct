using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ClientProduct.ViewModels;

namespace ClientProduct.Commands.OrderCommand
{
    public class DeleteCommand : ICommand
    {
       
        private readonly OrdersViewModel _viewModel;
        public DeleteCommand(OrdersViewModel viewModel)
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
