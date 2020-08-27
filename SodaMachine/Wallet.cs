using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> coins;
        public Card card;

        public Wallet()
        {
            coins = new List<Coin>();
            card = new Card();
            InitWallet(10, 15, 15, 20);
        }
        private void InitWallet(int quarters, int dimes, int nickels, int pennies)
        {
            AddQuarters(quarters);
            AddDimes(dimes);
            AddNickels(nickels);
            AddPennies(pennies);
        }
        private void AddQuarters(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Quarter();
                coins.Add(coin);
            }
        }
        private void AddDimes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Dime();
                coins.Add(coin);
            }
        }
        private void AddNickels(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Nickel();
                coins.Add(coin);
            }
        }
        private void AddPennies(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Coin coin = new Penny();
                coins.Add(coin);
            }
        }
    }
}
