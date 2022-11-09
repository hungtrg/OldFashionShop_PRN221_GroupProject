using BusinessLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail);

        public OrderDetail GetOrderDetailById(int id) => OrderDetailDAO.Instance.GetOrderDetailByID(id);

        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetailList();

        public void RemoveOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.RemoveOrderDetail(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
    }
}
