using ClientProduct.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClientProduct.Models
{
    public class OrderModel : IModel
    {
        public int Id { get; set; }
        public int No { get; set; }

        // Внешние ключи
        public int ClientId { get; set; }
        public int ProductId { get; set; }


        public DateTime OrderDate { get; set; }
       

        // Навигационные свойства для EF
        //public ClientModel Client { get; set; }
        //public ProductModel Product { get; set; }

        public OrderModel Clone()
        {
           var orderModel = new OrderModel();
            orderModel.No = No;
            orderModel.ClientId = ClientId;
            orderModel.ProductId = ProductId;
            orderModel.OrderDate = OrderDate;
            return orderModel;
        }



        public bool IsValid(out string message)
        {
            if (ClientId <= 0)
            {
                message = "Заполните Id клиента";
                return false;
            }

            if (ProductId <= 0)
            {
                message = "Заолните Id продукта";
                return false;
            }


            message = null;
            return true;
        }
    }
}
