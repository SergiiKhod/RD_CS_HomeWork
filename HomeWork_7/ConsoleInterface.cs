using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{

    public class ConsoleInterface
    {
        private enum ItemMenu
        {
            CHOOSE_CAR = 1,
            GET_SPEED = 2,
            PRESS_GAS = 3,
            PRESS_BRAKE = 4,
            EXIT = 0
        }

        private Car[] _cars;

        private Car _currentCar;

        public ConsoleInterface(Car[] cars)
        {
            _cars = cars;
            _currentCar = _cars[0];
        }
        private void ChooseCar()
        {
            while (true)
            {
                ShowMenuChooseCar();
                var choice = Console.ReadLine();
                int item = 0;
                if (int.TryParse(choice, out item))
                {
                    _currentCar = _cars[item - 1];
                    break;
                }
                else
                {
                    Console.Write("Wrong choice. Please, try again:  ");
                }
            }
        }

        private void ShowMenuChooseCar()
        {
            Console.Beep();
            Console.Clear();
            Console.WriteLine("Choose car");
            for (int i = 0; i < _cars.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_cars[i].Brand}");
            }
            Console.Write("Please choose a car, enter the corresponding number: ");
        }
        private void ShowMenu()
        {
            Console.Beep();
            Console.Clear();
            Console.WriteLine("Program Menu:");
            Console.WriteLine("1. Choose car");
            Console.WriteLine("2. Get current speed");
            Console.WriteLine("3. Press gas");
            Console.WriteLine("4. Press brake");
            Console.WriteLine("0. Exit Program");
            Console.Write("Please choose a menu option, enter the corresponding number: ");
        }
        private void Execute(int item)
        {
            switch (item)
            {
                case (int)ItemMenu.CHOOSE_CAR:
                    ChooseCar();
                    Console.WriteLine($"Current cas is {_currentCar.Brand}");
                    Console.Read();
                    break;
                case (int)ItemMenu.GET_SPEED:
                    _currentCar.GetCurrentSpeed(); ;
                    Console.WriteLine($"Speed is {_currentCar.GetCurrentSpeed()}");
                    Console.Read();
                    break;
                case (int)ItemMenu.PRESS_GAS:
                    _currentCar.PressGas();
                    Console.WriteLine($"Speed up to {_currentCar.GetCurrentSpeed()}");
                    Console.Read();
                    break;
                case (int)ItemMenu.PRESS_BRAKE:
                    _currentCar.PressBreak();
                    Console.WriteLine($"Speed down to {_currentCar.GetCurrentSpeed()}");
                    Console.Read();
                    break;
                case (int)ItemMenu.EXIT:
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
                if (int.TryParse(choice, out item))
                {
                    Execute(item);
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
