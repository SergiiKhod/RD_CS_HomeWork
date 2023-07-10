using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace HomeWork_8
{
    internal class Ferrari : Car
    {
        public override string Brand => "Ferrari";
        public override int MaxSpeed => 380;
        public override double SpeedUp => 50;
        public override double Braking => 40;
        
        public Ferrari() : base(0) { }

        public override void TurnOn()
        {
            Console.WriteLine("Welcome to the RedRadio! ");
        }
        public override void TurnOff()
        {
            Console.WriteLine("Goob bye! ");
        }
        public override void ChangeStation()
        {
            Random rand = new Random(800);
            double station = 100 + (double)rand.Next() / 100;
            Console.WriteLine($"You are listening to a radio station {station}");
        }
        public override void IncreaseVolume()
        {
            Console.WriteLine($"The volume is increased to a comfortable sound");
        }

        public override void AdjustPosition()
        {
            Console.WriteLine($"The seat has adjusted to a comfortable position");
        }
        public override void HeatOn()
        {
            Console.WriteLine($"Comfortable heating of the buttocks is included");
        }
        public override void HeatOff()
        {
            Console.WriteLine($"Comfortable heating of the buttocks is disabled");
        }
    }
}
