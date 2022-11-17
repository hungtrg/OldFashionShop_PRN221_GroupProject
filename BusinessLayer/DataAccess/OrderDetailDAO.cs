using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                orderDetails = myStoreDB.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public OrderDetail GetOrderDetailByID(int orderDetailID)
        {
            OrderDetail orderDetail = null;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                orderDetail = myStoreDB.OrderDetails.SingleOrDefault(orderDetail => orderDetail.OrderDetailId == orderDetailID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail p = GetOrderDetailByID((int) orderDetail.OrderDetailId);
                if (p == null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.OrderDetails.Add(orderDetail);
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderDetail has already existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail p = GetOrderDetailByID((int) orderDetail.OrderDetailId);
                if (p != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderDetail has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail p = GetOrderDetailByID((int) orderDetail.OrderDetailId);
                if (p != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Remove(orderDetail);
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderDetail has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
