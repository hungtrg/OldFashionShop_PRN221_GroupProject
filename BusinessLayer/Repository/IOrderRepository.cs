﻿using BusinessLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void RemoveOrder(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public Order GetOrderById(int id) => OrderDAO.Instance.GetOrderByID(id);

        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrderList();

        public void RemoveOrder(Order order) => OrderDAO.Instance.RemoveOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
    }
}
