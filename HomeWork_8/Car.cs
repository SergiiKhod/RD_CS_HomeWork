using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    public abstract class Car: ISeats, IRadio
    {
        public abstract string Brand { get; }
        public abstract int MaxSpeed { get; }
        public abstract double SpeedUp { get; }
        public abstract double Braking { get; }

        private double _currentSpeed;

        public double GetCurrentSpeed() => _currentSpeed;

        public void PressGas()
        {
            _currentSpeed += SpeedUp;
            if (_currentSpeed > MaxSpeed)
                _currentSpeed = MaxSpeed;
        }

        public void PressBreak()
        {
            _currentSpeed -= SpeedUp;
            if (_currentSpeed < 0)
                _currentSpeed = 0;
        }

        public Car(int speed)
        {
            _currentSpeed = speed;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void ChangeStation();
        public abstract void IncreaseVolume();
        public abstract void AdjustPosition();
        public abstract void HeatOn();
        public abstract void HeatOff();
    }
}
