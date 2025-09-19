

namespace BankAccountApp {
    class Program {
        public static Customer customer = new Customer();

        static void Main(string[] args) {
            int loginAttempts = 1;

            Console.Write( "Enter PIN: " );
            int pin = Helpers.ValidatePin( Console.ReadLine() );

            while ( !customer.Authenticate( pin ) ) {
                if( loginAttempts++ == 3 ) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( "You have reached the maximum number of login attempts." );
                    Console.ResetColor();
                    Environment.Exit( 0 );
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "Incorrect PIN. Please try again." );
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write( "Enter PIN: " );
                Console.ResetColor();
                pin = Helpers.ValidatePin( Console.ReadLine() );
            }

            Menu.Run();
        }
    }
}