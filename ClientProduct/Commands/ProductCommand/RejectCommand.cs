using ClientProduct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProduct.ViewModels;
using System.Windows.Input;
using ClientProduct.Models;

namespace ClientProduct.Commands.ProductCommand
{
    public class RejectCommand : ICommand
    {

        private readonly ProductsViewModel _viewModel;
        public RejectCommand(ProductsViewModel viewModel)
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
            _viewModel.SelectedProduct = null;
            _viewModel.CurrentProduct = new ProductModel();
            _viewModel.CurrentSituation = Situation.NORMAL;
        }
    }
}

