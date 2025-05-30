using ClientProduct.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ClientProduct.ViewModels;
using ClientProductCore.Domain.Interfaces;
using ClientProduct.Models;
using ClientProduct.Mappers;


namespace ClientProduct.Commands.OrderCommand
{
     internal class OpenOrdersCommand : ICommand
    {
        private readonly IUnitOfWork _db;
        public OpenOrdersCommand(IUnitOfWork db)
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

            var control = new OrdersControl();
            var viewModel = new OrdersViewModel(_db);

            var orders = _db.OrderRepository.GetAll();
            var orderModels = new List<OrderModel>();

            var orderMapper = new OrderMapper();

            var no = 1;

            foreach (var order in orders)
            {
                var orderModel = orderMapper.Map(order);

                orderModel.No = no++;

                orderModels.Add(orderModel);
            }

            viewModel.Orders = new ObservableCollection<OrderModel>(orderModels);

            control.DataContext = viewModel;

            grid.Children.Add(control);
        }


    }
}
