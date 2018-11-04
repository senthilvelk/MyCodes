using System;
 
namespace numberOfBST
{
    class Program
    {
    
        public static int numberOfBST(int inputValue)
        {
            //Applying Catalan equation, Cn= (2n)!/(n+1)!n!
            int result=Factorial(2*inputValue)/Factorial(inputValue+1)*Factorial(inputValue);
            return result;
        }

        public static int Factorial(int number)
        {
            if(number==1) return 1;

            return number*Factorial(number-1);
        }

        public static void MainRun() 
        {
            Console.WriteLine("Enter the number:");
            int number=Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Number of unique BST for {0} is {1}",number,numberOfBST(number));
        }
    }
}