using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    internal class Scania : Car
    {
        public override string Brand => "Scania";
        public override int MaxSpeed => 110;
        public override double SpeedUp =>5;
        public override double Braking => 20;

        public Scania() : base(0) { }

        public override void TurnOn()
        {
            Console.WriteLine("Radio ON ");
        }
        public override void TurnOff()
        {
            Console.WriteLine("Radio OFF! ");
        }
        public override void ChangeStation()
        {
            Console.WriteLine($"The radio station has changed");
        }
        public override void IncreaseVolume()
        {
            Console.WriteLine($"The volume has increased");
        }

        public override void AdjustPosition()
        {
            Console.WriteLine($"The seat has adjusted");
        }
        public override void HeatOn()
        {
            Console.WriteLine($"Heat ON");
        }
        public override void HeatOff()
        {
            Console.WriteLine($"Heat OFF");
        }
    }
}
