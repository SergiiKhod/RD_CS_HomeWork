using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{

    public class ConsoleInterface
    {
        private enum ItemMenu
        {
            GET_SPEED = 1,
            PRESS_GAS = 2,
            PRESS_BRAKE = 3,
            RADIO_ON = 4,
            RADIO_OFF = 5,
            CHANGE_STATTION=6,
            INCREASE_VOLUME=7,
            HEAT_ON = 8,
            HEAT_OFF = 9,
            ADJUST_POSITION = 10,
            EXIT = 0
        }

        private IList<Car> _cars;


        public ConsoleInterface(Car[] cars)
        {
            _cars = cars;
        }
     

        private Car SelectCar()
        {
            Console.WriteLine("Select car");
            for (int i = 0; i < _cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_cars[i].Brand}");
            }
            Console.Write("Please select a car, enter the corresponding number: ");
            int numberCar = -1;
            while (!(numberCar>0 && numberCar<=_cars.Count))
            {
                var strNumberCar= Console.ReadLine();
                if (!int.TryParse(strNumberCar, out numberCar))
                {
                    Console.Write($"Number of car must be between 1 and {_cars.Count}. Please try again: ");
                }
            }            
            return _cars[numberCar-1];
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Program Menu:");
            Console.WriteLine($"{(int)ItemMenu.GET_SPEED}. Get current speed");
            Console.WriteLine($"{(int)ItemMenu.PRESS_GAS}. Press gas");
            Console.WriteLine($"{(int)ItemMenu.PRESS_BRAKE}. Press brake");
            Console.WriteLine($"{(int)ItemMenu.RADIO_ON}. Radio ON");
            Console.WriteLine($"{(int)ItemMenu.RADIO_OFF}. Radio OFF");
            Console.WriteLine($"{(int)ItemMenu.CHANGE_STATTION}. Change the radio stattion");
            Console.WriteLine($"{(int)ItemMenu.INCREASE_VOLUME}. Increase volume");
            Console.WriteLine($"{(int)ItemMenu.HEAT_ON}. Heat ON");
            Console.WriteLine($"{(int)ItemMenu.HEAT_OFF}. Heat OFF");
            Console.WriteLine($"{(int)ItemMenu.ADJUST_POSITION}. Adjust the seat position");
            Console.WriteLine($"{(int)ItemMenu.EXIT}. Exit");
            Console.Write("Please select a menu option, enter the corresponding number: ");
        }
        private void Execute(ItemMenu item)
        {
            switch (item)
            {
                case ItemMenu.GET_SPEED:
                    {
                        Car car = SelectCar();
                        car.GetCurrentSpeed(); ;
                        Console.WriteLine($"Speed is {car.GetCurrentSpeed()}");
                        Console.Read();
                        break;
                    }
                case ItemMenu.PRESS_GAS:
                    {
                        Car car = SelectCar();
                        car.PressGas();
                        Console.WriteLine($"Speed up to {car.GetCurrentSpeed()}");
                        Console.Read();
                        break;
                    }
                case ItemMenu.PRESS_BRAKE:
                    {
                        Car car = SelectCar();
                        car.PressBreak();
                        Console.WriteLine($"Speed down to {car.GetCurrentSpeed()}");
                        Console.Read();
                        break;
                    }
                case ItemMenu.RADIO_ON:
                    {
                        Car car = SelectCar();
                        car.TurnOn();
                        Console.Read();
                        break;
                    }
                case ItemMenu.RADIO_OFF:
                    {
                        Car car = SelectCar();
                        car.TurnOff();
                        Console.Read();
                        break;
                    }
                case ItemMenu.CHANGE_STATTION:
                    {
                        Car car = SelectCar();
                        car.ChangeStation();
                        Console.Read();
                        break;
                    }
                case ItemMenu.HEAT_OFF:
                    {
                        Car car = SelectCar();
                        car.HeatOff();
                        Console.Read();
                        break;
                    }
                case ItemMenu.HEAT_ON:
                    {
                        Car car = SelectCar();
                        car.HeatOn();
                        Console.Read();
                        break;
                    }
                case ItemMenu.ADJUST_POSITION:
                    {
                        Car car = SelectCar();
                        car.AdjustPosition();
                        Console.Read();
                        break;
                    }
                case ItemMenu.INCREASE_VOLUME:
                    {
                        Car car = SelectCar();
                        car.IncreaseVolume();
                        Console.Read();
                        break;
                    }
                case ItemMenu.EXIT:
                    ExitProgram();
                    break;
                default:
                    Console.Write("Invalid menu choice. Please try again:");
                    break;
            }
        }
        public void Run()
        {
            while (true)
            {
                ShowMenu();
                var choice = Console.ReadLine();
                int item = 0;
                if (int.TryParse(choice, out item) &&  item >=0 && item<=10)
                {                                  
                    Execute((ItemMenu)item);
                }
                else
                {
                    Console.Write("Wrong choice. Please, try again:  ");
                }
            }
        }
        private static void ExitProgram()
        {
            Console.WriteLine("Exiting the program...");
            Environment.Exit(0);
        }
    }
}
