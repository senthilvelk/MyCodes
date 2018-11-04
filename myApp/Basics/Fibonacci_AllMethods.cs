using System;

public class Program
{
    public const int MAX=100; 
    private static int Compute_Iterative(int number)
    {
        int first=0;
        int second=1;
        int result=first;

        if (number==0) return first;
        if(number==1) return second;
        for(int i=1;i<number;i++)
        {
            result=first+second;
            first=second;
            second=result;
        }
        return result;
    }

    public static int Compute_Recursive(int number)
    {
        if(number==0) return 0;
        if(number==1) return 1;
        return Compute_Recursive(number-1)+Compute_Recursive(number-2);
    }

    public static int Compute_Recursive_Memoization(int number,int[] memo)
    {
        if(number==0) return 0;
        if(number==1) return 1;
        if (memo[number].Equals(0))
        {
            memo[number]=Compute_Recursive_Memoization(number-1,memo)+Compute_Recursive_Memoization(number-2,memo);
            return memo[number]; 
        }
        else
        {
            return memo[number];
        }
    }
    public static void MainRun(string[] args)
    {
        int[] memo=new int[MAX];
        Console.WriteLine("Enter the nth Fibonacci number required:");
        //Console.WriteLine("hello "+Console.ReadLine());
        int number=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("{0}th Fibonacci number is {1} through iterative method",number,
            Compute_Iterative(number));
        Console.WriteLine("{0}th Fibonacci number is {1} through recursive method",number,
            Compute_Recursive(number));
        Console.WriteLine("{0}th Fibonacci number is {1} through recursive memoization method",number,
            Compute_Recursive_Memoization(number,memo));
    }
}