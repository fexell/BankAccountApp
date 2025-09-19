using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp {
    internal class BankAccount {
        const string CURRENCY = "SEK";
        private decimal balance;
        public decimal Balance { get => balance; }

        public BankAccount( decimal balance ) {
            this.balance = balance;
        }

        public void Deposit(decimal amount) {
            while ( amount < 0 ) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( "The amount can't be negative." );
                Console.ResetColor();
                Console.Write( "Enter amount to deposit: " );
                amount = Helpers.ValidateDecimal( Console.ReadLine() );
            }

            balance += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( $"\n{amount} has been added to your balance. Your new balance is {balance} {CURRENCY}\n" );
            Console.ResetColor();
        }

        public void Withdraw( decimal amount ) {
            while ( amount < 0 ) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( "The amount can't be negative." );
                Console.ResetColor();
                Console.Write( "Enter amount to withdraw: " );
                amount = Helpers.ValidateDecimal( Console.ReadLine() );
            }

            while ( amount > balance ) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "You can't withdraw more than your balance." );
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write( "Enter amount to withdraw: " );
                Console.ResetColor();
                amount = Helpers.ValidateDecimal( Console.ReadLine() );
            }

            balance -= amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( $"\n{amount} has been withdrawn from your balance. Your new balance is {balance} {CURRENCY}\n" );
            Console.ResetColor();
        }

        public void GetBalance() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( $"\nYour balance is {balance} {CURRENCY}\n" );
            Console.ResetColor();
        }
    }
}
