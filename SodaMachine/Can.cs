using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    abstract class Can
    {
        protected double cost;
        public double Cost { get => cost; }
        public string name;
    }
}
