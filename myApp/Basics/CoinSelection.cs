using System;

namespace CoinSelection
{
    class Program
    {
        //public int[] coins;

        Program()
        {
            
        }
        public static int SelectCoinIterative(int number)
        {
            if (number<=0) return 0;
            int minCoins=0;
            int[] coins=new int[]{25,10,5,1};
            foreach (int coin in coins)
            {
                while(number -coin>=0){
                    minCoins++;
                    number=number-coin;
                }
            }
            return minCoins;
        }

private static int[] coins = new int[]{10, 6, 1};
public static int SelectCoinRecursive(int c,int[] cache) {
    //if (c == 0) return 0;
    if (cache[c]>=0) return cache[c];
    int minCoins=int.MaxValue;
    // Try removing each coin from the total and
    // see how many more coins are required
    foreach (int coin in coins) {
    // Skip a coin if it’s value is greater
    // than the amount remaining
        if (c - coin >= 0) {
            int currMinCoins = SelectCoinRecursive(c - coin,cache);
            if (currMinCoins < minCoins)
            minCoins = currMinCoins;
        }
    }
// Add back the coin removed recursively
cache[c]=minCoins + 1;
return cache[c];
}
        public static void MainRun(string[] args)
        {
            int[] cache=new int[int.MaxValue];
            Console.WriteLine("Enter the value:");
            int number=Convert.ToInt32(Console.ReadLine());
            int result=SelectCoinRecursive(number,cache);
            Console.WriteLine("Value is {0}",result);
        }
    }
}