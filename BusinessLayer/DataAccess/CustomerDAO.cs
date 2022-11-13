//using DataLayer.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLayer.DataAccess
//{
//    public class CustomerDAO
//    {
//        private static CustomerDAO instance = null;
//        private static readonly object instanceLock = new object();
//        private CustomerDAO() { }
        
//        public static CustomerDAO Instance
//        {
//            get
//            {
//                lock (instanceLock)
//                {
//                    if (instance == null)
//                    {
//                        instance = new CustomerDAO();
//                    }
//                    return instance;
//                }
//            }
//        }

//        public IEnumerable<Customer> GetCustomerList()
//        {
//            List<Customer> customers;
//            try
//            {
//                var myStoreDB = new MyStoreManagementContext();
//                customers = myStoreDB.Customers.ToList();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            return customers;
//        }

//        public Customer GetCustomerByID(int customerID)
//        {
//            Customer customer = null;
//            try
//            {
//                var myStoreDB = new MyStoreManagementContext();
//                customer = myStoreDB.Customers.SingleOrDefault(customer => customer.CustomerId == customerID);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            return customer;
//        }

//        public void AddCustomer(Customer customer)
//        {
//            try
//            {
//                Customer c = GetCustomerByID(customer.CustomerId);
//                if (c == null)
//                {
//                    var myStoreDB = new MyStoreManagementContext();
//                    myStoreDB.Customers.Add(c);
//                    myStoreDB.SaveChanges();
//                }
//                else
//                {
//                    throw new Exception("The customer has already existed!");
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public void UpdateCustomer(Customer customer)
//        {
//            try
//            {
//                Customer c = GetCustomerByID(customer.CustomerId);
//                if (c != null)
//                {
//                    var myStoreDB = new MyStoreManagementContext();
//                    myStoreDB.Entry<Customer>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//                    myStoreDB.SaveChanges();
//                }
//                else
//                {
//                    throw new Exception("The customer has not existed!");
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public void RemoveCustomer(Customer customer)
//        {
//            try
//            {
//                Customer c = GetCustomerByID(customer.CustomerId);
//                if (c != null)
//                {
//                    var myStoreDB = new MyStoreManagementContext();
//                    myStoreDB.Remove(c);
//                    myStoreDB.SaveChanges();
//                }
//                else
//                {
//                    throw new Exception("The customer has not existed!");
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//    }
//}
