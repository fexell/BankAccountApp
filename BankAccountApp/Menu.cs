using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp {
    internal class Menu {
        static Dictionary<int, MenuItem> MenuItems = new() {
            { 1, new MenuItem( "Deposit", () => {
                Console.Write( "\nEnter amount to deposit: " );
                Program.customer.BankAccount.Deposit( Helpers.ValidateDecimal( Console.ReadLine() ) );
            } ) },
            { 2, new MenuItem( "Withdraw", () => {
                Console.Write( "\nEnter amount to withdraw: " );
                Program.customer.BankAccount.Withdraw( Helpers.ValidateDecimal( Console.ReadLine() ) );
            } ) },
            { 3, new MenuItem( "Show Balance", () => Program.customer.BankAccount.GetBalance() ) },
            { 4, new MenuItem( "Exit", () => Environment.Exit( 0 ) ) },
        };

        static void ShowMenu() {
            foreach( var menuItem in MenuItems ) {
                Console.WriteLine( $"{menuItem.Key}. {menuItem.Value.Name}" );
            }
        }

        static void MenuLoop() {
            while( true ) {
                Console.Clear();

                Console.WriteLine( "====== CASH MACHINE ======" );

                ShowMenu();

                Console.WriteLine( "==========================" );

                Console.Write( "Select an option: " );

                if( int.TryParse( Console.ReadLine(), out int result ) && MenuItems.ContainsKey( result ) ) {
                    MenuItems[ result ].Action();
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( "Invalid option. Press any key to try again..." );
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        public static void Run() {
            MenuLoop();
        }
    }

    internal class MenuItem : Menu {
        public string Name;
        public Action Action;

        public MenuItem( string name, Action action, bool isAutoReturn = true ) {
            Name = name;
            
            if( isAutoReturn )
                Action = () => { action(); Console.WriteLine( "Press any key to return to the main menu..." ); Console.ReadKey(); };
            else
                Action = action;
        }
    }
}
