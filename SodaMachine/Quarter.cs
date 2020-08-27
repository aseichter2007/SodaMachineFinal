using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Quarter : Coin
    {
        public Quarter()
        {
            this.name = "quarter";
            this.value = 0.25;
        }
    }
}
