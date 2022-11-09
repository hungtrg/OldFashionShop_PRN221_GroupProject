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
        Account GetAccountById(int id);
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        void RemoveAccount(Account account);
    }
}
