using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    internal class Scania : Car
    {
        public override string Brand => "Scania";
        public override int MaxSpeed => 110;
        public override double SpeedUp =>5;
        public override double Braking => 20;

        public Scania() : base(0) { }
    }
}
