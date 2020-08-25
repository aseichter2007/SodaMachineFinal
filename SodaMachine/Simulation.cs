using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
        }
        public void Run()
        {
            UserInterface.Hello();
            bool exit = false;
            do
            {
                int[] payCoins = new int[4];
                UserInterface.WhatsInMyWallet()
                UserInterface


            } while (!exit);
        }

    }

}
