using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ClientProductCore.Domain.Interfaces;
using ClientProduct.Commands.OrderCommand;
using ClientProduct.Commands.ProductCommand;
using ClientProduct.Commands.ClientCommand;
using ClientProductCore.Domain.Interfaces;


namespace ClientProduct.ViewModels
{
    internal class MainPageViewModel: BaseViewModel
    {
       
        
        private readonly IUnitOfWork _db;
        public MainPageViewModel(IUnitOfWork db)
            
        {
            _db = db;
            OpenClientsCommand = new OpenClientsCommand(db);
            OpenOrdersCommand = new OpenOrdersCommand(db);
            OpenProductsCommand = new OpenProductsCommand(db);
        } 

        public OpenOrdersCommand OpenOrdersCommand { get; }
        public OpenClientsCommand OpenClientsCommand { get; }
        public OpenProductsCommand OpenProductsCommand { get; }

    }
}
