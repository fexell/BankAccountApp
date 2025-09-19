using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp {
    internal class Customer {
        private const int PIN = 1234;
        public Person Person { get; }
        public BankAccount BankAccount { get; }

        public Customer() {
            Person = new Person("Felix", "123456789");
            BankAccount = new BankAccount( 10000 );
        }

        public bool Authenticate( int pin ) {
            return pin == PIN;
        }
    }
}
