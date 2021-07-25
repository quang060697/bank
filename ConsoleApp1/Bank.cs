using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Bank
    {
        private List<Account> _accounts;
        private List<Transaction> _transaction;
        public Bank()
        {
            _accounts = new List<Account>();
            _transaction = new List<Transaction>();
        }
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }
        public Account GetAccount( String name)
        {
            for(int i=0;i<_accounts.Count;i++)
            {
                if(_accounts[i].Name==name)
                {
                    return _accounts[i];
                }
              
            }
            return null;
        }
     
        public void ExecuteTransaction(Transaction transaction)
        {
            _transaction.Add(transaction);
            transaction.Execute();
        }
        public void RollbackTransaction(Transaction transaction)
        {
            _transaction.Add(transaction);
            transaction.Rollback();
        }
        public void PrintTransactionHistory()
        {
            for(int i=0;i<_transaction.Count;i++)
            {
                Console.Write("#"+i+" ");
                _transaction[i].Print();
            }
        }
        public Transaction GetTransaction(int index)
        {
          
                    return _transaction[index];
                
        }
    }
}
