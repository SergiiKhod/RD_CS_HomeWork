using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    internal class Hammer : Car
    {
        public override string Brand => "Hammer";
        public override int MaxSpeed => 160;
        public override double SpeedUp => 10;
        public override double Braking => 20;

        public Hammer() : base(0) { }
        
    }
}
