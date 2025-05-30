using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientProduct.ViewModels;
using System.Windows;
using ClientProduct.Enums;
using ClientProductCore.Domain.Interfaces;
using ClientProduct.Mappers;
using ClientProduct.Models;
using ClientProductCore.Domain.Entities;

namespace ClientProduct.Commands.ProductCommand
{
    public class SaveCommand : ICommand
    {
       
       
        private readonly ProductsViewModel _viewModel;
        private readonly IUnitOfWork _db;
        public SaveCommand(IUnitOfWork db,ProductsViewModel viewModel)
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
            if (_viewModel.CurrentProduct.IsValid(out string message) == false)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var mapper = new ProductMapper();
            var product = mapper.Map(_viewModel.CurrentProduct);
            _db.ProductRepository.Add(product);
            var lastElementNo = _viewModel.Products.LastOrDefault()?.No ?? 0; ;
            _viewModel.CurrentProduct.No = lastElementNo + 1;
            _viewModel.Products.Add(_viewModel.CurrentProduct);
            _viewModel.CurrentProduct = new ProductModel();
            _viewModel.CurrentSituation = Situation.NORMAL;
        }
    }
}
