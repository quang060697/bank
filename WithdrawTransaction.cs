using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class WithdrawTransaction: Transaction
    {
        private Account _account;
   
     
        public WithdrawTransaction(Account account,decimal amount):base(amount)
        {
            this._account = account;
  
        }
        public void Print()
        {
            if (_success == true)
            {
                _account.Print();
                Console.WriteLine("Withdraw amount: " + this._amount);
            }
            else
            {
                Console.WriteLine("Transaction failed");
            }
            
            
        }
        public override void Execute()
        {
            if(Executed==true)
            {
                throw new System.InvalidOperationException("The withdraw has been occured");
            }
            
            if(_account.Balance>=this._amount)
            {
                base.Execute();

                _account.Withdraw(_amount);
                _success = true;

            }
            else
            {
                throw new System.InvalidOperationException("Not enough fund");

            }


        }
        public override void Rollback()
        {
            if(Reversed==true)
            {
                throw new System.InvalidOperationException("The rollback has been occured");
            }
            else if(_success==true)
            {
                _account.Deposit(_amount);
                base.Reversed = true;
            }
        }
        
    }
}
