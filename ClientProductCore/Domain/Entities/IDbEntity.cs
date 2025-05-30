using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProductCore.Domain.Entities
{
    public interface IDbEntity
    {
        int Id { get; set; }
    }
}
