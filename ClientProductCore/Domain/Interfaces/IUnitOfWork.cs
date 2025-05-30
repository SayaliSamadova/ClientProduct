using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProductCore.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
     
        IClientRepository ClientRepository { get; }
       
        IProductRepository ProductRepository { get; }
       
    }
}
