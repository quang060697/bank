using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Account
    {
        private decimal _balance;
        private String _name;
        public Account(String name, decimal balance)
        {
            this._name = name;
            this._balance = balance;
        }
        public bool Deposit(decimal amount)
        {
            if(amount<=0)
            {
                Console.WriteLine("Deposit Failed ");
                return false;
            }
            else
            {
                this._balance+= amount;
                
                return true;
            }
        }
        public bool Withdraw(decimal amount)
        {
            if (amount<0 || amount >this._balance)
            {
                Console.WriteLine("Withdraw Failed ");
                return false;
            }
            else
            {
                this._balance-= amount;
                
                return true;
            }
        }
        public void Print()
        {
            Console.WriteLine("Account name: " + this._name);
            Console.WriteLine("Account balance: " + this._balance);
        }
        public string Name
        {
            get => _name;
            private set => value = _name;


        }
        public decimal Balance
        {
            get => _balance;
            private set => value = _balance;
            
        }

    }
}