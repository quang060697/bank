using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DepositTransaction : Transaction
    {
        private Account _account;
      
        public DepositTransaction( Account account,decimal amount) : base(amount)
        {
            this._account = account;
        }
        public  void Print()
        {
            if (_success == true)
            {
                _account.Print();
                Console.WriteLine("Deposit amount: " + this._amount);
            }
            else
            {
                Console.WriteLine("Transaction failed");
            }


        }
        public override void Execute()
        {
            if (Executed == true)
            {
                throw new System.InvalidOperationException("The deposit has been occured");
            }

            if (this._amount>0)
            {
                base.Execute();
                _account.Deposit(_amount);
                _success = true;
            }
            else
            {
                throw new System.InvalidOperationException("Not enough fund");

            }


        }
        public override void Rollback()
        {
            if (Reversed == true)
            {
                throw new System.InvalidOperationException("The rollback has been occured");
            }
            else if (_success == true)
            {
                base.Rollback();
                _account.Withdraw(_amount);
                
            }
        }
     
     
    }
}
