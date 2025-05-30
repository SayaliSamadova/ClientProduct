using ClientProduct.Models.Interfaces;
using ClientProductCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.Mappers
{
    public interface IMapper<TModel, TEntity> where TEntity : IDbEntity where TModel : IModel
    {
        TModel Map(TEntity entity);
        TEntity Map(TModel model);
    }
}
