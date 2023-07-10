using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    internal class Hammer : Car
    {
        public override string Brand => "Hammer";
        public override int MaxSpeed => 160;
        public override double SpeedUp => 10;
        public override double Braking => 20;

        public Hammer() : base(0) { }

        public  override void TurnOn()
        {
            Console.WriteLine("Radio does not work ");
        }
        public override void TurnOff()
        {
            Console.WriteLine("Radio does not work ");
        }
        public  override void ChangeStation()
        {
            Console.WriteLine($"Radio does not work");
        }
        public override void IncreaseVolume()
        {
            Console.WriteLine($"Radio does not work");
        }

        public override void AdjustPosition()
        {
            Console.WriteLine($"What?");
        }
        public override void HeatOn()
        {
            Console.WriteLine($"Heating does not work");
        }
        public override void HeatOff()
        {
            Console.WriteLine($"Heating does not work");
        }

    }
}
