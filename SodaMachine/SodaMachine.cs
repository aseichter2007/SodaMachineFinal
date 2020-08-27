using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;

        public SodaMachine()
        {
            register = new List<Coin>();
            inventory = new List<Can>();
            InitSodaMachine(20, 10, 20, 50, 15, 15, 15);
        }

        public List<Coin> TakeCoins(List<Coin> change, string soda)
        {
            List<Coin> output = null;
            int[] coins = CountChange(change);
            int[] returnchange = BuySoda(soda, coins[0], coins[1], coins[2], coins[3]);
            if (returnchange != null)
            {
                output = GetCoinsList(returnchange);
            }
            else
            {
                output = change;
            }
            return output;
        }
       
        private List<Coin> GetCoinsList(int[] coinSelection)
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
        private int[] CountChange(List<Coin> coins)
        {
            int[] change = new int[4] { 0, 0, 0, 0 };
            foreach (Coin coin in coins)
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
        private int[] BuySoda(string soda, int quarters, int dimes, int nickels, int pennies)
        {
            double payment = CountChange(quarters, dimes, nickels, pennies);
            double cost = GetSodaCost(soda);
            if (payment == cost)
            {
                AddToRegister(quarters, dimes, nickels, pennies);
                Can can = Dispense(soda);
                if (can != null)
                {
                    return new int[4] { 0, 0, 0, 0 };
                }
                else
                {
                    return null;
                }
            }
            else if (payment > cost)
            {
                AddToRegister(quarters, dimes, nickels, pennies);
                Can can = Dispense(soda);
                if (can != null)
                {
                    return MakeChange(payment - cost);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private bool RemoveCoinFromRegister(string coinName)
        {
            bool output = false;
            foreach (Coin coin in register)
            {
                if (coin.name == coinName)
                {
                    register.Remove(coin);
                    return true;
                }
            }
            return output;
        }
        private bool RegisterContainsCoin(string name)
        {
            foreach (Coin coin in register)
            {
                if (coin.name == name)
                {
                    return true;
                }
            }
            return false;
        }
        private int[] MakeChange(double change)
        {
            bool success = true;
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickle = new Nickel();
            Penny penny = new Penny();
            int[] changeReturned = new int[4] { 0, 0, 0, 0 };
            do
            {
                if (change > quarter.Value && RegisterContainsCoin(quarter.name))
                {
                    success = RemoveCoinFromRegister(quarter.name);
                    change -= quarter.Value;
                    changeReturned[0]++;
                }
                else if (change > dime.Value && RegisterContainsCoin(dime.name))
                {
                    success = RemoveCoinFromRegister(dime.name);
                    change -= dime.Value;
                    changeReturned[1]++;
                }
                else if (change > nickle.Value && RegisterContainsCoin(nickle.name))
                {
                    success = RemoveCoinFromRegister(nickle.name);
                    change -= nickle.Value;
                    changeReturned[2]++;
                }
                else if (change>penny.Value && RegisterContainsCoin(penny.name))
                {
                    success = RemoveCoinFromRegister(penny.name);
                    change -= penny.Value;
                    changeReturned[3]++;
                }
                else
                {
                    success = false;
                }
            } while (change > 0 && success == true);
            if (success)
            {
            return changeReturned;
            }
            else
            {
                AddToRegister(changeReturned[0], changeReturned[1], changeReturned[2], changeReturned[3]);
                return null;
            }

        }
        public int[] CountCoinsInRegister()
        { 

            int[] change = new int[4] { 0, 0, 0, 0 };
            foreach (Coin coin in register)
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
        private double GetSodaCost(string soda)
        {
            Can can;
            switch (soda)
            {
                case "Cola":
                    can = new Cola();
                    return can.Cost;
                case "Root Beer":
                    can = new RootBeer();
                    return can.Cost;
                case "Orange Soda":
                    can = new OrangeSoda();
                    return can.Cost;
            }
            return -1;
        }
        private double CountChange(int quarters, int dimes, int nickels, int pennies)
        {
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickle = new Nickel();
            Penny penny = new Penny();
            double value = 0;

            value += quarter.Value * quarters;
            value += dime.Value * dimes;
            value += nickle.Value * nickels;
            value += penny.Value * pennies;

            return value;

        }
        
        public Can Dispense(string soda)
        {
            foreach (Can can in inventory)
            {
                if (can.name == soda)
                {
                    inventory.Remove(can);
                    return can;
                }
            }
            return null;
        }
        private void InitSodaMachine(int quarters, int dimes, int nickels, int pennies, int cola, int rootbeer, int orange)
        {
            AddToRegister(quarters, dimes, nickels, pennies);
            InitInventory(cola, rootbeer, orange);

        }
        private void AddToRegister(int quarters, int dimes, int nickels, int pennies)
        {
            AddQuarters(quarters);
            AddDimes(dimes);
            AddNickels(nickels);
            AddPennies(pennies);           
        }    

        private void InitInventory(int cola, int rootbeer, int orange)
        {
            AddCola(cola);
            AddRootBeer(rootbeer);
            AddOrange(orange);
        }
        public void AddCola(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Can can = new Cola();
                inventory.Add(can);
            }
        }
        public void AddRootBeer(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Can can = new RootBeer();
                inventory.Add(can);
            }
        }
        public void AddOrange(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Can can = new OrangeSoda();
                inventory.Add(can);
            }
        }
        private void AddQuarters(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Quarter();
                register.Add(coin);
            }
        }
        private void AddDimes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Dime();
                register.Add(coin);
            }
        }
        private void AddNickels(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Nickel();
                register.Add(coin);
            }
        }
        private void AddPennies(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Penny();
                register.Add(coin);
            }
        }
    }
}
