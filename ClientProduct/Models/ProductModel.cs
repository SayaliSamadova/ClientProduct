using ClientProduct.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.Models
{
    public class ProductModel : IModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductModel Clone()
        {
            var productModel = new ProductModel();
            productModel.No = No;
            productModel.Name = Name;
            productModel.Description = Description;
            productModel.Price = Price;
           

            return productModel;
        }

        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                message = "Заполните название";
                return false;
            }
            if (Price <= 0)
            {
                message = "Цена должна быть выше нуля";
                return false;
            }
            message = null;
            return true;
        }
    }

}
