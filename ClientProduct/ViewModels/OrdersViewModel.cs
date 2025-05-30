using ClientProduct.Enums;
using ClientProduct.Models;
using ClientProduct.ViewModels.Interfaces;
using ClientProductCore.Domain.Interfaces;
using ClientProduct.Commands.OrderCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.ViewModels
{
    public class OrdersViewModel :BaseViewModel, IControlViewModel
    {
        private readonly IUnitOfWork _db;
        public OrdersViewModel(IUnitOfWork db)
        {
            _db = db;
            CurrentOrder = new OrderModel();
        }
        public string Header => "Заказы";
        private Situation _currentSituation;
        public Situation CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }

        }

        private OrderModel _currentOrder;
        public OrderModel CurrentOrder
        {
            get => _currentOrder;
            set
            {
                _currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }

        private OrderModel _selectedOrder;
        public OrderModel SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;

                if (_selectedOrder != null)
                {
                    CurrentOrder = SelectedOrder.Clone();
                    CurrentSituation = Situation.SELECTED;
                }
                else
                {
                    CurrentOrder = new OrderModel();
                    CurrentSituation = Situation.NORMAL;
                }
            }
        }
        public ObservableCollection<OrderModel> Orders { get; set; }

        public AddCommand Add => new AddCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public EditCommand Edit => new EditCommand(this);
        public RejectCommand Reject => new RejectCommand(this);
        public SaveCommand Save => new SaveCommand(_db, this);


    
    }
}
