using BusinessLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> SearchAccounts(string search);
        Account GetAccount(string email);
        Account CheckLogin(string email, string password);
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        void RemoveAccount(Account account);
    }

    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);

        public Account CheckLogin(string email, string password) => AccountDAO.Instance.CheckLogin(email, password);

        public Account GetAccount(string email) => AccountDAO.Instance.GetAccount(email);

        public IEnumerable<Account> GetAccounts() => AccountDAO.Instance.GetAccountList();

        public IEnumerable<Account> SearchAccounts(string search) => AccountDAO.Instance.SearchAccounts(search);

        public void RemoveAccount(Account account) => AccountDAO.Instance.RemoveAccount(account);

        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
    }
}
