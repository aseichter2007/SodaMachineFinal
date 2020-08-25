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

        public int[] BuySoda(string soda, int quarters, int dimes, int nickels, int pennies)
        {
            double payment = CountChange(quarters, dimes, nickels, pennies);
            double cost = GetSodaCost(soda);
            if (payment == cost)
            {
                Can can = Dispense(soda);
                if (can != null)
                {
                    return new int[4] { 0, 0, 0, 0 };
                }
                else
                {
                    return new int[4] { -1, -1, -1, -1 };
                }
            }
            else if (payment > cost)
            {
                Can can = Dispense(soda);
                if (can != null)
                {
                    return MakeChange(payment - cost);
                }
                else
                {
                    return new int[4] { -1, -1, -1, -1 };
                }
            }
            else
            {
                return new int[4] { -2, -2, -2, -2 };
            }


        }
        private int[] MakeChange(double change)
        {
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickle = new Nickel();
            Penny penny = new Penny();
            int[] changeReturned = new int[4] { 0, 0, 0, 0 };
            do
            {          
                if (change > quarter.Value)
                {
                    change -= quarter.Value;
                    changeReturned[0]++;
                }
                else if (change > dime.Value)
                {
                    change -= dime.Value;
                    changeReturned[1]++;
                }
                else if (change > nickle.Value)
                {
                    change -= nickle.Value;
                    changeReturned[2]++;
                }
                else if (change>penny.Value)
                {
                    change -= penny.Value;
                    changeReturned[3]++;
                }
            } while (change > 0);
            return changeReturned;
        }
        public double GetSodaCost(string soda)
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
        public double CountChange(int quarters, int dimes, int nickels, int pennies)
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
        
        private Can Dispense(string soda)
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
            InitRegister(quarters, dimes, nickels, pennies);
            InitInventory(cola, rootbeer, orange);

        }
        private void InitRegister(int quarters, int dimes, int nickels, int pennies)
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
