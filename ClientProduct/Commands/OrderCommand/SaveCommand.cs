using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ClientProduct.ViewModels;
using ClientProduct.Enums;
using ClientProduct.Mappers;
using ClientProduct.Models;
using ClientProductCore.Domain.Interfaces;

namespace ClientProduct.Commands.OrderCommand
{
    public class SaveCommand :ICommand
    {
       

        private readonly OrdersViewModel _viewModel;
        private readonly IUnitOfWork _db;
        public SaveCommand(IUnitOfWork db, OrdersViewModel viewModel)
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
            if (_viewModel.CurrentOrder.IsValid(out string message) == false)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var mapper = new OrderMapper();
            var order = mapper.Map(_viewModel.CurrentOrder);
            order.OrderDate = DateTime.Now;

            _db.OrderRepository.Add(order);
            var lastElementNo = _viewModel.Orders.LastOrDefault()?.No ?? 0;
            _viewModel.CurrentOrder.No = lastElementNo + 1;
            _viewModel.Orders.Add(_viewModel.CurrentOrder);
            _viewModel.CurrentOrder = new OrderModel();
            _viewModel.CurrentSituation = Situation.NORMAL;
        }

    }
}
