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
        public void TakeCan(Can can)
        {
            backpack.cans.Add(can);
        }
        public void TakeChange(List<Coin> change)
        {
            foreach (Coin coin in change)
            {
                wallet.coins.Add(coin);
            }
        }
        public List<Coin> InsertCoins(int[] coins)
        {
            if (PayForSoda(coins[0],coins[1],coins[2],coins[3]))
            {
                return GetCoinsList(coins);
            }
            else
            {
                return null;
            }
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
            List<Coin> RemoveCoins = new List<Coin>();
            int[] paid = new int[4] { 0, 0, 0, 0 };
            foreach (Coin coin in wallet.coins)
            {
                if (coin.name == "quarter")
                {
                    if (paid[0] < quarters)
                    {
                        paid[0]++;
                        RemoveCoins.Add(coin);
                    }
                }
                else if (coin.name == "dime")
                {
                    if (paid[1] < dimes)
                    {
                        paid[1]++;
                        RemoveCoins.Add(coin);
                    }
                }
                else if (coin.name == "nickel")
                {
                    if (paid[2] < nickels)
                    {
                        paid[2]++;
                        RemoveCoins.Add(coin);
                    }
                }
                else if (coin.name == "penny")
                {
                    if (paid[3] < pennies)
                    {
                        paid[3]++;
                        RemoveCoins.Add(coin);
                    }
                }
            }
            foreach (Coin coin in RemoveCoins)
            {
                wallet.coins.Remove(coin);
            }
        }
        public int[] CountChange()
        {
            //Quarter quarter = new Quarter();
            //Dime dime = new Dime();
            //Nickel nickel = new Nickel();
            //Penny penny = new Penny();

            int[] change = new int[4] { 0, 0, 0, 0 };
            foreach (Coin coin in wallet.coins)
            {
                switch (coin.name)
                {
                    //case quarter.name://why cant I set this?
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
                        Console.WriteLine("there was an error counting coins, please contact the developer of this application : CountChange()");
                        break;
                }
            }
            return change;
        }
        public List<Coin> GetCoinsList(int[] coinSelection)
        {
            List<Coin> output = new List<Coin>();
            for (int i = 0; i < coinSelection.Length; i++)
            {
                for (int j = 0; j < coinSelection[i]; j++)
                {
                    Coin coin;
                    switch (i)
                    {
                        case 0:
                            coin = new Quarter();
                            output.Add(coin);
                            break;
                        case 1:
                            coin = new Dime();
                            output.Add(coin);
                            break;
                        case 2:
                            coin = new Nickel();
                            output.Add(coin);
                            break;
                        case 3:
                            coin = new Penny();
                            output.Add(coin);
                            break;
                    }
                }
            }
            return output;
        }

    }
}
