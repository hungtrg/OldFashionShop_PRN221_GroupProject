using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DataAccess
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }

        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Account> GetAccountList()
        {
            List<Account> accounts;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                accounts = myStoreDB.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }

        public Account GetAccount(string email)
        {
            Account account = null;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                account = myStoreDB.Accounts.SingleOrDefault(account => account.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public Account CheckLogin(string email, string password)
        {
            Account account = null;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                account = myStoreDB.Accounts.SingleOrDefault(account => account.Email == email && account.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public void AddAccount(Account account)
        {
            try
            {
                Account c = GetAccount(account.Email);
                if (c == null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Accounts.Add(account);
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The account has already existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAccount(Account account)
        {
            try
            {
                Account c = GetAccount(account.Email);
                if (c != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Entry<Account>(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The account has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveAccount(Account account)
        {
            try
            {
                Account c = GetAccount(account.Email);
                if (c != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Remove(c);
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The account has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
