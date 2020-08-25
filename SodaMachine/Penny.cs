using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Penny : Coin
    {
        public Penny()
        {
            this.name = "penny";
            this.value = 0.01;
        }
    }
}
