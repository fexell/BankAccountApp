using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAccountApp {
    internal class Helpers {
        public static decimal ValidateDecimal( string input ) {
            while (true) {
                if ( decimal.TryParse( input, out decimal result ) ) {
                    return result;
                }

                Console.Write("Invalid input. Please enter a valid decimal number: ");
                input = Console.ReadLine();
            }
        }

        public static int ValidatePin( string input ) {
            while ( true ) {
                if ( !int.TryParse( input, out int result ) && !Regex.IsMatch( result.ToString(), @"[0-9]{4}" ) ) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write( "Invalid input. Please enter a valid 4-digit PIN: " );
                    Console.ResetColor();
                    input = Console.ReadLine();
                }

                return result;
            }
        }
    }
}
