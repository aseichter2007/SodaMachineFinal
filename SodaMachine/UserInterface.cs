using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    static class UserInterface
    {
        public static void Hello()
        {
            Console.WriteLine(" Hello and welcome to the computer digital soda replicator. \n Don't worry, I made sure you have some virtual coins to buy virtual soda with. ");
        }
        public static string PromptFor(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static double WhatsInMyWallet(Wallet wallet)
        {
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickel = new Nickel();
            Penny penny = new Penny();

            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            double value = 0;

            foreach (Coin coin in wallet.coins)
            {
                if (coin.name == quarter.name)
                {
                    quarters -= -1;

                }
                else if (coin.name == dime.name)
                {
                    dimes -= -1;
                }
                else if (coin.name == nickel.name)
                {
                    nickels -= -1;
                }
                else if (coin.name == penny.name)
                {
                    pennies -= -1;
                }
                else
                {
                    Console.WriteLine("something went wrong counting coins. Contact the developer of this application. : WhatsInMyWallet()");
                }

                value += coin.Value;

            }
            Console.WriteLine($"You have {quarters} quarters, {dimes} dimes, {nickels} nickels, and {pennies} pennies, totalling {value.ToString("c")}  in your wallet.");
            Console.WriteLine("press any key to continue.");
            Console.ReadKey();

            return value;
        }
        public static bool ValidInputBinary(string input)
        {
            bool output = false;
            switch (input.ToLower())
            {
                case "y":
                case "ye":
                case "yes":
                case "why thank you kindly":
                    output = true;
                    break;
            }
            return output;
        }
        public static int ValidInputNumeric(string input)
        {
            int output = -1;
            switch (input)
            {
                case "1":
                    output = 1;
                    break;
                case "2":
                    output = 2;
                    break;
                case "3":
                    output = 3;
                    break;
                case "4":
                    output = 4;
                    break;
                default:
                    output = -1;
                    break;
            }
            return output;
        }
        public static int CoinPrompt()
        {
            int output = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("Please inseert a coin.");
                Console.WriteLine("1. quarter");
                Console.WriteLine("2. dime");
                Console.WriteLine("3. nickel");
                Console.WriteLine("4. penny");
                string response =  Console.ReadLine();
                output = ValidInputNumeric(response);

            } while (output == -1);
            return output;
        }
        public static string SodaPrompt()
        {
            Can cola = new Cola();
            Can rootbeer = new RootBeer();
            Can orange = new OrangeSoda();
            string output = "";
            do
            {
                Console.WriteLine("Please choose a soda.");
                Console.WriteLine("1. " +cola.name);
                Console.WriteLine("2. " + rootbeer.name);
                Console.WriteLine("3. " + orange.name);
                int check = ValidInputNumeric(Console.ReadLine());
                if (check > 0 && check < 4)
                {
                    switch (check)
                    {
                        case 1:
                            output = cola.name;
                            break;
                        case 2:
                            output = rootbeer.name;
                            break;
                        case 3:
                            output = orange.name;
                            break;
                        default:
                            output = "";
                            break;
                    }
                }
            } while (output == "");
            return output;
        }
        public static bool MoreCoins()
        {
            bool output = ValidInputBinary(PromptFor("would you like to insert another coin?"));
            return output;
        }
        public static void ReadCoins(int[] coins)
        {
            Console.WriteLine($"You have inserted {coins[0]} quarters, {coins[1]} dimes, {coins[2]} nickels, and {coins[3]} pennies.\n");
        }
        public static void RegisterContains(int[] coins)
        {
            Console.WriteLine($"The SodaMachine contains {coins[0]} quarters, {coins[1]} dimes, {coins[2]} nickels, and {coins[3]} pennies.\n");
        }
        public static void WalletContains(int[] coins)
        {
            Console.WriteLine($"your wallet contains {coins[0]} quarters, {coins[1]} dimes, {coins[2]} nickels, and {coins[3]} pennies.\n");
        }
        public static void Dispense(string soda, Backpack backpack)
        {
            Console.WriteLine($"the machine spits out a {soda} and youput it in your bag. Your bag now contains {backpack.cans.Count} cans of soda\n");
        }
        public static void InsertCoins(int[] coins)
        {
            Console.WriteLine($"You put {coins[0]} quarters, {coins[1]} dimes, {coins[2]} nickels, and {coins[3]} pennies. Into the soda machine. \n");

        }
        public static void ReturnCoins(List<Coin> coins)
        {
            Console.WriteLine($"The SodaMachine spits out:");
            foreach (Coin coin in coins)
            {
                Console.WriteLine(coin.name);
            }
        }
    }
}
