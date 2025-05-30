using ClientProduct.Models;
using ClientProductCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProduct.Mappers
{
    public class OrderMapper : IMapper<OrderModel, Order>
    {
        public OrderModel Map(Order entity)
        {
            var orderModel = new OrderModel();
            orderModel.ProductId = entity.ProductId;
            orderModel.ClientId = entity.ClientId;
            orderModel.OrderDate = entity.OrderDate;
            return orderModel;
        }

        public Order Map(OrderModel model)
        {
            var order = new Order();
            order.ProductId = model.ProductId;
            order.ClientId = model.ClientId;
            order.OrderDate = model.OrderDate;
            return order;

        }
    }
}
