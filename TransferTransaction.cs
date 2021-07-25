using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TransferTransaction: Transaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        public override bool Success => _withdraw.Success && _deposit.Success;

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount):base(amount)
        {
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
            
            this._withdraw = new WithdrawTransaction(fromAccount, amount);
            this._deposit = new DepositTransaction(toAccount, amount);
        }
        public void Print()
        {
            Console.WriteLine("Transferred " + this._amount + " from " + this._fromAccount.Name+ " account " + " to " + this._toAccount.Name+" account ");
            _deposit.Print();
            _withdraw.Print();

        }
        public override void Execute()
        {
            if (Executed == true)
            {
                throw new System.InvalidOperationException("The deposit has been occured");
            }

            if (_fromAccount.Balance >= this._amount)
            {
                
                base.Execute();
                _withdraw.Execute();
                _success = true;
                if (_withdraw.Success == true)
                {
                    _deposit.Execute();
                    if (_deposit.Success == false)
                    {
                        _withdraw.Rollback();
                    }
                   
                }
               
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
            else if (this.Success == true)
            {
                base.Rollback();
                _withdraw.Rollback();
                
                _deposit.Rollback();
                if (_toAccount.Balance < this._amount)
                {
                    throw new System.InvalidOperationException("Fund not enough to rollback");

                }
                else
                {
                    base.Reversed = true;
                }


            }
        }
       

     
    }
}
