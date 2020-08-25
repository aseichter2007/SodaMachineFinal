using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    static class UserInterface
    {
        public static void Hello()
        {
            Console.WriteLine("");
        }
        public static string PromptFor(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static double WhatsInMyWallet(Wallet wallet)
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            double value = 0;

            foreach (Coin coin in wallet.coins)
            {
                if (coin.name == "quarter")
                {
                    quarters -= -1;

                }
                else if (coin.name == "dime")
                {
                    dimes -= 1;
                }
                else if (coin.name == "nickel")
                {
                    nickels -= -1;
                }
                else if (coin.name == "penny:")
                {
                    pennies -= -1;
                }
                else
                {
                    Console.WriteLine("something went wrong counting coins. Contact the developer of this application.");
                }

                value += coin.Value;

            }
            Console.WriteLine($"You have {quarters} quarters, {dimes} dimes, {nickels} nickels, and {pennies} pennies, totalling {value.ToString("c")}  in your wallet.");
            return value;
        }

    }
}
