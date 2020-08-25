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
    }
}
