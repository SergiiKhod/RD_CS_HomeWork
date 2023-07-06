using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    internal class Ferrari : Car
    {
        public override string Brand => "Ferrari";
        public override int MaxSpeed => 380;
        public override double SpeedUp => 50;
        public override double Braking => 40;

        public Ferrari() : base(0) { }
    }
}
