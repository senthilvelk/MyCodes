using System;

namespace myApp
{
    class Program
    {
        public static int Factorial(int number)
        {
            if (number==1) return 1;
            else return(number*Factorial(number-1));
        }
        static void MainRun(string[] args)
        {
            Console.WriteLine("Factorial computation:");
            Console.WriteLine("Enter number:");
            int number=Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Factorial is: {0}",Factorial(number));
        }
    }
}
