using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class BankSystem
    {
        static void Main(string[] args)
        {
        
            Bank newbank = new Bank();
            MenuOption option;
            do{
            option =ReadUserOption();
            
            switch (option)
            {
                case MenuOption.WITHDRAW:
                {
                    DoWithdraw(newbank);
                           
                    break;
                }
                case MenuOption.DEPOSIT:
                {
                    DoDeposit(newbank);
                    break;
                }
                case MenuOption.PRINT:
                {
                    DoPrint(newbank);
                    break;
                }
                case MenuOption.TRANSFER:
                {
                    DoTransfer(newbank);
                    break;
                }
                case MenuOption.ADDNEWACCOUNT:
                {
                   DoAddAccount(newbank); 
                   break;
                }
                case MenuOption.PRINTHISTORYTRANSACTION:
                {
                    DoPrintTransactionHistory(newbank);
                    break;
                }
                case MenuOption.ROLLBACK:
                {
                    DoRollback(newbank);
                    break;
                }
                case MenuOption.QUIT:
                break;
            }
            }while(option!=MenuOption.QUIT);
        }
       
       
     enum MenuOption
        {
            WITHDRAW,
            DEPOSIT,
            PRINT,
            TRANSFER,
            ADDNEWACCOUNT,
            PRINTHISTORYTRANSACTION,
            ROLLBACK,
            QUIT
        };
        
    static MenuOption ReadUserOption()
    {
        int result;
        
       
            Console.WriteLine("1.WITHDRAW");
            Console.WriteLine("2.DEPOSIT");
            Console.WriteLine("3.PRINT");
            Console.WriteLine("4.TRANSFER");
            Console.WriteLine("5.ADD A NEW ACCOUNT");
            Console.WriteLine("6.PRINT HISTORY TRANSACTION");

            Console.WriteLine("7.ROLL BACK");
            Console.WriteLine("8.QUIT");
            result=Convert.ToInt32(Console.ReadLine());
            while(result <1 || result>8)
            {
                Console.WriteLine("Please enter valid option");
                result=Convert.ToInt32(Console.ReadLine());

            }
            return (MenuOption)Convert.ToInt32(result-1);
    }
         static void DoDeposit(Bank bank)
        {
            Account account= FindAccount(bank);
            if (account != null)
            {
                Console.WriteLine("Enter amount of value you want to deposit: ");

                DepositTransaction b = new DepositTransaction(account, Convert.ToDecimal(Console.ReadLine()));
                bank.ExecuteTransaction(b);
                b.Print();
                Console.WriteLine("Deposit succeed");
            }
            else
            {
                Console.WriteLine("Account is not available");

            }
        }
         static void DoWithdraw(Bank bank)
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                Console.WriteLine("Enter amount of value you want to withdraw: ");

                WithdrawTransaction b = new WithdrawTransaction(account, Convert.ToDecimal(Console.ReadLine()));
                bank.ExecuteTransaction(b);
                Console.WriteLine("Withdraw succeed");

            }
            else
            {
                Console.WriteLine("Account is not available");

            }
        }
         static void DoPrint(Bank bank)
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                account.Print();
            }
            else
            {
                Console.WriteLine("Account is not available");

            }
        }
        static void DoTransfer(Bank bank)
        {
            Console.WriteLine("THE DEBIT ACCOUNT");
            Account fromAccount = FindAccount(bank);
            Console.WriteLine("THE CREDIT ACCOUNT");

            Account toAccount = FindAccount(bank);
            if (fromAccount != null && toAccount != null)
            {
                Console.WriteLine("Enter amount of value you want to transfer: ");
                TransferTransaction b = new TransferTransaction(fromAccount, toAccount, Convert.ToDecimal(Console.ReadLine()));
                bank.ExecuteTransaction(b);

            }
            else
            {
                Console.WriteLine("Account is not available");

            }


        }
        static void DoAddAccount(Bank bank)
        {
            Console.WriteLine("Enter the new bank account name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the balance: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            Account a = new Account(name, balance);
            bank.AddAccount(a);
            Console.WriteLine("Add account successfully");
            
        }
        static Account FindAccount(Bank bank)
        {
            Console.WriteLine("Enter the account name: ");
            string name = Console.ReadLine();
           
                return bank.GetAccount(name);
          
        }
        static void DoPrintTransactionHistory(Bank bank)
        {
            bank.PrintTransactionHistory();
        }
        static void DoRollback(Bank bank)
        {
            Console.WriteLine("Enter the transaction number you want to rollback");
            Transaction a = bank.GetTransaction(Convert.ToInt32(Console.ReadLine()));
            bank.RollbackTransaction(a);
        }


    }
     
     
}
