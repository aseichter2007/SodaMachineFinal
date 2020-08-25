using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Register
    {
        public List<Coin> register;
        public List<Can> inventory;

        public Register()
        {
            register = new List<Coin>;
            inventory = new List<Can>;
            InitSodaMachine();
        }
        private void InitSodaMachine()
        {
            InitRegister(20, 10, 20, 50);
            InitInventory(15, 15, 15);
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
                Coin coin = new Nickle();
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
