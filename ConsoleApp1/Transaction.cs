using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Transaction
    {
        protected decimal _amount;
        protected Boolean _success;
        private Boolean _executed;
        private Boolean _reversed;
        private DateTime _dateStamp ;
        public virtual Boolean Success
        {
            get { return _success; }
            protected set { _success = value; }


        }
        public Boolean Executed
        {
            get { return _executed; }
            protected set { _executed = value; }


        }
        public Boolean Reversed
        {
            get { return _reversed; }
            protected set { _reversed = value; }

        }
        public DateTime DateStamp
        {
            get { return _dateStamp; }

        }
        public Transaction( decimal amount)
        {
            this._amount = amount;
           
        }
        public void  Print()
        {
            if(Executed==true)
            {
                Console.WriteLine("Transaction Executed successfully");
            }
            if(Reversed==true)
            {
                Console.WriteLine("Transaction Rollback successfully");

            }
            Console.WriteLine(DateStamp);
        }
        public virtual void Execute()
        {
            _executed = true;
            _dateStamp = DateTime.Now;
            
        }
        public virtual void Rollback()
        {
            _reversed = true;
            _dateStamp = DateTime.Now;
        }
    }
}
