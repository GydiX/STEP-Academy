using System;
using System.Threading;

namespace BankAccountSimulation
{
    class BankAccount
    {
        private decimal balance;
        private readonly object locker = new object();

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            Monitor.Enter(locker);
            try
            {
                if (balance >= amount)
                {
                    Console.WriteLine($"Withdrawing {amount} by Thread {Thread.CurrentThread.ManagedThreadId}");
                    balance -= amount;
                }
                else
                {
                    Console.WriteLine($"Insufficient funds for Thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(1000m);

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() => account.Withdraw(300m));
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"Final balance: {account.GetBalance()}");
        }
    }
}
