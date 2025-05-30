using ClientProduct.Enums;
using ClientProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProduct.Commands.ProductCommand;
using ClientProduct.ViewModels.Interfaces;
using ClientProductCore.Domain.Interfaces;
using System.Collections.ObjectModel;

namespace ClientProduct.ViewModels
{
    public class ProductsViewModel : BaseViewModel, IControlViewModel
    {
        private readonly IUnitOfWork _db;
        public ProductsViewModel(IUnitOfWork db)
        {

            _db = db;
            CurrentProduct = new ProductModel();
        }
        public string Header => "Цветы";
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

        private ProductModel _currentProduct;
        public ProductModel CurrentProduct
        {
            get => _currentProduct;
            set
            {
                _currentProduct = value;
                OnPropertyChanged(nameof(CurrentProduct));
            }
        }
        private ProductModel _selectedProduct;
        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                
                if (_selectedProduct != null)
                {
                    CurrentProduct = SelectedProduct.Clone();
                    CurrentSituation = Situation.SELECTED;
                }
                else
                {
                    CurrentProduct = new ProductModel();
                    CurrentSituation = Situation.NORMAL;
                }
            }
        }
        public ObservableCollection<ProductModel> Products { get; set; }

        public AddCommand Add => new AddCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public EditCommand Edit => new EditCommand(this);
        public RejectCommand Reject => new RejectCommand(this);
        public SaveCommand Save => new SaveCommand(_db,this);
    }
}
