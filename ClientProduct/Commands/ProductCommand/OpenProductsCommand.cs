using ClientProduct.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ClientProduct.ViewModels;
using System.Windows.Input;
using ClientProductCore.Domain.Interfaces;
using ClientProduct.Mappers;
using ClientProduct.Models;

namespace ClientProduct.Commands.ProductCommand
{
    internal class OpenProductsCommand : ICommand 
    {

        private readonly IUnitOfWork _db;

        public OpenProductsCommand(IUnitOfWork db)
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

            var control = new ProductsControl();
            var viewModel = new ProductsViewModel(_db);

            var products = _db.ProductRepository.GetAll();

            var productModels = new List<ProductModel>();

            var productMapper = new ProductMapper();
            var no = 1;

            foreach (var product in products)
            {
                var productModel = productMapper.Map(product);

                productModel.No= no++;
                productModels.Add(productModel);
            }

            viewModel.Products = new ObservableCollection<ProductModel> (productModels);

            control.DataContext = viewModel;

            grid.Children.Add(control);
        }
    }
}
