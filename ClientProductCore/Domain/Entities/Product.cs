using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProductCore.Domain.Entities
{
    public class Product : IDbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
