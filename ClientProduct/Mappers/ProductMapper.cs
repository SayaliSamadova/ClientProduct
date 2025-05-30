using ClientProduct.Models;
using ClientProductCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.Mappers
{
    public class ProductMapper : IMapper<ProductModel, Product>
    {
        public ProductModel Map(Product entity)
        {
            var productModel = new ProductModel();
            productModel.Name = entity.Name;
            productModel.Description = entity.Description;
            productModel.Price = entity.Price;
            return productModel;
        }

        public Product Map(ProductModel model)
        {
            var product = new Product();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;

            return product;


        }
    }
}
