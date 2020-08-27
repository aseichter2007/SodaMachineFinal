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
            Run();
        }
        public void Run()
        {
            UserInterface.Hello();
            bool exit = false;
            do
            {
                int[] payCoins = new int[4];
                string response = UserInterface.PromptFor("Would you like to buy a soda?");
                if (UserInterface.ValidInputBinary(response))
                {
                    do
                    {
                        UserInterface.WhatsInMyWallet(customer.wallet);
                        int addCoin = UserInterface.CoinPrompt() - 1;
                        payCoins[addCoin]++;
                        UserInterface.ReadCoins(payCoins);
                    } while (UserInterface.MoreCoins());

                    List<Coin> coinsIn = customer.InsertCoins(payCoins);
                    UserInterface.InsertCoins(payCoins);
                    string soda = UserInterface.SodaPrompt();
                    List<Coin> change = sodaMachine.TakeCoins(coinsIn, soda);
                    UserInterface.ReturnCoins(change);
                    customer.TakeChange(change);

                    if (coinsIn != change)
                    {
                        Can can = sodaMachine.Dispense(soda);
                        customer.TakeCan(can);
                        UserInterface.Dispense(can.name, customer.backpack);
                    }
                    UserInterface.WalletContains(customer.CountChange());
                    UserInterface.RegisterContains(sodaMachine.CountCoinsInRegister());
                }

            } while (!exit);
            UserInterface.PromptFor("thank you for choosing SodaMachine, have a nice day.");
        }
    }

}
