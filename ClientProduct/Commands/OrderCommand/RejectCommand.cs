using ClientProduct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientProduct.Models;
using ClientProduct.ViewModels;

namespace ClientProduct.Commands.OrderCommand
{
    public class RejectCommand : ICommand
    {
        private readonly OrdersViewModel _viewModel;
        public RejectCommand(OrdersViewModel viewModel)
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
            _viewModel.CurrentOrder = null;
            _viewModel.CurrentOrder = new OrderModel();
            _viewModel.CurrentSituation = Situation.NORMAL;
        }
    }
}
