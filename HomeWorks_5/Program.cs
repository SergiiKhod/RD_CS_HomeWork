using System.Xml.Serialization;

namespace HomeWork_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Enter the index number of prime number which you would like found: ");
            string? str = Console.ReadLine();
            int number = 0;
            bool isNumber = Int32.TryParse(str, out number);

            if (isNumber)
            {
                int primeNumber = GetPrimeNumber(number);
                Console.WriteLine($"Your Prime number is {primeNumber}");
            }
            else
            {
                Console.WriteLine($"{str} is not number");
            }

            
            Console.ReadLine();
        }



        public static int[] GetPrimesByEratosthenes(int countNumbers)
        {

            bool[] isPrime = new bool[countNumbers + 1];

            for (int i = 2; i <= countNumbers; i++)
            {
                isPrime[i] = true;
            }

            for (int primeNumber = 2; primeNumber * primeNumber <= countNumbers; primeNumber++)
            {
                if (isPrime[primeNumber] == true)
                {
                    for (int i = primeNumber * primeNumber; i <= countNumbers; i += primeNumber)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            int count = 0;
            for (int i = 2; i <= countNumbers; i++)
            {
                if (isPrime[i] == true)
                {
                    count++;
                }
            }

            int[] primes = new int[count];
            int index = 0;
            for (int i = 2; i <= countNumbers; i++)
            {
                if (isPrime[i] == true)
                {
                    primes[index++] = i;
                }
            }

            return primes;
        }

        public static int GetPrimeNumber(int indexPrimeNumber)
        {
            int primeNumber = 0;
            int k = 0;

            while (primeNumber == 0)
            {
                int countCheckNumbers = GetCountCheckNumbers(indexPrimeNumber + k);
                int[] arrayPrimes = GetPrimesByEratosthenes(countCheckNumbers);                

                if (arrayPrimes.Length >= indexPrimeNumber)
                {
                    primeNumber = arrayPrimes[indexPrimeNumber - 1];
                }
                else
                {
                    k++;
                }
            }
            return primeNumber;
        }

        public static int GetCountCheckNumbers(int indexPrimeNumber)
        {
            double ret = indexPrimeNumber * Math.Log(indexPrimeNumber);

            return (int)ret;
        }
    }
}

