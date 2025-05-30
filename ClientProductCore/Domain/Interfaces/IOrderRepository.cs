using ClientProductCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProductCore.Domain.Interfaces
{
    public interface IOrderRepository : ICrudRepository<Order>
    {
    }
}
