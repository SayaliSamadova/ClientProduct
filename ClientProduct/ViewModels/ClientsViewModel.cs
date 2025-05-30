using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProduct.Commands.ClientCommand;
using ClientProduct.Enums;
using ClientProduct.Models;
using ClientProduct.ViewModels.Interfaces;
using ClientProductCore.Domain.Interfaces;

namespace ClientProduct.ViewModels
{
    public class ClientsViewModel : BaseViewModel, IControlViewModel
    {
        private readonly IUnitOfWork _db;
        public ClientsViewModel(IUnitOfWork db) 
        {
            _db = db;
          CurrentClient = new ClientModel();
        }
        public string Header => "Клиенты";
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

        private ClientModel _currentClient;
        public ClientModel CurrentClient
        {
            get => _currentClient;
            set
            {
                _currentClient = value;
                OnPropertyChanged(nameof(CurrentClient));
            }
        }

        private ClientModel _selectedClient;
        public ClientModel SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                
                if (_selectedClient != null)
                {
                    CurrentClient = SelectedClient.Clone();
                    CurrentSituation = Situation.SELECTED;
                }
                else
                {
                    CurrentClient = new ClientModel();
                    CurrentSituation = Situation.NORMAL;
                }
            }
        }
        public ObservableCollection<ClientModel> Clients { get; set; }

        public AddCommand Add => new AddCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public EditCommand Edit => new EditCommand(this);
        public RejectCommand Reject => new RejectCommand(this);
        public SaveCommand Save => new SaveCommand(_db, this);


        
    }
}

