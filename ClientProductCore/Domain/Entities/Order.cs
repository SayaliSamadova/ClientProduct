using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProductCore.Domain.Entities
{
    public class Order :IDbEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; } // client client
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
