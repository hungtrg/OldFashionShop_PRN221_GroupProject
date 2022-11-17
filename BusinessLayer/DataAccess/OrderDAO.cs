using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrderList()
        {
            List<Order> orders;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                orders = myStoreDB.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public IEnumerable<Order> SearchOrders(string search)
        {
            List<Order> orders;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                orders = myStoreDB.Orders.Where(orders => orders.AccountId.ToString().Contains(search) || orders.OrderDate.ToString().Contains(search)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order GetOrderByID(int orderID)
        {
            Order order = null;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                order = myStoreDB.Orders.SingleOrDefault(order => order.OrderId == orderID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public Order AddOrder(Order order)
        {
            try
            {
                Order c = GetOrderByID(order.OrderId);
                if (c == null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Orders.Add(order);
                    myStoreDB.SaveChanges();
                    return order;
                }
                else
                {
                    throw new Exception("The order has already existed!");
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return null;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                Order c = GetOrderByID(order.OrderId);
                if (c != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveOrder(Order order)
        {
            try
            {
                Order c = GetOrderByID(order.OrderId);
                if (c != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Remove(c);
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
