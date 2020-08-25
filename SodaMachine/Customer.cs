using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }
        public bool PayForSoda(int quarters, int dimes, int nickels, int pennies)
        {
            int[] change = CountChange();
            bool CanAfford = true;
            if (change[0] > quarters)
            {
                if (change[1] > dimes)
                {
                    if (change[2] > nickels)
                    {
                        if (change[3] > pennies)
                        {
                            PayChange(quarters,dimes,nickels,pennies);
                        }
                        else
                        {
                            CanAfford = false;
                        }
                    }
                    else
                    {
                        CanAfford = false;
                    }
                }
                else
                {
                    CanAfford = false;
                }
            }
            else
            {
                CanAfford = false;
            }

            return CanAfford;
        }
        public void PayChange(int quarters, int dimes, int nickels, int pennies)
        {
            int[] paid = new int[4] { 0, 0, 0, 0 };
            foreach (Coin coin in wallet.coins)
            {
                if (coin.name == "quarter")
                {
                    if (paid[0] < quarters)
                    {
                        paid[0]++;
                        wallet.coins.Remove(coin);
                    }
                }
                else if (coin.name == "dime")
                {
                    if (paid[1] < dimes)
                    {
                        paid[1]++;
                        wallet.coins.Remove(coin);
                    }
                }
                else if (coin.name == "nickel")
                {
                    if (paid[2] < nickels)
                    {
                        paid[2]++;
                        wallet.coins.Remove(coin);
                    }
                }
                else if (coin.name == "penny")
                {
                    if (paid[3] < pennies)
                    {
                        paid[3]++;
                        wallet.coins.Remove(coin);
                    }
                }
            }
        }
        private int[] CountChange()
        {
            int[] change = new int[4] { 0, 0, 0, 0 };
            foreach (Coin coin in wallet.coins)
            {
                switch (coin.name)
                {
                    case "quarter":
                        change[0]++;
                        break;
                    case "dime":
                        change[1]++;
                        break;
                    case "nickel":
                        change[2]++;
                        break;
                    case "penny":
                        change[3]++;
                        break;
                    default:
                        Console.WriteLine("there was an error counting coins, please contact the developer of this application");
                        break;
                }
            }
            return change;
        }

    }
}
